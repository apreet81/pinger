using System;
using System.Net.NetworkInformation;

namespace pinger
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerStatusBy();
        }

        public static void ServerStatusBy()
        {
            Console.Write("Enter server url:");
            var url = Console.ReadLine();
            Console.Clear();
            Ping pingSender = new Ping();
            PingReply reply = pingSender.Send(url);
            Console.WriteLine("Status of Host: {0}", url);
            if (reply.Status == IPStatus.Success)
            {
                Console.WriteLine("IP Address: {0}", reply.Address.ToString());
                Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
                Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
                Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
                Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);
            }
            else
                Console.WriteLine(reply.Status);

            Console.Write("Do you want to test another website (y/n)?");
            var choice = Console.ReadLine();
            if (choice.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                ServerStatusBy();
            }
        }
    }
}
