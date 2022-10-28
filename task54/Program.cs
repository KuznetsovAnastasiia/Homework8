/*Задача 54: Задайте двумерный массив. Напишите программу,
которая упорядочит по убыванию элементы каждой строки двумерного массива.*/

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

int[,] Zadacha54(int[,] array) // метод для сортировки двумерного массива методом пузырька
{
    for (int i = 0; i < array.GetLength(0); i ++) // сортируем методом пузырька в цикле
    {
        for (int j = 0; j < array.GetLength(1) - 1; j++)
        {
            for (int x = 0; x < array.GetLength(1) - 1; x++)
            {
                int temp;
                if (array[i, x] < array[i, x + 1])
                {
                    temp = array[i, x];
                    array[i, x] = array[i, x + 1];
                    array[i, x + 1] = temp;
                }
            }
        }
    }

    return array;
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
Zadacha54(numbers);
Console.WriteLine($"Итоговый массив после сортировки методом пузырька.");
PrintArray(numbers); // вызов метода для печати двумерного массива