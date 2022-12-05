Console.WriteLine(part1());
Console.WriteLine(part2());

static int part1()
{
    string[] input = File.ReadAllLines("input.txt");
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
    return count;
}

static int part2()
{
    string[] input = File.ReadAllLines("input.txt");
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
    return count;
}