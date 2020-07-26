using QuicNet;
using QuicNet.Connections;
using QuicNet.Streams;
using System;
using System.Text;

namespace QuicProtocolBasicTestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client");
            QuicClient client = new QuicClient();
            QuicConnection connection = client.Connect("127.0.0.1", 18000);   // Connect to peer (Server)

            // Create a Bidirectional data stream
            QuicStream stream = connection.CreateStream(QuickNet.Utilities.StreamType.ClientBidirectional);

            // Send Data
            var message = Console.ReadLine();
            stream.Send(Encoding.UTF8.GetBytes(message));

            // Receive from server (Blocks)
            byte[] data = stream.Receive();
            Console.ReadKey();
        }
    }
}
