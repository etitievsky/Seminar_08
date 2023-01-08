// Задайте двумерный массив из целых чисел. Напишите программу, 
// которая удалит строку и столбец, на пересечении которых расположен наименьший элемент массива.

int EnterData(string text)
{
    Console.Write(text);
    int number = int.Parse(Console.ReadLine());
    return number;
}

int[,] CreateArray(int rows, int columns, int minNumber, int maxNumber)
{
    int[,] array = new int[rows, columns];
    for(int i=0; i<rows; i++)
    {
        for(int j=0; j<columns; j++)
        {
            array[i,j] = new Random().Next(minNumber, maxNumber+1);
        }
    }
    return array;
}

void PrintArray(int[,] array)
{
    for(int i=0; i<array.GetLength(0); i++)
    {
        for(int j=0; j<array.GetLength(1); j++)
        {
            Console.Write($"{array[i,j]} ");
        }
    Console.WriteLine();
    }
}

int[,] DeleteMinRowColumn(int[,] array)
{
    int min = array[0,0];
    int minRow = 0;
    int minColumn = 0;
    for(int i=0; i<array.GetLength(0); i++)
    {
        for(int j=0; j<array.GetLength(1); j++)
        {
            if(array[i,j] < min) 
            {
                min = array[i,j];
                minRow = i;
                minColumn = j;
            }
        }
    }
    int[,] arr = new int[array.GetLength(0)-1, array.GetLength(1)-1];
    int ArrCountRows = 0;
    int ArrCountCol = 0;
    for(int i=0; i<array.GetLength(0); i++)
        {
            if(i != minRow)
            {
                for(int j=0; j<array.GetLength(1); j++)
                    {
                        if(j != minColumn)
                        {  
                            arr[ArrCountRows,ArrCountCol] = array[i,j];
                            ArrCountCol++;    
                        }
                    }
                ArrCountRows++;
            }    
        }
            

    return arr;
}


Console.WriteLine("Введите параметры массива:");
int rows = EnterData("количество строк - ");
int columns = EnterData("количество столбцов - ");
int minNumber = EnterData("минимальное значение элемента - ");
int maxNumber = EnterData("максимальное значение элемента - ");
int[,] array = CreateArray(rows, columns, minNumber, maxNumber);
PrintArray(array);
Console.WriteLine();
int[,] arr = DeleteMinRowColumn(array);
PrintArray(arr);