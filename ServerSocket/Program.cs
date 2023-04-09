using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace ServerSocket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //build the "connector"
            /*IPHostEntry ipe = Dns.GetHostEntry("localhost");
            IPAddress[] ips = ipe.AddressList;

            foreach(IPAddress ip in ips)
            {
                Console.WriteLine(ip.ToString());
            }*/

            // Console.WriteLine(IPAddress.Any);

            IPEndPoint ipe = new IPEndPoint(IPAddress.Any, 1234);

            Socket server_socket = new Socket(IPAddress.Any.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            server_socket.Bind(ipe);
            server_socket.Listen(5);

            //use this to send and receive messages
            Socket client_socket = server_socket.Accept();
            Console.WriteLine("[+] Connection from: {0}", client_socket.LocalEndPoint);

            Console.WriteLine("Enter message to send: ");
            string msg = Console.ReadLine();

            client_socket.Send(Encoding.ASCII.GetBytes(msg));

            client_socket.Close();
            server_socket.Close();

            Console.ReadKey();
        }
    }
}
