using System.Text.RegularExpressions;

Console.WriteLine(Part1());
Console.WriteLine(Part2());



static int Part1()
{
    var dict = new Dictionary<char, int>() {
        { 'X', 1 }, { 'Y', 2 }, { 'Z', 3 },
        { 'A', 1 }, { 'B', 2 }, { 'C', 3 } };

    int score = 0;

    string[] strategy = File.ReadAllLines("input.txt");

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

static int Part2()
{
    string[] strategy = File.ReadAllLines("input.txt");

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
    return score;
}