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

            if (args.Length > 0 && args[0] == "-t")
            {
                ConsoleHelper.PrintTable(Constants.BORDER_TABLE, "Usage", new[] {
                new {command = "add", description = "This is a test"},
                new {command = "tasklist", description = "This is a test I wish"},
                new {command = "use", description = "This will list all the users prsent in a row"}
             });
            }
            else
            {
                ConsoleHelper.PrintTable(Constants.SPACED_TABLE, "Usage", new[] {
                new {command = "add", description = "This is a test"},
                new {command = "tasklist", description = "This is a test I wish"},
                new {command = "use", description = "This will list all the users prsent in a row"}
             });
            }

        }
    }
}
