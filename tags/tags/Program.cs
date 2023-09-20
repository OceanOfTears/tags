using System;

int[,] nums = new int[4, 4]{
    {1, 2, 3, 4},    {5, 6, 7, 8},
    {9, 10, 11, 12}, {13, 14, 15, 0}
};
int w = nums.GetLength(0);
int h = nums.GetLength(1);
Random rand = new Random();
for (int i = w * h - 1; i > 0; i--)
{
    int row1 = i / w;
    int col1 = i % h;
    int row2 = rand.Next(0, w);
    int col2 = rand.Next(0, h);
    int temp = nums[row1, col1];
    nums[row1, col1] = nums[row2, col2];
    nums[row2, col2] = temp;
}
while (true)
{
    for (int i = 0; i < nums.GetLength(0); i++)
    {
        for (int j = 0; j < nums.GetLength(1); j++)
        {
            Console.Write(nums[i, j] + "\t");
        }
        Console.WriteLine();
    }
    if (IsWinner(nums))
    {
        Console.WriteLine("пабеда!");
        break;
    }
    Console.WriteLine("Куда переместить 0? (W, A, S, D), 0 для выхода:");
    string direction = Console.ReadLine().ToUpper();
    if (direction == "0")
    {
        Console.WriteLine("Выход из программы.");
        break;
    }

    if (CanMove(nums, direction))
    {
        MoveZero(nums, direction);
    }
    else
    {
        Console.WriteLine("Нельзя переместить 0");
    }
}
bool IsWinner(int[,] nums)
{
    int n = 1;
    for (int i = 0; i < nums.GetLength(0); i++)
    {
        for (int j = 0; j < nums.GetLength(1); j++)
        {
            if (nums[i, j] != n)
            {
                return false;
            }
            n = (n + 1) % (w * h);
        }
    }
    return true;
}
bool CanMove(int[,] nums, string direction)
{
    int zeroRow = -1;
    int zeroCol = -1;
    for (int i = 0; i < nums.GetLength(0); i++)
    {
        for (int j = 0; j < nums.GetLength(1); j++)
        {
            if (nums[i, j] == 0)
            {
                zeroRow = i;
                zeroCol = j;
                break;
            }
        }
    }
    switch (direction)
    {
        case "W":
            return zeroRow > 0;
        case "A":
            return zeroCol > 0;
        case "S":
            return zeroRow < nums.GetLength(0) - 1;
        case "D":
            return zeroCol < nums.GetLength(1) - 1;
        default:
            return false;
    }
}
void MoveZero(int[,] nums, string direction)
{
    int zeroRow = -1;
    int zeroCol = -1;
    for (int i = 0; i < nums.GetLength(0); i++)
    {
        for (int j = 0; j < nums.GetLength(1); j++)
        {
            if (nums[i, j] == 0)
            {
                zeroRow = i;
                zeroCol = j;
                break;
            }
        }
    }
    int newRow = zeroRow;
    int newCol = zeroCol;
    switch (direction)
    {
        case "W":
            newRow--;
            break;
        case "A":
            newCol--;
            break;
        case "S":
            newRow++;
            break;
        case "D":
            newCol++;
            break;
    }
    int temp = nums[zeroRow, zeroCol];
    nums[zeroRow, zeroCol] = nums[newRow, newCol];
    nums[newRow, newCol] = temp;
}