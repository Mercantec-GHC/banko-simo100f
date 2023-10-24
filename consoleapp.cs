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
int nextNumber;
int rowsNeeded = 1;
int rowsPerBoard = 3;
int numbersPerRow = 5;
int boardsNeeded = 5;

List<string> boardIDs = new List<string>();
List<int> enteredNumbers = new List<int>();

string userInput = "";

bool moreInRow = true;
bool gameOver = false;
bool isValidInput;

GetNumbers();

void GetNumbers()
{
    Random rng = new Random();


    for (int i = 0; i < boardsNeeded; i++)
    {
        Dictionary<int, int[]> rows = new Dictionary<int, int[]>();

        switch (i)
        {
            case 1:
                for (int j = 0; j < rowsPerBoard; j++)
                {
                    rows.Add(j, row);
                    rows.Add(j, row);
                    rows.Add(j, row);
                }
            case 2:
                for (int j = 0; j < rowsPerBoard; j++)
                {

                    int[] row = new int[numbersPerRow];

                    for (int k = 0; k < numbersPerRow; k++)
                    {
                        int minNumber = k * 10 + 1;
                        int maxNumber = (k + 1) * 10 - 1;

                        int randomNumber = rng.Next(minNumber, maxNumber + 1);

                        while (row.Contains(randomNumber))
                        {
                            randomNumber = rng.Next(minNumber, maxNumber + 1);
                        }

                        row[k] = randomNumber;
                    }
                    rows.Add(j, row);
                }
            case 3:
                for (int j = 0; j < rowsPerBoard; j++)
                {

                    int[] row = new int[numbersPerRow];

                    for (int k = 0; k < numbersPerRow; k++)
                    {
                        int minNumber = k * 10 + 1;
                        int maxNumber = (k + 1) * 10 - 1;

                        int randomNumber = rng.Next(minNumber, maxNumber + 1);

                        while (row.Contains(randomNumber))
                        {
                            randomNumber = rng.Next(minNumber, maxNumber + 1);
                        }

                        row[k] = randomNumber;
                    }
                    rows.Add(j, row);
                }
            case 4:
                for (int j = 0; j < rowsPerBoard; j++)
                {

                    int[] row = new int[numbersPerRow];

                    for (int k = 0; k < numbersPerRow; k++)
                    {
                        int minNumber = k * 10 + 1;
                        int maxNumber = (k + 1) * 10 - 1;

                        int randomNumber = rng.Next(minNumber, maxNumber + 1);

                        while (row.Contains(randomNumber))
                        {
                            randomNumber = rng.Next(minNumber, maxNumber + 1);
                        }

                        row[k] = randomNumber;
                    }
                    rows.Add(j, row);
                }
            case 5:
                for (int j = 0; j < rowsPerBoard; j++)
                {

                    int[] row = new int[numbersPerRow];

                    for (int k = 0; k < numbersPerRow; k++)
                    {
                        int minNumber = k * 10 + 1;
                        int maxNumber = (k + 1) * 10 - 1;

                        int randomNumber = rng.Next(minNumber, maxNumber + 1);

                        while (row.Contains(randomNumber))
                        {
                            randomNumber = rng.Next(minNumber, maxNumber + 1);
                        }

                        row[k] = randomNumber;
                    }
                    rows.Add(j, row);
                }
            default:
                for (int j = 0; j < rowsPerBoard; j++)
                {

                    int[] row = new int[numbersPerRow];

                    for (int k = 0; k < numbersPerRow; k++)
                    {
                        int minNumber = k * 10 + 1;
                        int maxNumber = (k + 1) * 10 - 1;

                        int randomNumber = rng.Next(minNumber, maxNumber + 1);

                        while (row.Contains(randomNumber))
                        {
                            randomNumber = rng.Next(minNumber, maxNumber + 1);
                        }

                        row[k] = randomNumber;
                    }
                    rows.Add(j, row);
                }
        }
        bankoBoard.Add(i, rows);
    }
}



for (int i = 0; i < boardsNeeded; i++)
{
    Console.WriteLine($"Board ID: {currentBoard + 1}");
    for (int j = 0; j <= 18; j++)
    {
        for (int k = 0; k <= 108; k++)
        {
            if (j % 6 == 0 || k % 12 == 0)
            {
                Console.Write("*");
            }
            else if (j % 6 == 3 && k % 12 == 6)
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

void CheckRows()
{
    foreach (var board in bankoBoard)
    {
        List<int> rowsCompleted = new List<int>();
        //Console.WriteLine(board);
        foreach (var row in board.Value)
        {
            //Console.WriteLine(row);
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
                    Console.WriteLine($"All values in board {board.Key + 1}, row:");
                    foreach (var row in board.Value)
                    {
                        Console.WriteLine($"{row + 1}");
                    }
                    Console.WriteLine(" have been entered!");
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
                    Console.WriteLine($"All values in board {board.Key + 1}, rows:");
                    foreach (var row in board.Value)
                    {
                        Console.WriteLine($"{row + 1}");
                    }
                    Console.WriteLine(" have been entered!");
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
                    Console.WriteLine($"All values in board, {board.Key + 1}, have been entered!");
                    Console.WriteLine($"Congratulations you win full board");
                }
                rowsNeeded++;
            }
            break;
        default:
            break;
    }
}

RunGame();
void RunGame()
{
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
                    foreach(var x in enteredNumbers)
                    {
                        Console.Write($"{x}, ");
                    }
                    Console.WriteLine();
                    CheckRows();
                    Console.WriteLine($"You need, {rowsNeeded}, rows to win");
                }
            }
        }
    }
}

while (true)
{
    Console.WriteLine("Press 1 to play again");
    userInput = Console.ReadLine();
    isValidInput = Int32.TryParse(userInput, out nextNumber);

    if (isValidInput && nextNumber == 1)
    {
        RunGame();
    }
}