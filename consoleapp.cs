using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

Dictionary<int, Dictionary<int, int[]>> bankoBoard = new Dictionary<int, Dictionary<int, int[]>>();
Dictionary<int, List<int>> boardsWith1Row = new Dictionary<int, List<int>>();
Dictionary<int, List<int>> boardsWith2Rows = new Dictionary<int, List<int>>();
Dictionary<int, List<int>> boardsWith3Rows = new Dictionary<int, List<int>>();

int numbersInRow = 0;
int currentRow = 0;
int currentBoard = 0;
int currentColumn = 0;
int rowsNeeded = 1;
int numbersPerRow = 5;
int boardsNeeded = 0;
int rowsPerBoard = 3;
int boxHeight = 2;
int boxWidth = boxHeight * 2;
int nextNumber;

List<string> boardIDs = new List<string>();
List<int> enteredNumbers = new List<int>();

string userInput = "";

bool moreInRow = true;
bool gameOver = false;
bool isValidInput = false;

RunGame();

void GetNumbers()
{
    Random rng = new Random();


    for (int i = 0; i < boardsNeeded; i++)
    {
        Dictionary<int, int[]> rows = new Dictionary<int, int[]>();

        switch (i)
        {
            case 0:
                rows.Add(0, new int[] {21, 31, 44, 71, 80});
                rows.Add(1, new int[] {8, 32, 47, 53, 64});
                rows.Add(2, new int[] {9, 18, 37, 49, 88});
                boardIDs.Add("Simon");
                break;
            case 1:
                rows.Add(0, new int[] {1, 23, 60, 75, 80});
                rows.Add(1, new int[] {17, 26, 34, 46, 57});
                rows.Add(2, new int[] {7, 19, 28, 58, 69});
                boardIDs.Add("Vilslev");
                break;
            case 2:
                rows.Add(0, new int[] {1, 10, 32, 42, 71});
                rows.Add(1, new int[] {25, 34, 53, 67, 73});
                rows.Add(2, new int[] {9, 19, 37, 47, 89});
                boardIDs.Add("WiseGeek");
                break;
            case 3:
                rows.Add(0, new int[] {31, 51, 60, 70, 80});
                rows.Add(1, new int[] {22, 41, 63, 72, 88});
                rows.Add(2, new int[] {9, 18, 36, 59, 79});
                boardIDs.Add("Silas");
                break;
            case 4:
                rows.Add(0, new int[] {3, 21, 30, 44, 52});
                rows.Add(1, new int[] {4, 45, 55, 77, 84});
                rows.Add(2, new int[] {14, 28, 69, 78, 86});
                boardIDs.Add("Lukas");
                break;
            case 5:
                rows.Add(0, new int[] { 1, 11, 21, 31, 40 });
                rows.Add(1, new int[] { 1, 11, 21, 31, 41 });
                rows.Add(2, new int[] { 1, 11, 21, 31, 42 });
                boardIDs.Add("Test");
                break;
            default:
                for (int j = 0; j < rowsPerBoard; j++)
                {

                    int[] row = new int[numbersPerRow];

                    for (int k = 0; k < numbersPerRow; k++)
                    {
                        int minNumber = 0;
                        int maxNumber = 0;
                        if(j == 1)
                        {

                            if (k == 4)
                            {
                                minNumber = 81;
                                maxNumber = 90;
                            }
                            else
                            {
                                minNumber = k * 20 + 1;
                                maxNumber = (k + 1) * 20 - 1;
                            }
                        }
                        else
                        {
                            if (k == 4)
                            {
                                minNumber = 71;
                                maxNumber = 90;
                            }
                            else
                            {
                                minNumber = k * 20 + 1;
                                maxNumber = (k + 1) * 20 - 11;
                            }
                        }

                        int randomNumber = rng.Next(minNumber, maxNumber + 1);

                        while (row.Contains(randomNumber))
                        {
                            randomNumber = rng.Next(minNumber, maxNumber + 1);
                        }

                        row[k] = randomNumber;
                    }
                    rows.Add(j, row);
                }
                boardIDs.Add((i + 1).ToString());
                break;
        }
        bankoBoard.Add(i, rows);
    }
}


