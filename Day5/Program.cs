using System.Text;
using System.Text.RegularExpressions;

Console.WriteLine(Part1());
Console.WriteLine(Part2());
static string Part1()
{
    var sb = new StringBuilder();
    string[] input = File.ReadAllLines("input.txt");
    List<string>[] stack = new List<string>[10].Select(x => new List<string>()).ToArray();

    for (int i = 7; i >= 0; i--)
    {
        int stackCount = 1;
        for (int j = 1; j < 34; j += 4)
        {
            if (Regex.IsMatch(input[i].Substring(j, 1), @"[A-Z]"))
                stack[stackCount].Add(input[i].Substring(j, 1));
            stackCount += 1;
        }
    }
    for (int i = 10; i < input.Length; i++)
    {
        int move = int.Parse(input[i].Split(" ")[1]);
        int from = int.Parse(input[i].Split(" ")[3]);
        int to = int.Parse(input[i].Split(" ")[5]);

        for (int j = 0; j < move; j++)
        {
            stack[to].Add(stack[from].LastOrDefault());
            stack[from].RemoveAt(stack[from].Count - 1);
        }
    }
    foreach (List<string> list in stack)
        sb.Append(list.LastOrDefault());
    return sb.ToString();
}

static string Part2()
{
    var sb = new StringBuilder();
    string[] input = File.ReadAllLines("input.txt");
    List<string>[] stack = new List<string>[10].Select(x => new List<string>()).ToArray();

    for (int i = 7; i >= 0; i--)
    {
        int stackCount = 1;
        for (int j = 1; j < 34; j += 4)
        {
            if (Regex.IsMatch(input[i].Substring(j, 1), @"[A-Z]"))
                stack[stackCount].Add(input[i].Substring(j, 1));
            stackCount += 1;
        }
    }
    for (int i = 10; i < input.Length; i++)
    {
        int move = int.Parse(input[i].Split(" ")[1]);
        int from = int.Parse(input[i].Split(" ")[3]);
        int to = int.Parse(input[i].Split(" ")[5]);
        stack[to].AddRange(stack[from].TakeLast(move));
        stack[from].RemoveRange(stack[from].Count - move, move);
    }
    foreach (List<string> list in stack)
        sb.Append(list.LastOrDefault());
    return sb.ToString();
}