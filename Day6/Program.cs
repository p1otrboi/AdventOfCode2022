Console.WriteLine(Part1("input.txt"));
Console.WriteLine(Part2("input.txt"));

static int Part1(string inputpath)
{
    string input = File.ReadAllText(inputpath);
    try
    {
        var recentFourChars = new List<char>
        {
            input[0],
            input[1],
            input[2]
        };
        for (int i = 3; i < input.Length; i++)
        {
            recentFourChars.Add(input[i]);
            if (recentFourChars.Distinct().Count() == 4)
                return i + 1;
            else
                recentFourChars.RemoveAt(0);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    return 0;
}

static int Part2(string inputpath)
{
    string input = File.ReadAllText(inputpath);
    try
    {
        var recentMessage = new List<char>
        {
            input[0],
            input[1],
            input[2],
            input[3],
            input[4],
            input[5],
            input[6],
            input[7],
            input[8],
            input[9],
            input[10],
            input[11],
            input[12],
        };
        for (int i = 13; i < input.Length; i++)
        {
            recentMessage.Add(input[i]);
            if (recentMessage.Distinct().Count() == 14)
                return i + 1;
            else
                recentMessage.RemoveAt(0);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    return 0;
}