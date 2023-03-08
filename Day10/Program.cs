var input = File.ReadAllLines("input.txt");

var minCycles = 0;
foreach (string s in input)
{
	if (s[0] == 'n') minCycles++;
	else minCycles += 2;
}
var signalStrengths = new List<int>();
var register = 1;
var cycle = 0;
var buffer = 0;
var addBuffer = false;

// part 2 

var crtScreen = new char[40, 6];
crtScreen[0, 0] = '#';


for (var i = 0; cycle < minCycles; i++)
{
	cycle++;
	addSignalStrength();
    drawCrtScreen();

    if (input[i] != "noop")
	{
		buffer = int.Parse(input[i].Split(' ')[1]);
		addBuffer = true;
		cycle++;
		addSignalStrength();
        drawCrtScreen();
    }

    if (addBuffer)
	{
		register += buffer;
		addBuffer = false;
	}
}
void addSignalStrength()
{
	if (cycle == 20 || (cycle + 20) % 40 == 0)
	{
		signalStrengths.Add(register * cycle);
	}
}

Console.WriteLine($"Part 1: Sum of the signalstrengths is {signalStrengths.Sum()}");

// part 2

for (var y = 0; y < 6; y++)
{
    for (var x = 0; x < 40; x++)
    {
        Console.Write(crtScreen[x, y]);
    }
    Console.WriteLine();
}

void drawCrtScreen()
{
    var x = (cycle - 1) % 40;
    var y = cycle / 40;

    if (x < 40 && y < 6)
        if (Math.Abs(register - x) <= 1)
            crtScreen[x, y] = '#';
        else
            crtScreen[x, y] = '.';
}