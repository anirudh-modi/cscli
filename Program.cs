using System;
using System.Text.Json;
using System.IO;
using Newtonsoft.Json;

namespace cscli
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nWelcome to TODO using C#.Net\n");
            Console.ResetColor();

            if (args.Length > 0)
            {
                string command = args[0];
                string command2 = args[1];
                Console.WriteLine(command2);
                switch (command)
                {
                    case "add":
                        Console.WriteLine("Add");
                        break;
                    case "tasks":
                        Console.WriteLine("Listing");
                        break;
                    default:
                        Console.WriteLine("Invalid Command");
                        break;
                }
            }
            else
            {
                ConsoleHelper.Row rowIns = new ConsoleHelper.Row("add", "To add a new task", false);
                Console.WriteLine("Usage: dotnet run [options]\n");
                ConsoleHelper.Row[] rows = new ConsoleHelper.Row[] {
                    new ConsoleHelper.Row("add", "To add a new task", false),
                    new ConsoleHelper.Row("tasks", "List all tasks", false),
                };

                // string jsonString = JsonSerializer.Serialize(rowIns);
                // File.WriteAllText("test.json", jsonString);

                string jsonString = File.ReadAllText("test.json");
                ConsoleHelper.Row weatherForecast = JsonConvert.DeserializeObject<ConsoleHelper.Row>(jsonString);

                Console.WriteLine(weatherForecast.title);

                ConsoleHelper.PrintTable(Constants.SPACED_TABLE, "Options", rows);
            }
        }
    }
}
