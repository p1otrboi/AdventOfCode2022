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


for (var i = 0; cycle < minCycles; i++)
{
	cycle++;
	addSignalStrength();

	if (input[i] != "noop")
	{
		buffer = int.Parse(input[i].Split(' ')[1]);
		addBuffer = true;
		cycle++;
		addSignalStrength();
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