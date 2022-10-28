/*Задача 60. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)*/

int InputMessage(string message)
{
    Console.Write(message);
    return Convert.ToInt32(Console.ReadLine());
}

// для заполнения трёхмерного массива неповторяющимися числами используем булеву логику
bool CheckUniqueElement(int[,,] array, int number)
{
    //проходим по каждому элементу массива и, если он не равен числу, переданному из метода FillArrayNonrepeatingNumbers() и сгенерированного рандомно, то метод возвращает true
    //и в методе FillArrayNonrepeatingNumbers() помещаем это число в итоговый массив
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int x = 0; x < array.GetLength(2); x++)
            {
                if (array[i, j, x] == number)
                {
                    return false;
                }
            }
        }
    }
    return true;
}


void FillArrayNonrepeatingNumbers(int[,,] array, int minNumber, int maxNumber)
{
    Random random = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int x = 0; x < array.GetLength(2); x++)
            {
                while (array[i, j, x] == 0)
                {
                    int number = random.Next(minNumber, maxNumber);
                    if (CheckUniqueElement(array, number) == true)
                    {
                        array[i, j, x] = number;
                    }
                }
            }
        }
    }
}

void PrintArray(int[,,] array) // метод для вывода массива
{
    int rows = array.GetLength(0);
    int columns = array.GetLength(1);
    int planes =  array.GetLength(2);

    for (int x = 0; x < planes; x++)
    {
        for (int i = 0; i < rows; i ++)
        {
            for (int j = 0; j < columns; j ++)
            {
                Console.Write($"{array[i, j, x]} ({i},{j},{x})\t"); // \t используется, чтобы элементы массива при их выводе были визуально выравнены
            }
            Console.WriteLine();
        }
    }
}

int rows = InputMessage("Введите размерность массива по оси x (количество строк массива): ");
int columns = InputMessage("Введите размерность массива по оси y (количество столбцов массива): ");
int planes = InputMessage("Введите размерность массива по оси z: ");
if (rows * columns * planes > 90) // проверяем размерность массива, так как его нужно заполнить неповторяющимися двузначными числами, то он должен содержать не более 90 элементов
    {
        Console.WriteLine("Массив слишком большой! Массив должен содержать не более 90 элементов!");
    }

if (rows * columns * planes < 91)
{
    int[,,] massiv = new int[rows, columns, planes];
    FillArrayNonrepeatingNumbers(massiv, 10, 100); // чтобы заполнить массив только двузначными числами
    PrintArray(massiv);
}