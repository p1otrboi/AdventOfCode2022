Console.WriteLine(Day1("input.txt"));

static string Day1(string input)
{
    string[] list = File.ReadAllLines(input);
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
    return $"Part 1: {dict.Select(x => x.Value).Max()}" +
           $"\nPart 2: {dict.OrderByDescending(x => x.Value).Take(3).Sum(x => x.Value)}";
}

