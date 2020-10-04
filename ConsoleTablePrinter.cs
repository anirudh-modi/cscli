using System;
using System.Collections.Generic;

namespace cscli
{
    static class ConsoleHelper
    {
        public class Row
        {
            public string title { get; set; }
            public string description { get; set; }

            public bool isHeader { get; set; }

            public Row(string title, string description, bool isHeader)
            {
                this.title = title;
                this.description = description;
                this.isHeader = isHeader;
            }
        }

        public static void PrintTable(string printerType, string title, Row[] rows)
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

        private static void PrintSpacedTable(string title, Row[] rows)
        {
            Console.WriteLine($"{title}:");
            foreach (Row row in rows)
            {
                Console.WriteLine("  {0,-20}{1,-1}", row.title, row.description);
            }
        }

        private static void PrintBorderTable(string title, Row[] rows)
        {
            int maxDescription = -1;
            int maxCommand = -1;
            int EmptySpace = 3;

            foreach (Row row in rows)
            {
                if (row.description.Length > maxDescription)
                {
                    maxDescription = row.description.Length;
                }

                if (row.title.Length > maxCommand)
                {
                    maxCommand = row.title.Length;
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

            foreach (Row row in rows)
            {
                string command = row.title;
                string description = row.description;
                Console.WriteLine("{0}   {1}   {0}   {2}   {0}", Constants.COLUMN_DELIMETER, getCenteredText(command, maxCommand), getCenteredText(description, maxDescription));
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