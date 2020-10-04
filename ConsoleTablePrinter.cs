using System;
using System.Collections.Generic;

namespace cscli
{
    static class ConsoleHelper
    {
        public static void PrintTable(string printerType, string title, object[] rows)
        {
            switch (printerType)
            {

                case Constants.SPACED_TABLE:
                    PrintSpacedTable(title, rows);
                    break;

                case Constants.BORDER_TABLE:
                    PrintBorderTable(title, rows);
                    break;

                default:
                    PrintSpacedTable(title, rows);
                    break;
            }
        }

        private static void PrintSpacedTable(string title, object[] rows)
        {
            Console.WriteLine($"{title}:");
            foreach (dynamic row in rows)
            {
                Console.WriteLine("  {0,-20}{1,-1}", row.command, row.description);
            }
        }

        private static void PrintBorderTable(string title, object[] rows)
        {
            int maxDescription = -1;
            int maxCommand = -1;
            int EmptySpace = 3;

            foreach (dynamic row in rows)
            {
                if (row.description.Length > maxDescription)
                {
                    maxDescription = row.description.Length;
                }

                if (row.command.Length > maxCommand)
                {
                    maxCommand = row.command.Length;
                }
            }

            if (maxDescription % 2 != 0)
            {
                maxDescription++;
            }

            if (maxCommand % 2 != 0)
            {
                maxCommand++;
            }

            int sumOfPads = maxCommand + maxDescription + EmptySpace * 4 + 3;
            string CenteredTitle = String.Format("{0}{1}{0}", Constants.COLUMN_DELIMETER, getCenteredText(title, sumOfPads - 2));

            PrintRowSeparator(sumOfPads);
            Console.WriteLine(CenteredTitle);
            PrintRowSeparator(sumOfPads);

            foreach (dynamic row in rows)
            {
                string command = row.command;
                string description = row.description;
                Console.WriteLine("|   {0}   |   {1}   |", getCenteredText(command, maxCommand), getCenteredText(description, maxDescription));
            }

            PrintRowSeparator(sumOfPads);
        }

        private static string getCenteredText(string textToCenter, int maxLength)
        {
            int lengthToTitle = textToCenter.Length;
            int padLeftForTitle = (maxLength - lengthToTitle) / 2 + lengthToTitle;
            return textToCenter.PadLeft(padLeftForTitle).PadRight(maxLength);
        }

        private static void PrintRowSeparator(int lengthOfDelimeter)
        {
            Console.WriteLine(new String(Constants.ROW_SEPARATOR, lengthOfDelimeter));
        }
    }
}