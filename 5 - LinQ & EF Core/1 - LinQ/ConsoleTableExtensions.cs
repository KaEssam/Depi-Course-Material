
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    namespace LINQ_DATA
    {
        public static class ConsoleTableExtensions
        {
            /// <summary>
            /// Displays a collection of objects in a formatted table in the console
            /// </summary>
            /// <typeparam name="T">The type of objects in the collection</typeparam>
            /// <param name="items">The collection to display</param>
            /// <param name="title">Optional title for the table</param>
            public static void ToConsoleTable<T>(this IEnumerable<T> items, string title = null)
            {
                if (!items.Any())
                {
                    Console.WriteLine("No data to display.");
                    return;
                }

                // Get properties of the first item
                var properties = typeof(T).GetProperties();
                var headers = properties.Select(p => p.Name).ToArray();
                var values = items.Select(item =>
                    properties.Select(p => p.GetValue(item)?.ToString() ?? "null").ToArray()
                ).ToArray();

                // Calculate column widths
                var columnWidths = new int[headers.Length];
                for (int i = 0; i < headers.Length; i++)
                {
                    columnWidths[i] = Math.Max(headers[i].Length,
                        values.Max(row => row[i]?.Length ?? 0));
                }

                // Print title
                if (!string.IsNullOrEmpty(title))
                {
                    Console.WriteLine($"\n{title}");
                    Console.WriteLine(new string('=', title.Length));
                }

                // Print header
                PrintRow(headers, columnWidths);
                Console.WriteLine(new string('-', columnWidths.Sum() + headers.Length + 1));

                // Print data rows
                foreach (var row in values)
                {
                    PrintRow(row, columnWidths);
                }
                Console.WriteLine();
            }

            /// <summary>
            /// Displays a collection of objects in a formatted table with custom headers
            /// </summary>
            /// <typeparam name="T">The type of objects in the collection</typeparam>
            /// <param name="items">The collection to display</param>
            /// <param name="headers">Custom headers for the columns</param>
            /// <param name="title">Optional title for the table</param>
            public static void ToConsoleTable<T>(this IEnumerable<T> items, string[] headers, string title = null)
            {
                if (!items.Any())
                {
                    Console.WriteLine("No data to display.");
                    return;
                }

                var properties = typeof(T).GetProperties();
                var values = items.Select(item =>
                    properties.Select(p => p.GetValue(item)?.ToString() ?? "null").ToArray()
                ).ToArray();

                // Calculate column widths
                var columnWidths = new int[headers.Length];
                for (int i = 0; i < headers.Length; i++)
                {
                    columnWidths[i] = Math.Max(headers[i].Length,
                        values.Max(row => row[i]?.Length ?? 0));
                }

                // Print title
                if (!string.IsNullOrEmpty(title))
                {
                    Console.WriteLine($"\n{title}");
                    Console.WriteLine(new string('=', title.Length));
                }

                // Print header
                PrintRow(headers, columnWidths);
                Console.WriteLine(new string('-', columnWidths.Sum() + headers.Length + 1));

                // Print data rows
                foreach (var row in values)
                {
                    PrintRow(row, columnWidths);
                }
                Console.WriteLine();
            }

            /// <summary>
            /// Displays a collection with custom column formatting
            /// </summary>
            /// <typeparam name="T">The type of objects in the collection</typeparam>
            /// <param name="items">The collection to display</param>
            /// <param name="columnConfigs">Configuration for each column</param>
            /// <param name="title">Optional title for the table</param>
            public static void ToConsoleTable<T>(this IEnumerable<T> items,
                Dictionary<string, string> columnConfigs, string title = null)
            {
                if (!items.Any())
                {
                    Console.WriteLine("No data to display.");
                    return;
                }

                var properties = typeof(T).GetProperties();
                var headers = columnConfigs.Keys.ToArray();
                var propertyNames = columnConfigs.Values.ToArray();

                var values = items.Select(item =>
                    propertyNames.Select(propName =>
                    {
                        var prop = properties.FirstOrDefault(p => p.Name == propName);
                        return prop?.GetValue(item)?.ToString() ?? "null";
                    }).ToArray()
                ).ToArray();

                // Calculate column widths
                var columnWidths = new int[headers.Length];
                for (int i = 0; i < headers.Length; i++)
                {
                    columnWidths[i] = Math.Max(headers[i].Length,
                        values.Max(row => row[i]?.Length ?? 0));
                }

                // Print title
                if (!string.IsNullOrEmpty(title))
                {
                    Console.WriteLine($"\n{title}");
                    Console.WriteLine(new string('=', title.Length));
                }

                // Print header
                PrintRow(headers, columnWidths);
                Console.WriteLine(new string('-', columnWidths.Sum() + headers.Length + 1));

                // Print data rows
                foreach (var row in values)
                {
                    PrintRow(row, columnWidths);
                }
                Console.WriteLine();
            }

            private static void PrintRow(string[] values, int[] columnWidths)
            {
                Console.Write("|");
                for (int i = 0; i < values.Length; i++)
                {
                    Console.Write($" {values[i]?.PadRight(columnWidths[i])} |");
                }
                Console.WriteLine();
            }

            /// <summary>
            /// Displays a simple list of values in a table format
            /// </summary>
            /// <typeparam name="T">The type of values</typeparam>
            /// <param name="items">The collection to display</param>
            /// <param name="columnName">Name for the single column</param>
            /// <param name="title">Optional title for the table</param>
            public static void ToConsoleTable<T>(this IEnumerable<T> items, string columnName, string title = null)
            {
                var formattedItems = items.Select(item => new { Value = item?.ToString() ?? "null" });
                formattedItems.ToConsoleTable(new[] { columnName }, title);
            }
        }
    }
