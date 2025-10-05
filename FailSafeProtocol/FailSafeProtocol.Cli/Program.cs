using System;
using System.Collections.Generic;
using FailSafeProtocol.Domain;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var service = new DefaultAsteroidService();
        Console.WriteLine("FailSafeProtocol CLI");
        Console.WriteLine("Commands:");
        Console.WriteLine("get <round>");
        Console.WriteLine("act <a> <b> <c> <d>");
        Console.WriteLine(":q");

        while (true)
        {
            Console.Write("> ");
            var line = Console.ReadLine();
            if (line is null) continue;
            var trimmed = line.Trim();
            if (trimmed == ":q") break;
            if (string.IsNullOrWhiteSpace(trimmed)) continue;

            var mode = FirstToken(trimmed);
            if (string.Equals(mode, "get", StringComparison.OrdinalIgnoreCase))
            {
                var roundToken = NextToken(trimmed);
                if (!int.TryParse(roundToken, out var round) || round <= 0)
                {
                    Console.WriteLine("round must be a positive integer");
                    continue;
                }
                var dtos = service.GetAsteroid(round);
                PrintQuadrants(dtos);
                continue;
            }

            if (string.Equals(mode, "act", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(mode, "mod", StringComparison.OrdinalIgnoreCase))
            {
                var actions = SplitExactlyN(RemoveFirstToken(trimmed), ' ', 4);
                var dtos = service.CalculateStates([0,0,0,0]);
                PrintQuadrants(dtos);
                continue;
            }

            Console.WriteLine("unknown command");
        }
    }

    static string FirstToken(string input)
    {
        var idx = input.IndexOf(' ');
        return idx < 0 ? input : input.Substring(0, idx);
    }

    static string NextToken(string input)
    {
        var idx = input.IndexOf(' ');
        if (idx < 0) return "";
        var rest = input.Substring(idx + 1).TrimStart();
        var nextIdx = rest.IndexOf(' ');
        return nextIdx < 0 ? rest : rest.Substring(0, nextIdx);
    }

    static string RemoveFirstToken(string input)
    {
        var idx = input.IndexOf(' ');
        return idx < 0 ? "" : input.Substring(idx + 1).TrimStart();
    }

    static string?[] SplitExactlyN(string input, char separator, int expected)
    {
        var tokens = new List<string?>();
        var current = new List<char>();
        foreach (var ch in input)
        {
            if (ch == separator && tokens.Count < expected - 1)
            {
                tokens.Add(current.Count == 0 ? null : new string(current.ToArray()));
                current.Clear();
            }
            else
            {
                current.Add(ch);
            }
        }
        tokens.Add(current.Count == 0 ? null : new string(current.ToArray()));
        while (tokens.Count < expected) tokens.Add(null);
        if (tokens.Count > expected) tokens = tokens.GetRange(0, expected);
        for (int i = 0; i < tokens.Count; i++)
        {
            if (tokens[i] is not null && string.IsNullOrWhiteSpace(tokens[i])) tokens[i] = null;
        }
        return tokens.ToArray();
    }

    static void PrintQuadrants(AsteroidDto?[] dtos)
    {
        var labels = new[] { "A", "B", "C", "D" };
        for (int i = 0; i < dtos.Length; i++)
        {
            Console.Write($"{labels[i]}: ");
            PrintDto(dtos[i]);
        }
    }

    static void PrintDto(AsteroidDto? dto)
    {
        if (dto is null)
        {
            Console.WriteLine("null");
            return;
        }

        Console.Write("{ ");
        WritePair("Velocity", dto.Velocity); Console.Write(", ");
        WritePair("Size", dto.Size); Console.Write(", ");
        WritePair("IsFastRotation", dto.IsFastRotation); Console.Write(", ");
        WritePair("IsIrregular", dto.IsIrregular); Console.Write(", ");
        WritePair("Composition", dto.Composition); Console.Write(", ");
        WritePair("IsMultiplicity", dto.IsMultiplicity); Console.Write(", ");
        WritePair("Eccentricity", dto.Eccentricity); Console.Write(", ");
        WritePair("Volatility", dto.Volatility); Console.Write(", ");
        WritePair("Integrity", dto.Integrity); Console.Write(", ");
        WritePair("Compact", dto.Compact); Console.Write(", ");
        WritePair("Distance", dto.Distance);
        Console.WriteLine(" }");
    }

    static void WritePair(string key, object? value)
    {
        Console.Write($"{key}=");
        if (value is null)
        {
            Console.Write("null");
            return;
        }
        if (value is bool b)
        {
            Console.Write(b ? "true" : "false");
            return;
        }
        Console.Write(value.ToString());
    }
}
