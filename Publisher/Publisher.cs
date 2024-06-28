using NATS.Client;
using System.Text;

namespace NATS_Example
{
    public class Publisher
    {
        public static void Publish(string[] args)
        {
            Options opts = ConnectionFactory.GetDefaultOptions();
            opts.Url = "nats://localhost:4222";
            string subject = "example";
            while (true)
            {
                string msg = Console.ReadLine();
                if (msg == null) {
                    Console.WriteLine($"{subject}: No message received");
                    Thread.Sleep(1000);
                }
                else
                {
                    using (IConnection c = new ConnectionFactory().CreateConnection(opts))
                    {
                        c.Publish(subject, Encoding.UTF8.GetBytes(msg));
                        
                    }
                }
            }
            
        }
    }
}
