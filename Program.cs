using System;
using System.Text.Json;
using System.IO;
using Newtonsoft.Json;
using static cscli.CommandPrinterFactory;
using static cscli.Constants;

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
                Console.WriteLine("Usage: dotnet run [command]\n");
                Row[] rows = new Row[] {
                    new Row("add", "To add a new task"),
                    new Row("tasks", "List all tasks"),
                };
                CommandPrinter printer = PrintTable(SPACED_TABLE, "command", rows);


                // string jsonString = JsonSerializer.Serialize(rowIns);
                // File.WriteAllText("test.json", jsonString);

                // string jsonString = File.ReadAllText("test.json");
                // Row weatherForecast = JsonConvert.DeserializeObject<Row>(jsonString);

                // Console.WriteLine(weatherForecast.title);

                // PrintTable(Constants.SPACED_TABLE, "Options", rows);
            }
        }
    }
}
