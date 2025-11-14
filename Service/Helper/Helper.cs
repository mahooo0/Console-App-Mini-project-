using System.Reflection;

namespace Service.Helper;

public static class Helper
{
    public static void Print(string message, ConsoleColor color = ConsoleColor.White)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void ShowObject<T>(T obj) where T : class
    {
        if (obj == null)
        {
            Print("Object not found!", ConsoleColor.Red);
            return;
        }

        var properties = typeof(T).GetProperties()
            .OrderBy(p => p.Name == "Id" ? 0 : 
                         (p.Name == "CreatedAt" || p.Name == "UpdatedAt") ? 2 : 1)
            .ThenBy(p => p.Name)
            .ToArray();
        var headers = properties.Select(p => p.Name).ToArray();
        var values = properties.Select(p => p.GetValue(obj)?.ToString() ?? "null").ToArray();

        int[] columnWidths = new int[headers.Length];
        for (int i = 0; i < headers.Length; i++)
        {
            columnWidths[i] = Math.Max(headers[i].Length, values[i].Length) + 2;
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        for (int i = 0; i < headers.Length; i++)
        {
            Console.Write(headers[i].PadRight(columnWidths[i]));
        }
        Console.WriteLine();
        Console.ResetColor();

        Console.WriteLine(new string('-', columnWidths.Sum()));

        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int i = 0; i < values.Length; i++)
        {
            Console.Write(values[i].PadRight(columnWidths[i]));
        }
        Console.WriteLine();
        Console.ResetColor();
    }

    public static void ShowObjectsInTable<T>(List<T> objects) where T : class
    {
        if (objects == null || objects.Count == 0)
        {
            Print("No data to display!", ConsoleColor.Red);
            return;
        }

        var properties = typeof(T).GetProperties()
            .OrderBy(p => p.Name == "Id" ? 0 : 
                         (p.Name == "CreatedAt" || p.Name == "UpdatedAt") ? 2 : 1)
            .ThenBy(p => p.Name)
            .ToArray();
        var headers = properties.Select(p => p.Name).ToArray();

        int[] columnWidths = new int[headers.Length];
        for (int i = 0; i < headers.Length; i++)
        {
            columnWidths[i] = headers[i].Length;
            foreach (var obj in objects)
            {
                var value = properties[i].GetValue(obj)?.ToString() ?? "null";
                columnWidths[i] = Math.Max(columnWidths[i], value.Length);
            }
            columnWidths[i] += 2; 
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        for (int i = 0; i < headers.Length; i++)
        {
            Console.Write(headers[i].PadRight(columnWidths[i]));
        }
        Console.WriteLine();
        Console.ResetColor();

        Console.WriteLine(new string('-', columnWidths.Sum()));

        foreach (var obj in objects)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < properties.Length; i++)
            {
                var value = properties[i].GetValue(obj)?.ToString() ?? "null";
                Console.Write(value.PadRight(columnWidths[i]));
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        Console.WriteLine(new string('-', columnWidths.Sum()));
        Print($"\nTotal records: {objects.Count}", ConsoleColor.Green);
    }
    public static int GetIntInput()
    {
        int input;
        while (!int.TryParse(Console.ReadLine(), out input))
        {
            Print("Invalid input. Please enter a valid integer.", ConsoleColor.Red);
        }
        return input;
       
    }

    public static string GetStringInput(string prompt = "")
    {
        if (!string.IsNullOrEmpty(prompt))
        {
            Console.WriteLine(prompt);
        }

        string? input;
        while (true)
        {
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            Print("Input cannot be empty. Please enter a valid value.", ConsoleColor.Red);
        }
    }
}