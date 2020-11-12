using QuicNet;
using QuicNet.Connections;
using System;
using System.Text;

namespace QuicProtocolBasicTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server");
            QuicListener listener = new QuicListener(18000);
            listener.Start();
            while (true)
            {

                // Blocks while waiting for a connection
                QuicConnection client = listener.AcceptQuicClient();

                // Assign an action when a data is received from that client.
                client.OnDataReceived += (c) => {
                    byte[] data = c.Data;
                    Console.WriteLine("Data received: " + Encoding.UTF8.GetString(data));
                    // Echo back data to the client
                    c.Send(Encoding.UTF8.GetBytes("Echo!"));
                };
            }
        }
    }
}
