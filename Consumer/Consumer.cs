using NATS.Client;
using NATS.Client.JetStream;
using System.Text;

namespace NATS_Example
{
    public class Consumer
    {
        public static void Consume(string[] args)
        {
            Console.WriteLine($"Hello, I am Consumer");
            Options opts = ConnectionFactory.GetDefaultOptions();
            opts.Url = "nats://localhost:4222";

            using (IConnection c = new ConnectionFactory().CreateConnection(opts))
            {
                string subject = "example";
                EventHandler<MsgHandlerEventArgs> msgHandler = (sender, args) =>
                {
                    string receivedMessage = Encoding.UTF8.GetString(args.Message.Data);
                    Console.WriteLine($"{subject}: {receivedMessage}");
                };

                c.SubscribeAsync(subject, msgHandler);
                Console.WriteLine($"Subscribed to subject: {subject}");

                // Keep the application running to listen for messages
                Console.ReadLine();
            }
        }
    }
}
