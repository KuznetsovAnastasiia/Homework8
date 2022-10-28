/*Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка*/

void FillArray(int[,] array) // метод заполнения массива
{
    Random random = new Random();
    int rows = array.GetLength(0); //метод GetLength используем, чтобы получить количество строк заданного массива в текущем методе
    int columns = array.GetLength(1); //метод GetLength используем, чтобы получить количество столбцов заданного массива в текущем методе  
    
    for (int i = 0; i < rows; i ++)
    {
        for (int j = 0; j < columns; j ++)
        {
            array[i, j] = random.Next(0,11);
        }
    }
}

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

void PrintArrayOneDimensional(int[] arr) // метод вывода одномерного массива
{
    Console.Write("[");
    for (int i = 0; i < arr.Length - 1; i++)
    {
        Console.Write(arr[i] + ", ");
        if (i == arr.Length - 2)
        {
            Console.Write(arr[arr.Length - 1] + "]");
        }
    }
}

int[] FindSumOfRows(int[,] array) // метод для нахождения строки с наименьшей суммой элементов
{
    int[] result = new int[array.GetLength(0)]; // одномерный массив для сохранения результата
    
    for (int i = 0; i < array.GetLength(0); i++) // заполняем одномерный массив суммами каждой строки (один элемент одномерного массива = сумме элементов строки двумерного исходного массива)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                result[i] += array[i, j];
            }
        }
    return result;
}

int Result(int[] massiv)
{   //перебираем элементы нового одномерного массива для нахождения строки с минимальной суммой элементов
    int minSumm = massiv[0];
    int minNumberRow = 0;
    for (int i = 0; i < massiv.Length; i++)
    {
        if(massiv[i] < minSumm)
        {
            minSumm = massiv[i];
            minNumberRow = i;
        }
    }
    return minNumberRow;
}


//создаём двумерный массив
Random random = new Random();
int rows = random.Next(2, 5);
int columns = random.Next(4, 5);
int[,] numbers = new int[rows, columns];

Console.Clear();
Console.WriteLine($"Исходный массив размером {rows} на {columns}.");

FillArray(numbers); // вызов метода для заполнения двумерного массива случайными числами
PrintArray(numbers); // вызов метода для печати двумерного массива
Console.WriteLine();

PrintArrayOneDimensional(FindSumOfRows(numbers)); // выводим на печать одномерный массив, в котором хранятся суммы строк двумерного массива
int[] resultSumm = new int[rows]; // создаём одномерный массив для сохранения в нём результатов сложения элементов строк двумерного массива
resultSumm = FindSumOfRows(numbers);
Console.WriteLine();
Console.WriteLine($"Номер строки с наименьшей суммой элементов: {Result(resultSumm) + 1}.");