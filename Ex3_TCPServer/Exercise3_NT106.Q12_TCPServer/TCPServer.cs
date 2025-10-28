using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace CaroServer
{
    public class TCPServer
    {
        private TcpListener? listener;

        public void Start(int port)
        {
            Database.Initialize();
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            Console.WriteLine($"[SERVER] Listening on port {port}...");

            while (true)
            {
                var client = listener.AcceptTcpClient();
                var ip = ((IPEndPoint)client.Client.RemoteEndPoint!).Address.ToString();
                Console.WriteLine($"[SERVER] Accepted: {ip}");
                new Thread(() => HandleClient(client)).Start();
            }
        }

        private void HandleClient(TcpClient client)
        {
            string ip = ((IPEndPoint)client.Client.RemoteEndPoint!).Address.ToString();
            try
            {
                using var stream = client.GetStream();
                var buffer = new byte[4096];
                int len;
                while ((len = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string request = Encoding.UTF8.GetString(buffer, 0, len);
                    Console.WriteLine($"[SERVER] RECV ← {ip}: {request}");

                    string response = ProcessRequest(request);
                    Console.WriteLine($"[SERVER] SEND → {ip}: {response}");

                    byte[] data = Encoding.UTF8.GetBytes(response);
                    stream.Write(data, 0, data.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SERVER] ERROR {ip}: {ex.Message}");
            }
            finally
            {
                try { client.Close(); } catch { }
                Console.WriteLine($"[SERVER] CLOSED: {ip}");
            }
        }

        private string ProcessRequest(string req)
        {
            try
            {
                var parts = req.Split('|');
                if (parts.Length == 0) return "Error|Empty";

                string action = parts[0].ToUpperInvariant();

                return action switch
                {
                    "SIGNUP" => HandleSignup(parts),
                    "SIGNIN" => HandleSignin(parts),
                    "GETUSER" => HandleGetUser(parts),
                    "SIGNOUT" => "Success|Signed out",
                    _ => "Error|Unknown action"
                };
            }
            catch (Exception ex)
            {
                return $"Error|{ex.Message}";
            }
        }

        private string HandleSignup(string[] p)
        {
            if (p.Length < 8) return "Error|Missing arguments";

            var user = new User
            {
                Username = p[1],
                PasswordHash = p[2],
                Email = p[3],
                FullName = p[4],
                Age = p[5],
                Address = p[6],
                Phone = p[7]
            };

            if (UserRepo.GetUser(user.Username) != null)
                return "Error|Username already exists";

            return UserRepo.Register(user)
                ? "Success|Registered successfully"
                : "Error|Register failed";
        }

        private string HandleSignin(string[] p)
        {
            if (p.Length < 3) return "Error|Missing arguments";

            string username = p[1];
            string hash = p[2];

            var user = UserRepo.GetUser(username);
            if (user == null) return "Error|User not found";
            if (!string.Equals(user.PasswordHash, hash, StringComparison.OrdinalIgnoreCase))
                return "Error|Wrong password";

            return $"Success|{user.Username}|{user.Email}|{user.FullName}|{user.Age}|{user.Address}|{user.Phone}";
        }

        private string HandleGetUser(string[] p)
        {
            if (p.Length < 2) return "Error|Missing username";
            var user = UserRepo.GetUser(p[1]);
            if (user == null) return "Error|Not found";
            return $"Success|{user.Username}|{user.Email}|{user.FullName}|{user.Age}|{user.Address}|{user.Phone}";
        }
    }
}
