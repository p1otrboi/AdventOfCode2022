Console.WriteLine($"Day 1{Day1()}");
Day2();



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

static void Day2()
{
    var dict = new Dictionary<char, int>() { 
        { 'X', 1 }, { 'Y', 2 }, { 'Z', 3 }, 
        { 'A', 1 }, { 'B', 2 }, { 'C', 3 } };

    int[] rps = new int[] { 0, 1, 2, };

    int score = 0;

    string[] strategy = File.ReadAllLines(@"Files/day2.txt");

    for (int i = 0; i <= strategy.Length; i++)
    {
        int decision = ((dict[strategy[i].ToArray()[2]])-(dict[strategy[i].ToArray()[2]])+3)% 3;
        Console.WriteLine(decision);
    }




}