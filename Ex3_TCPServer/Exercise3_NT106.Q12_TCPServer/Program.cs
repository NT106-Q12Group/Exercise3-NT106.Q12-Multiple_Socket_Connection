using System;

namespace CaroServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Caro Game TCP Server";
            Database.Initialize();
            Console.WriteLine("[SERVER] Database initialized.");

            var server = new TCPServer();
            server.Start(25565);
        }
    }
}
