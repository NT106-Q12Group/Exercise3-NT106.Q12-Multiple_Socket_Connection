using System;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace Exercise3_NT106.Q12_TCPClient
{
    public class TCPClient
    {
        private readonly string serverIP;
        private readonly int serverPort;
        private TcpClient? client;
        private NetworkStream? stream;
        private bool isConnected;

        public TCPClient(string ip, int port)
        {
            serverIP = ip;
            serverPort = port;
        }

        public bool Connect()
        {
            try
            {
                if (isConnected && client != null && client.Connected) return true;

                client = new TcpClient();
                client.Connect(serverIP, serverPort);
                stream = client.GetStream();
                isConnected = true;
                Console.WriteLine("[Client] CONNECTED");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("[Client] CONNECT FAIL: " + ex.Message);
                isConnected = false;
                return false;
            }
        }

        public void Disconnect()
        {
            try { stream?.Close(); stream?.Dispose(); } catch { }
            try { client?.Close(); } catch { }
            stream = null; client = null; isConnected = false;
            Console.WriteLine("[Client] DISCONNECTED");
        }

        public bool TestConnection() => IsConnected() || Connect();
        public bool IsConnected() => isConnected && client != null && client.Connected;

        private string Send(string request)
        {
            try
            {
                if (!IsConnected() && !Connect())
                    return "Error|Cannot connect";

                Console.WriteLine("[Client] SEND → " + request);
                var s = stream!;
                var data = Encoding.UTF8.GetBytes(request);
                s.Write(data, 0, data.Length);

                var buf = new byte[4096];
                int n = s.Read(buf, 0, buf.Length);
                if (n == 0) { Disconnect(); return "Error|Disconnected"; }

                var resp = Encoding.UTF8.GetString(buf, 0, n);
                Console.WriteLine("[Client] RECV ← " + resp);
                return resp;
            }
            catch (Exception ex)
            {
                Disconnect();
                return $"Error|{ex.Message}";
            }
        }

        private static string Sha256(string input)
        {
            using var sha = SHA256.Create();
            return BitConverter.ToString(sha.ComputeHash(Encoding.UTF8.GetBytes(input)))
                               .Replace("-", "").ToLowerInvariant();
        }

        public string Register(string username, string password, string email,
                               string fullname, string age, string address, string phone)
            => Send($"SIGNUP|{username}|{Sha256(password)}|{email}|{fullname}|{age}|{address}|{phone}");

        public string Login(string username, string password)
            => Send($"SIGNIN|{username}|{Sha256(password)}");

        public string GetUser(string username) => Send($"GETUSER|{username}");
        public string Logout(string username) => Send($"SIGNOUT|{username}");
    }

    public static class Session
    {
        public static TCPClient Client { get; } = new TCPClient("127.0.0.1", 25565);
        public static string CurrentUser { get; set; } = "";
    }

    public class UserView
    {
        public string Username { get; set; } = "";
        public string Email { get; set; } = "";
        public string FullName { get; set; } = "";
        public string Age { get; set; } = "";
        public string Address { get; set; } = "";
        public string Phone { get; set; } = "";
    }
}
