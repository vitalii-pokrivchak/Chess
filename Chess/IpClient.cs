using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Chess
{
    public class IpClient
    {
        static ManualResetEvent connectDone = new ManualResetEvent(false);
        static ManualResetEvent sendDone = new ManualResetEvent(false);
        public void SendMessage(string IP,int port,string msg)
        {
            var ip = new IPEndPoint(IPAddress.Parse(IP),port);

                var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.BeginConnect(ip, new AsyncCallback(ConnectCallback), socket);
                connectDone.WaitOne();
                var byteData = Encoding.UTF8.GetBytes(msg);
                Thread.Sleep(50);
                socket.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallBack), socket);
                sendDone.WaitOne();
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();

        }
        private static void SendCallBack(IAsyncResult ar)
        {


        Socket client = (Socket)ar.AsyncState;
        int bytesSent = client.EndSend(ar);
        sendDone.Set();

        }

        private static void ConnectCallback(IAsyncResult ar)
        {
        Socket client = (Socket)ar.AsyncState;
        client.EndConnect(ar);
        connectDone.Set();
        }
}
}
