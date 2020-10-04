using System;
using System.Collections.Generic;

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
                Console.WriteLine("Usage: dotnet run [options]\n");
                ConsoleHelper.Row[] rows = new ConsoleHelper.Row[] {
                new ConsoleHelper.Row("add", "To add a new task", false),
                new ConsoleHelper.Row("tasks", "List all tasks", false),
            };
                ConsoleHelper.PrintTable(Constants.SPACED_TABLE, "Options", rows);
            }
        }
    }
}
