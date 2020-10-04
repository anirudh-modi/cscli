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

            ConsoleHelper.Row[] rows = new ConsoleHelper.Row[] {
                new ConsoleHelper.Row("add", "this is a test", false),
                new ConsoleHelper.Row("tasks", "Listing all the tasks is a test", false),
            };
            if (args.Length > 0 && args[0] == "-t")
            {
                ConsoleHelper.PrintTable(Constants.BORDER_TABLE, "Usage", rows);
            }
            else
            {
                ConsoleHelper.PrintTable(Constants.SPACED_TABLE, "Usage", rows);
            }
        }
    }
}
