using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace Server
{
    class Program
    {
        static string host = "10.0.0.8";
        static int port = 80;
        static void Main(string[] args)
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);
            Socket socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                Console.WriteLine("Start Server");
                socket.Bind(localEndPoint);
                Console.WriteLine("Listening...");
                socket.Listen(1);
                socket.BeginAccept(new AsyncCallback(AcceptCallback), socket);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
        public static void AcceptCallback(IAsyncResult ar)
        {
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);
            StateObject state = new StateObject();
            state.workSocket = handler;
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReadCallBack), state);
        }
        public static void ReadCallBack(IAsyncResult result)
        {
            Console.WriteLine("Read Call Back");
            String content = String.Empty;
            StateObject state = (StateObject)result.AsyncState;
            Socket handler = state.workSocket;
            // Read data from the client socket.   
            int bytesRead = handler.EndReceive(result);
            if (bytesRead > 0)
            {
                state.sb.Append(Encoding.ASCII.GetString(
                    state.buffer, 0, bytesRead));
                content = state.sb.ToString();
                if (content.IndexOf("<EOF>") > -1)
                {
                    Console.WriteLine("Read {0} bytes from socket. \n Data : {1}",
                        content.Length, content);
                }
                else
                {
                    Console.WriteLine("Wating foe data");
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallBack), state);
                }
            }
        }
        public class StateObject
        {
            // Client  socket.  
            public Socket workSocket = null;
            // Size of receive buffer.  
            public const int BufferSize = 1024;
            // Receive buffer.  
            public byte[] buffer = new byte[BufferSize];
            // Received data string.  
            public StringBuilder sb = new StringBuilder();
        }
    }
}
