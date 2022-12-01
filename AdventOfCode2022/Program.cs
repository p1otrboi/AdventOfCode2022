Console.WriteLine($"Day 1{Day1()}");



static string Day1()
{
    string[] list = File.ReadAllLines(@"C:\Users\joaki\source\repos\AdventOfCode2022\AdventOfCode2022\Files\list.txt");
    Dictionary<int, int> dict = new();
    int key = 1;
    foreach (string line in list)
    {
        if (string.IsNullOrEmpty(line))
        {
            key++;
            continue;
        }
        else if (!dict.ContainsKey(key))
        {
            dict.Add(key, 0);
            dict[key] = int.Parse(line);
            continue;
        }
        else
            dict[key] += int.Parse(line);
    }
    return $"\nPart 1: {dict.Select(x => x.Value).Max()}" +
           $"\nPart 2: {dict.OrderByDescending(x => x.Value).Take(3).Sum(x => x.Value)}";
}