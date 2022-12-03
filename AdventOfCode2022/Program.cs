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
static void Day2Part1()
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
    Console.WriteLine(score);
}
static void Day2Part2()
{
    string[] strategy = File.ReadAllLines(@"C:\Users\joaki\Desktop\day2.txt");

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