Dictionary<int, Dictionary<int, int[]>> bankoBoard = new Dictionary<int, Dictionary<int, int[]>>();
int numbersUsed = 0;
int currentRow = 0;

GetNumbers();

void GetNumbers()
{
    Dictionary<int, int[]> row1 = new Dictionary<int, int[]>();
    Dictionary<int, int[]> row2 = new Dictionary<int, int[]>();
    Dictionary<int, int[]> row3 = new Dictionary<int, int[]>();
    
    row1.Add(1, new int[] {1, 15, 26, 41, 90});
    row2.Add(1, new int[] {38, 47, 58, 62, 71});
    row3.Add(1, new int[] {5, 19, 27, 49, 74});
    bankoBoard.Add(1, row1);
    bankoBoard.Add(2, row2);
    bankoBoard.Add(3, row3);
    Console.WriteLine(row1);
    Console.WriteLine(row2);
    Console.WriteLine(row3);
}
for (int i = 0; i <= 18; i++)
{
    for (int j = 0; j <= 108; j++)
    {
        if (i % 6 == 0 || j % 12 == 0)
        {
            Console.Write("*");
        }
        else if (i % 6 == 3 && j % 12 == 6)
        {
            
        }
        else
        {
            Console.Write(" ");
        }
    }
    Console.WriteLine("");
}
Console.WriteLine(bankoBoard);