void PrintBoards()
{
    GetNumbers();
    for (int i = 0; i < boardsNeeded; i++)
    {
        Console.WriteLine($"Board ID: {boardIDs[i]}");
        for (int j = 0; j <= (boxHeight * 3); j++)
        {
            for (int k = 0; k <= (boxWidth * 9); k++)
            {
                if (j % boxHeight == 0 || k % boxWidth == 0)
                {
                    Console.Write("*");
                }
                else if (j % boxHeight == boxHeight / 2 && k % boxWidth == boxWidth / 2)
                {
                    if (moreInRow)
                    {
                        int outerKey = currentBoard; // Replace with the desired outer key
                        int innerKey = currentRow; // Replace with the desired inner key
                        int indexToAccess = numbersInRow; // Replace with the desired index to access

                        if (bankoBoard.ContainsKey(outerKey) && bankoBoard[outerKey].ContainsKey(innerKey))
                        {
                            int[] innerArray = bankoBoard[outerKey][innerKey];

                            if (indexToAccess >= 0 && indexToAccess < innerArray.Length)
                            {
                                int valueAtIndex = innerArray[indexToAccess];

                                switch (currentColumn)
                                {
                                    case 0:
                                        if (valueAtIndex >= 1 && valueAtIndex <= 9)
                                        {
                                            Console.Write(valueAtIndex);
                                            numbersInRow++;
                                        }
                                        else
                                        {
                                            Console.Write(" ");
                                        }
                                        break;
                                    case 1:
                                        if (valueAtIndex >= 10 && valueAtIndex <= 19)
                                        {
                                            Console.Write(valueAtIndex);
                                            numbersInRow++;
                                            k++;
                                        }
                                        else
                                        {
                                            Console.Write(" ");
                                        }
                                        break;
                                    case 2:
                                        if (valueAtIndex >= 20 && valueAtIndex <= 29)
                                        {
                                            Console.Write(valueAtIndex);
                                            numbersInRow++;
                                            k++;
                                        }
                                        else
                                        {
                                            Console.Write(" ");
                                        }
                                        break;
                                    case 3:
                                        if (valueAtIndex >= 30 && valueAtIndex <= 39)
                                        {
                                            Console.Write(valueAtIndex);
                                            numbersInRow++;
                                            k++;
                                        }
                                        else
                                        {
                                            Console.Write(" ");
                                        }
                                        break;
                                    case 4:
                                        if (valueAtIndex >= 40 && valueAtIndex <= 49)
                                        {
                                            Console.Write(valueAtIndex);
                                            numbersInRow++;
                                            k++;
                                        }
                                        else
                                        {
                                            Console.Write(" ");
                                        }
                                        break;
                                    case 5:
                                        if (valueAtIndex >= 50 && valueAtIndex <= 59)
                                        {
                                            Console.Write(valueAtIndex);
                                            numbersInRow++;
                                            k++;
                                        }
                                        else
                                        {
                                            Console.Write(" ");
                                        }
                                        break;
                                    case 6:
                                        if (valueAtIndex >= 60 && valueAtIndex <= 69)
                                        {
                                            Console.Write(valueAtIndex);
                                            numbersInRow++;
                                            k++;
                                        }
                                        else
                                        {
                                            Console.Write(" ");
                                        }
                                        break;
                                    case 7:
                                        if (valueAtIndex >= 70 && valueAtIndex <= 79)
                                        {
                                            Console.Write(valueAtIndex);
                                            numbersInRow++;
                                            k++;
                                        }
                                        else
                                        {
                                            Console.Write(" ");
                                        }
                                        break;
                                    case 8:
                                        if (valueAtIndex >= 80 && valueAtIndex <= 90)
                                        {
                                            Console.Write(valueAtIndex);
                                            numbersInRow++;
                                            k++;
                                        }
                                        else
                                        {
                                            Console.Write(" ");
                                        }
                                        break;
                                    default:
                                        Console.Write(" ");
                                        break;
                                }
                                if (numbersInRow >= 5)
                                {
                                    numbersInRow = 0;
                                    moreInRow = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                    currentColumn++;
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine("");
            if (moreInRow == false)
            {
                currentColumn = 0;
                currentRow++;
                moreInRow = true;
            }
        }
        currentBoard++;
        currentRow = 0;
        Console.WriteLine("\n\n");
    }

}

void CheckRows()
{
    foreach (var board in bankoBoard)
    {
        List<int> rowsCompleted = new List<int>();

        foreach (var row in board.Value)
        {
            bool allValuesExistInCurrentRow = row.Value.All(value => enteredNumbers.Contains(value));
            if (allValuesExistInCurrentRow )
            {
                rowsCompleted.Add(row.Key);
            }
        }
        if(rowsCompleted.Count == rowsNeeded)
        {
            switch(rowsNeeded)
            {
                case 1:
                    if(rowsCompleted.Count >= 1)
                    {
                        boardsWith1Row.Add(board.Key, rowsCompleted);
                    }
                    break;
                case 2:
                    if (rowsCompleted.Count >= 2)
                    {
                        boardsWith2Rows.Add(board.Key, rowsCompleted);
                    }
                    break;
                case 3:
                    if (rowsCompleted.Count >= 3)
                    {
                        boardsWith3Rows.Add(board.Key, rowsCompleted);
                    }
                    break;
                default:
                    break;
            }
        }
    }
    switch (rowsNeeded)
    {
        case 1:
            if (boardsWith1Row.Count >= 1)
            {
                foreach (var board in boardsWith1Row)
                {
                    Console.WriteLine($"All values in board {boardIDs[board.Key]}, row: {board.Value[0] + 1}  have been entered!");
                    Console.WriteLine($"Congratulations you win {rowsNeeded} row");
                }
                rowsNeeded++;
            }
            break;
        case 2:
            if (boardsWith2Rows.Count >= 1)
            {
                foreach (var board in boardsWith2Rows)
                {
                    Console.WriteLine($"All values in board {boardIDs[board.Key]}, rows: {board.Value[0] + 1} and {board.Value[1] + 1} have been entered!");
                    Console.WriteLine($"Congratulations you win {rowsNeeded} rows");
                }
                rowsNeeded++;
            }
            break;
        case 3:
            if (boardsWith3Rows.Count >= 1)
            {
                foreach (var board in boardsWith3Rows)
                {
                    Console.WriteLine($"All values in board, {boardIDs[board.Key]}, have been entered!");
                    Console.WriteLine($"Congratulations you win full board");
                }
                rowsNeeded++;
                gameOver = true;
            }
            break;
        default:
            break;
    }
}

void RunGame()
{
    bankoBoard = new Dictionary<int, Dictionary<int, int[]>>();
    boardsWith1Row = new Dictionary<int, List<int>>();
    boardsWith2Rows = new Dictionary<int, List<int>>();
    boardsWith3Rows = new Dictionary<int, List<int>>();

    numbersInRow = 0;
    currentRow = 0;
    currentBoard = 0;
    currentColumn = 0;
    rowsNeeded = 1;

    boardIDs = new List<string>();
    enteredNumbers = new List<int>();

    gameOver = false;
    isValidInput = false;

    Console.Clear();

    while (true)
    {
        Console.WriteLine("How many boards would you like?");
        userInput = Console.ReadLine();

        isValidInput = Int32.TryParse(userInput, out boardsNeeded);
        if(!isValidInput)
        {
            Console.WriteLine("Input not recognized, please only enter whole numbers");
        } 
        else if (boardsNeeded < 1)
        {
            Console.WriteLine("you need at least one board to play");
        }
        else if(isValidInput && boardsNeeded >= 1)
        {
            break;
        }
    }

    PrintBoards();

    while (gameOver == false)
    {

        Console.WriteLine("Enter a number between 1 and 90, 0 to exit");
        userInput = Console.ReadLine();

        isValidInput = Int32.TryParse(userInput, out nextNumber);

        if (isValidInput)
        {
            if (nextNumber == 0)
            {
                gameOver = true;
            }
            else if (nextNumber >= 1 && nextNumber <= 90)
            {
                if(enteredNumbers.Contains(nextNumber) == false)
                {
                    enteredNumbers.Add(nextNumber);
                    CheckRows();
                }
            }
        }
    }
}

while (true)
{
    Console.WriteLine("do you want to play again? Y/N");
    userInput = Console.ReadLine();
    userInput = userInput.ToUpper();
    if(userInput == "YES" || userInput == "Y")
    {
        RunGame();
    }
    else if(userInput == "NO" || userInput == "N")
    {
        break;
    }
    else
    {
        Console.WriteLine("Input not recognized, try again");
    }
}