using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    class ClientProgram
    {
        static void Main(string[] args)
        {
            //  Console.WriteLine("Hello World!");
            // Client connection
            var client = new TcpClient();
            client.Connect(IPAddress.Loopback, 5000);

            var stream = client.GetStream();

            var data = Encoding.UTF8.GetBytes("Hello");

            stream.Write(data);

            data = new byte[client.ReceiveBufferSize];

            var cnt = stream.Read(data);

            var msg = Encoding.UTF8.GetString(data, 0, cnt);

            Console.WriteLine("MEssage from server");
        }
    }
}
