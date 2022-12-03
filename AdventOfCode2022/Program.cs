//static string Day1()
//{
//    string[] list = File.ReadAllLines(@"Files/list.txt");
//    Dictionary<int, int> dict = new();
//    int elf = 1;
//    for (int i = 0; i < list.Length; i++)
//    {
//        if (string.IsNullOrEmpty(list[i]))
//        {
//            elf++;
//            continue;
//        }
//        else if (!dict.ContainsKey(elf))
//        {
//            dict.Add(elf, 0);
//            dict[elf] = int.Parse(list[i]);
//            continue;
//        }
//        else
//            dict[elf] += int.Parse(list[i]);
//    }
//    return $"\nPart 1: {dict.Select(x => x.Value).Max()}" +
//           $"\nPart 2: {dict.OrderByDescending(x => x.Value).Take(3).Sum(x => x.Value)}";
//}
//static void Day2Part1()
//{
//    var dict = new Dictionary<char, int>() { 
//        { 'X', 1 }, { 'Y', 2 }, { 'Z', 3 }, 
//        { 'A', 1 }, { 'B', 2 }, { 'C', 3 } };

//    int score = 0;

//    string[] strategy = File.ReadAllLines(@"Files/day2.txt");

//    for (int i = 0; i < strategy.Length; i++)
//    {
//        int user = dict[strategy[i].ToCharArray()[2]];
//        int elf = dict[strategy[i].ToCharArray()[0]];

//        if (elf % 3 + 1 == user)
//            score += 6 + user;
//        else if (user % 3 + 1 == elf)
//            score += user;
//        else
//            score += 3 + user;
//    }
//    Console.WriteLine(score);
//}
//static void Day2Part2()
//{
//    string[] strategy = File.ReadAllLines(@"Files/day2.txt");

//    var dict = new Dictionary<char, int>() {
//        { 'A', 1 }, { 'B', 2 }, { 'C', 3 },
//        { 'X', 1 }, { 'Y', 2 }, { 'Z', 3 } };
//    var toWin = new Dictionary<int, int>() {
//        { 1, 2 }, { 2, 3 }, { 3, 1 } };
//    var toLose = new Dictionary<int, int>() {
//        { 1, 3 }, { 2, 1 }, { 3, 2 } };

//    int score = 0;

//    for (int i = 0; i < strategy.Length; i++)
//    {
//        int outcome = dict[strategy[i].ToCharArray()[2]];
//        int elf = dict[strategy[i].ToCharArray()[0]];
//        switch (outcome)
//        {
//            case 3: score += 6 + toWin[elf]; break;
//            case 2: score += 3 + elf; break;
//            default: score += toLose[elf]; break;
//        }
//    }
//    Console.WriteLine(score);
//}

using System.Text;
using System.Text.RegularExpressions;


//static void Day3Part1()
//{
//    string[] rucksack = File.ReadAllLines(@"Files/day3.txt");
//    int prioritiesSum = 0;
//    for (int i  = 0; i < rucksack.Length; i++)
//    {
//        var compOne = rucksack[i].Substring(0, (rucksack[i].Length / 2));
//        var compTwo = rucksack[i].Substring((rucksack[i].Length / 2), (rucksack[i].Length / 2));

//        var rg = new Regex(@$"[{compTwo}]");
//        var match = rg.Match(compOne);

//        if (match.Success)
//        {
//            if(match.Value == match.Value.ToUpper())
//            {
//                byte[] ascii = Encoding.ASCII.GetBytes(match.Value);
//                prioritiesSum += (ascii[0] - 38);
//            }
//            else
//            {
//                byte[] ascii = Encoding.ASCII.GetBytes(match.Value);
//                prioritiesSum += (ascii[0] - 96);
//            }
//        }  
//    }
//    Console.WriteLine(prioritiesSum);
//}


//static void Day3Part2()
//{
//    string[] rucksack = File.ReadAllLines(@"Files/day3.txt");
//    int keysumtotal = 0;
//    for (int i = 0; i < rucksack.Length; i+=3)
//    {
//        var elf1 = rucksack[i];
//        var elf2 = rucksack[i+1];
//        var elf3 = rucksack[i+2];
//        string commonkey = string.Empty;
//        int keysumgroup = 0;
//        foreach (char c in elf1)
//        {
//            if (Regex.Count(c.ToString(), @$"[{elf2}]") > 0 && Regex.Count(c.ToString(), @$"[{elf3}]") > 0)
//                commonkey = c.ToString();
//        }
//        if (commonkey == commonkey.ToUpper())
//        {
//            byte ascii = Encoding.ASCII.GetBytes(commonkey)[0];
//            keysumgroup += (ascii - 38);
//        }
//        else
//        {
//            byte ascii = Encoding.ASCII.GetBytes(commonkey)[0];
//            keysumgroup += (ascii - 96);
//        }
//        keysumtotal += keysumgroup;
//    }
//    Console.WriteLine(keysumtotal);
//}