using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ChessServer
{
    class Program
    {
        static Socket socketObj;
        static string Recieve(Socket handler)
        {
            if (handler.Available != 0)
            {
                byte[] data = new byte[256];
                int bytes = 0;
                List<byte> Result = new List<byte>(256);
                do
                {
                    bytes = handler.Receive(data, data.Length, SocketFlags.None);
                    for (int i = 0; i < bytes; i++)
                    {
                        Result.Add(data[i]);
                    }
                } while (handler.Available > 0);

                return Encoding.UTF8.GetString(Result.ToArray());
            }
            return "";
        }
        static void CallBack(Socket handler, string str)
        {
            handler.Send(Encoding.UTF8.GetBytes(str));
        }

        static void Main(string[] args)
        {
            socketObj =
                new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint iPEnd = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5555);

            socketObj.Bind(iPEnd);
            socketObj.Listen(10);

            bool stop = false;

            while (!stop)
            {
                var handler = socketObj.Accept();

                do
                {
                    Thread.Sleep(60);
                } while (handler.Available == 0);

                string msg = Recieve(handler);
                Console.WriteLine(msg);
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
            socketObj.Shutdown(SocketShutdown.Both);
            socketObj.Close();
        }
    }
}
