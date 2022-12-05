using System.Text.RegularExpressions;
using System.Text;

Console.WriteLine(Part1());
Console.WriteLine(Part2());

static int Part1()
{
    string[] rucksack = File.ReadAllLines("input.txt");
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
    return prioritiesSum;
}

static int Part2()
{
    string[] rucksack = File.ReadAllLines("input.txt");
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
    return keysumtotal;
}