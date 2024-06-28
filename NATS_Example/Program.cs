using System.Diagnostics;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Write("Enter the number of consumers: ");
            if (int.TryParse(Console.ReadLine(), out int numberOfConsumers))
            {
                for (int i = 0; i < numberOfConsumers; i++)
                {
                    string consumerName = $"Consumer_{i + 1}";
                    StartConsumer(consumerName);
                }
            }
            else
            {
                Console.WriteLine("Invalid number.");
            }
        }
    }

    static void StartConsumer(string consumerName)
    {
        Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = "dotnet",
            Arguments = $"run --project ../../../../Consumer/Consumer.csproj {consumerName}", // Adjust the path as needed
            CreateNoWindow = false,
            UseShellExecute = true
        };

        Process process = new Process
        {
            StartInfo = startInfo
        };

        process.Start();
    }
}