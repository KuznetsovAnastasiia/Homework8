/*Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07*/

void PrintArray(int[,] array) // метод для вывода массива
{
    int rows = array.GetLength(0); //метод GetLength используем, чтобы получить количество строк заданного массива в текущем методе
    int columns = array.GetLength(1); //метод GetLength используем, чтобы получить количество столбцов заданного массива в текущем методе
    for (int i = 0; i < rows; i ++)
    {
        for (int j = 0; j < columns; j ++)
        {
            Console.Write($"{array[i, j]}\t"); // \t используется, чтобы элементы массива при их выводе были визуально выравнены
        }
        Console.WriteLine();
    }
}

void FillArrayHelix(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        if (i == 0)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = j + 1;
            }
        }

        if (i == 3)
        {
            int temp = 1;
            for (int j = array.GetLength(1) - 1; j > -1; j--)
            {
                array[i, j] = i + j + temp;
                temp += 2;
            }
        }

        if (i == 1)
        {
            int temp = 12;
            for (int j = 1; j < array.GetLength(1) - 1; j++)
            {
                array[i, j] = j + temp;
            }
        }

        if (i == 2)
        {
            int temp = 9;
            for (int j = array.GetLength(1) - 1; j > 0; j--)
            {
                array[i, j] = i + j + temp;
                temp += 2;
            }
        }
    }

    for (int j = 0; j < array.GetLength(1); j++)
    {
        if (j == 3)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                array[i, j] = i + 4;
            }
        }

        if (j == 0)
        {
            int temp = 9;
            for (int i = 2; i > 0; i--)
            {
                array[i, j] = i + temp;
                temp += 2;
            }
        }
    }
}

int[,] numbersHelix = new int[4, 4];
FillArrayHelix(numbersHelix);
PrintArray(numbersHelix);