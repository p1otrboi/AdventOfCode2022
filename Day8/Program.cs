//---Day 8: Treetop Tree House ---
//The expedition comes across a peculiar patch of tall trees all planted carefully in a grid.
//The Elves explain that a previous expedition planted these trees as a reforestation effort.
//Now, they're curious if this would be a good location for a tree house.

//First, determine whether there is enough tree cover here to keep a tree house hidden. To do
//this, you need to count the number of trees that are visible from outside the grid when looking directly along a row or column.

//The Elves have already launched a quadcopter to generate a map with the height of each tree (your puzzle input). For example:

//30373
//25512
//65332
//33549
//35390
//Each tree is represented as a single digit whose value is its height, where 0 is the shortest
//and 9 is the tallest.

//A tree is visible if all of the other trees between it and an edge of the grid are shorter
//than it. Only consider trees in the same row or column; that is, only look up, down, left, or right from any given tree.

//All of the trees around the edge of the grid are visible - since they are already on the edge,
//there are no trees to block the view. In this example, that only leaves the interior nine trees to consider:

//The top-left 5 is visible from the left and top. (It isn't visible from the right or bottom
//since other trees of height 5 are in the way.)
//The top-middle 5 is visible from the top and right.
//The top-right 1 is not visible from any direction; for it to be visible, there would need to
//only be trees of height 0 between it and an edge.
//The left - middle 5 is visible, but only from the right.
//The center 3 is not visible from any direction; for it to be visible, there would need to be
//only trees of at most height 2 between it and an edge.
//The right - middle 3 is visible from the right.
//In the bottom row, the middle 5 is visible, but the 3 and 4 are not.
//With 16 trees visible on the edge and another 5 visible in the interior, a total of 21 trees
//are visible in this arrangement.

//Consider your map; how many trees are visible from outside the grid?

Console.WriteLine(Day8());

static string Day8()
{
    string[] input = File.ReadAllLines("input.txt");
    var TreeMap = new Dictionary<string, int>();
    //ScenicScore();
    //execute
    return $"Part 1: {Sum()}";

    //void ScenicScore()
    //{
    //    var ScoreMap = new Dictionary<string, int>();

    //    for (int x = 0; x < input.Length; x++)
    //    {
    //        for (int y = 0; y < input.Length; y++)
    //        {
    //            var indexStopLeft = 0;
    //            var indexStopRight = 0;
    //            var indexStopUp = 0;
    //            var indexStopDown = 0;
    //        }
    //    }
    //}



    int Sum()
    {
        Left();
        Right();
        Top();
        Bottom();
        int edgeTrees = (input.Length * 4) - 4;
        return TreeMap.Values.Sum() + edgeTrees;
    }
    void Left()
    {
        for (int i = 1; i < input.Length - 1; i++)
        {
            int currentTop = input[i].First();
            int treeIndex = 0;

            foreach (int tree in input[i])
            {
                if (tree > currentTop)
                {
                    if (!TreeMap.ContainsKey(new Tree(treeIndex, i).ToString()))
                        TreeMap.Add(new Tree(treeIndex, i).ToString(), 1);
                    currentTop = tree;
                }
                treeIndex++;
            }
        }
    }
    void Right()
    {
        for (int i = 1; i < input.Length - 1; i++)
        {
            int currentTop = input[i].Last();
            var treeRow = input[i].Reverse();
            int treeIndex = input.Length - 1;

            foreach (int tree in treeRow)
            {
                if (tree > currentTop)
                {
                    if (!TreeMap.ContainsKey(new Tree(treeIndex, i).ToString()))
                        TreeMap.Add(new Tree(treeIndex, i).ToString(), 1);
                    currentTop = tree;
                }
                treeIndex--;
            }
        }
    }
    void Top()
    {
        for (int treeCol = 1; treeCol < input.Length - 1; treeCol++)
        {
            int currentTop = input[0][treeCol];
            for (int i = 0; i < input.Length; i++)
            {
                int tree = input[i][treeCol];
                if (tree > currentTop)
                {
                    if (!TreeMap.ContainsKey(new Tree(treeCol, i).ToString()))
                        TreeMap.Add(new Tree(treeCol, i).ToString(), 1);
                    currentTop = tree;
                }
            }
        }
    }
    void Bottom()
    {
        for (int treeCol = 1; treeCol < input.Length - 1; treeCol++)
        {
            int currentTop = input[input.Length - 1][treeCol];

            for (int i = input.Length - 1; i >= 0; i--)
            {
                int tree = input[i][treeCol];
                if (tree > currentTop)
                {
                    if (!TreeMap.ContainsKey(new Tree(treeCol, i).ToString()))
                        TreeMap.Add(new Tree(treeCol, i).ToString(), 1);
                    currentTop = tree;
                }
            }
        }
    }
}
class Tree
{
    public int x; 
    public int y;
    public Tree(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public override string ToString()
    {
        return $"{x} {y}";
    }
}