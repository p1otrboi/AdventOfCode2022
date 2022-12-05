using System.Text;
using System.Text.RegularExpressions;
Day1();
Day2Part1();
Day2Part2();
Day3Part1();
Day3Part2();
Day4part1();
Day4part2();
Day5Part1();
Day5Part2();

static string Day1()
{
    string[] list = File.ReadAllLines(@"Files/list.txt");
    Dictionary<int, int> dict = new();
    int elf = 1;
    for (int i = 0; i < list.Length; i++)
    {
        if (string.IsNullOrEmpty(list[i]))
        {
            elf++;
            continue;
        }
        else if (!dict.ContainsKey(elf))
        {
            dict.Add(elf, 0);
            dict[elf] = int.Parse(list[i]);
            continue;
        }
        else
            dict[elf] += int.Parse(list[i]);
    }
    return $"\nPart 1: {dict.Select(x => x.Value).Max()}" +
           $"\nPart 2: {dict.OrderByDescending(x => x.Value).Take(3).Sum(x => x.Value)}";
}
static int Day2Part1()
{
    var dict = new Dictionary<char, int>() {
        { 'X', 1 }, { 'Y', 2 }, { 'Z', 3 },
        { 'A', 1 }, { 'B', 2 }, { 'C', 3 } };

    int score = 0;

    string[] strategy = File.ReadAllLines(@"Files/day2.txt");

    for (int i = 0; i < strategy.Length; i++)
    {
        int user = dict[strategy[i].ToCharArray()[2]];
        int elf = dict[strategy[i].ToCharArray()[0]];

        if (elf % 3 + 1 == user)
            score += 6 + user;
        else if (user % 3 + 1 == elf)
            score += user;
        else
            score += 3 + user;
    }
    return score;
}
static void Day2Part2()
{
    string[] strategy = File.ReadAllLines(@"Files/day2.txt");

    var dict = new Dictionary<char, int>() {
        { 'A', 1 }, { 'B', 2 }, { 'C', 3 },
        { 'X', 1 }, { 'Y', 2 }, { 'Z', 3 } };
    var toWin = new Dictionary<int, int>() {
        { 1, 2 }, { 2, 3 }, { 3, 1 } };
    var toLose = new Dictionary<int, int>() {
        { 1, 3 }, { 2, 1 }, { 3, 2 } };

    int score = 0;

    for (int i = 0; i < strategy.Length; i++)
    {
        int outcome = dict[strategy[i].ToCharArray()[2]];
        int elf = dict[strategy[i].ToCharArray()[0]];
        switch (outcome)
        {
            case 3: score += 6 + toWin[elf]; break;
            case 2: score += 3 + elf; break;
            default: score += toLose[elf]; break;
        }
    }
    Console.WriteLine(score);
}
static void Day3Part1()
{
    string[] rucksack = File.ReadAllLines(@"Files/day3.txt");
    int prioritiesSum = 0;
    for (int i = 0; i < rucksack.Length; i++)
    {
        var compOne = rucksack[i].Substring(0, (rucksack[i].Length / 2));
        var compTwo = rucksack[i].Substring((rucksack[i].Length / 2), (rucksack[i].Length / 2));

        var rg = new Regex(@$"[{compTwo}]");
        var match = rg.Match(compOne);

        if (match.Success)
        {
            if (match.Value == match.Value.ToUpper())
            {
                byte[] ascii = Encoding.ASCII.GetBytes(match.Value);
                prioritiesSum += (ascii[0] - 38);
            }
            else
            {
                byte[] ascii = Encoding.ASCII.GetBytes(match.Value);
                prioritiesSum += (ascii[0] - 96);
            }
        }
    }
    Console.WriteLine(prioritiesSum);
}
static void Day3Part2()
{
    string[] rucksack = File.ReadAllLines(@"Files/day3.txt");
    int keysumtotal = 0;
    for (int i = 0; i < rucksack.Length; i += 3)
    {
        var elf1 = rucksack[i];
        var elf2 = rucksack[i + 1];
        var elf3 = rucksack[i + 2];
        string commonkey = string.Empty;
        int keysumgroup = 0;
        foreach (char c in elf1)
        {
            if (Regex.Count(c.ToString(), @$"[{elf2}]") > 0 && Regex.Count(c.ToString(), @$"[{elf3}]") > 0)
                commonkey = c.ToString();
        }
        if (commonkey == commonkey.ToUpper())
        {
            byte ascii = Encoding.ASCII.GetBytes(commonkey)[0];
            keysumgroup += (ascii - 38);
        }
        else
        {
            byte ascii = Encoding.ASCII.GetBytes(commonkey)[0];
            keysumgroup += (ascii - 96);
        }
        keysumtotal += keysumgroup;
    }
    Console.WriteLine(keysumtotal);
}
static void Day4part1()
{
    string[] input = File.ReadAllLines(@"Files/day4.txt");
    int count = 0;
    foreach (string line in input)
    {
        int elf1low = int.Parse(line.Split('-', ',')[0]);
        int elf1hi = int.Parse(line.Split('-', ',')[1]);
        int elf2low = int.Parse(line.Split('-', ',')[2]);
        int elf2hi = int.Parse(line.Split('-', ',')[3]);

        if ((elf1low <= elf2low && elf1hi >= elf2hi) || (elf2low <= elf1low && elf2hi >= elf1hi))
            count++;
    }
    Console.WriteLine(count);
}
static void Day4part2()
{
    string[] input = File.ReadAllLines(@"Files/day4.txt");
    int count = 0;
    foreach (string line in input)
    {
        int elf1low = int.Parse(line.Split('-', ',')[0]);
        int elf1hi = int.Parse(line.Split('-', ',')[1]);
        var elfone = Enumerable.Range(elf1low, (elf1hi - elf1low) + 1).ToArray();
        int elf2low = int.Parse(line.Split('-', ',')[2]);
        int elf2hi = int.Parse(line.Split('-', ',')[3]);
        var elftwo = Enumerable.Range(elf2low, (elf2hi - elf2low) + 1).ToArray();

        if (elfone.Intersect(elftwo).Any())
            count++;
    }
    Console.WriteLine(count);
}
static void Day5Part1()
{
    string[] input = File.ReadAllLines(@"Files/day5.txt");
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
    {
        Console.Write(list.LastOrDefault());
    }
}
static void Day5Part2()
{
    string[] input = File.ReadAllLines(@"Files/day5.txt");
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
    {
        Console.Write(list.LastOrDefault());
    }
}