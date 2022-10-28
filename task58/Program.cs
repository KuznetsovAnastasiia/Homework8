/*Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18*/

int InputMessage(string message)
{
    Console.Write(message);
    return Convert.ToInt32(Console.ReadLine());
}

void FillArray(int[,] array) // метод заполнения массива
{
    Random random = new Random();
    int rows = array.GetLength(0);
    int columns = array.GetLength(1); 
    
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
    int rows = array.GetLength(0);
    int columns = array.GetLength(1);
    for (int i = 0; i < rows; i ++)
    {
        for (int j = 0; j < columns; j ++)
        {
            Console.Write($"{array[i, j]}\t");
        }
        Console.WriteLine();
    }
}

void CreatArrayProduct(int[,] arrayA, int[,] arrayB)
{
    if (arrayA.GetLength(1) != arrayB.GetLength(0)) // проверям, возможно ли произведение матриц
    {
        Console.WriteLine("Произведение матриц невозможно! Число столбцов первой матрицы должно быть равно числу строк второй!");
    }

    int[,] arrayProduct = new int[arrayA.GetLength(0), arrayB.GetLength(1)]; // создаём массив для сохранения результата произведения матриц
    if (arrayA.GetLength(1) == arrayB.GetLength(0))
    {
        for (int i = 0; i < arrayA.GetLength(0); i++)
        {
            for (int j = 0; j < arrayB.GetLength(1); j++)
            {
                for (int x = 0; x < arrayA.GetLength(1); x++)
                {
                    arrayProduct[i, j] += arrayA[i, x] * arrayB[x, j];
                }
            }
        }
        Console.WriteLine("Результат произведения двух матриц: ");
        PrintArray(arrayProduct);
    }
}

//создаём два двумерных массива, спрашивая у пользователя их размерность

int rowsA = InputMessage("Введите количество строк первой матрицы: ");
int columnsA = InputMessage("Введите количество столбцов первой матрицы: ");
int[,] numbersA = new int[rowsA, columnsA];

FillArray(numbersA); // вызов метода для заполнения двумерного массива случайными числами
Console.WriteLine("Первая матрица:");
PrintArray(numbersA); // вызов метода для печати двумерного массива
Console.WriteLine();

int rowsB = InputMessage("Введите количество строк второй матрицы: ");
int columnsB = InputMessage("Введите количество столбцов второй матрицы: ");
int[,] numbersB = new int[rowsB, columnsB];

FillArray(numbersB); // вызов метода для заполнения двумерного массива случайными числами
Console.WriteLine("Вторая матрица:");
PrintArray(numbersB); // вызов метода для печати двумерного массива
Console.WriteLine();

CreatArrayProduct(numbersA, numbersB);