using System;
using static cscli.Constants;
using System.Collections.Generic;

namespace cscli
{
    static class CommandPrinterFactory
    {
        public static ICommandPrinter PrintTable(string printerType, string title, Row[] rows)
        {
            switch (printerType)
            {
                case SPACED_TABLE:
                    return new SpaceTablePrinter(title, rows);
                case BORDER_TABLE:
                    return new GridTablePrinter(title, rows);
                default:
                    return new SpaceTablePrinter(title, rows);
            }
        }

        public class Row
        {
            public string title { get; set; }
            public string description { get; set; }

            public Row(string title, string description)
            {
                this.title = title;
                this.description = description;
            }
        }

        public interface ICommandPrinter
        {
            void PrintTitle();
            void PrintRows();
        }

        private class SpaceTablePrinter : ICommandPrinter
        {
            string tableTitle { get; set; } = String.Empty;
            Row[] rows { get; set; }

            public void PrintTitle()
            {
                Console.WriteLine($"{this.tableTitle}:");
            }

            public void PrintRows()
            {
                foreach (Row row in this.rows)
                {
                    Console.WriteLine("  {0,-20}{1,-1}", row.title, row.description);
                }
            }

            public SpaceTablePrinter(string tableTitle, Row[] rows)
            {
                this.tableTitle = tableTitle;
                this.rows = rows;

                this.PrintTitle();
                this.PrintRows();
            }
        }

        private class GridTablePrinter : ICommandPrinter
        {
            string tableTitle { get; set; } = String.Empty;
            Row[] rows { get; set; }
            int maxDescription { get; set; } = -1;
            int maxCommand { get; set; } = -1;
            int emptySpace { get; set; } = 3;
            int sumOfPads { get; set; } = 1;

            private void PrintRowSeparator(int lengthOfDelimeter)
            {
                Console.WriteLine(new String(ROW_SEPARATOR, lengthOfDelimeter));
            }

            private string GetCenteredText(string textToCenter, int maxLength)
            {
                int lengthToTitle = textToCenter.Length;
                int padLeftForTitle = (maxLength - lengthToTitle) / 2 + lengthToTitle;
                return textToCenter.PadLeft(padLeftForTitle).PadRight(maxLength);
            }

            public void PrintTitle()
            {
                string CenteredTitle = String.Format("{0}{1}{0}", COLUMN_DELIMETER, this.GetCenteredText(this.tableTitle, this.sumOfPads - 2));
                this.PrintRowSeparator(this.sumOfPads);
                Console.WriteLine(CenteredTitle);
                this.PrintRowSeparator(this.sumOfPads);
            }

            public void PrintRows()
            {
                foreach (Row row in this.rows)
                {
                    string command = row.title;
                    string description = row.description;
                    Console.WriteLine("{0}   {1}   {0}   {2}   {0}",
                        COLUMN_DELIMETER,
                        this.GetCenteredText(command, this.maxCommand),
                        this.GetCenteredText(description, this.maxDescription)
                    );
                }
                this.PrintRowSeparator(this.sumOfPads);
            }

            private void setMaxContentLength()
            {
                foreach (Row row in this.rows)
                {
                    var rowDesLength = row.description.Length;
                    var rowTitleLength = row.title.Length;

                    if (rowDesLength > this.maxDescription)
                    {
                        this.maxDescription = rowDesLength;
                    }

                    if (rowTitleLength > maxCommand)
                    {
                        this.maxCommand = rowTitleLength;
                    }
                }

                if (this.maxDescription % 2 != 0)
                {
                    this.maxDescription++;
                }

                if (this.maxCommand % 2 != 0)
                {
                    this.maxCommand++;
                }
                this.sumOfPads = this.maxCommand + this.maxDescription + this.emptySpace * 4 + 3;
            }

            public GridTablePrinter(string tableTitle, Row[] rows)
            {
                this.tableTitle = tableTitle;
                this.rows = rows;

                this.setMaxContentLength();
                this.PrintTitle();
                this.PrintRows();
            }
        }
    }
}
