using System;

namespace HomeWork4 //// Студент Вечёрко Р.Д. 1. Дан целочисленный массив из 20 элементов.
                    //// Элементы массива могут принимать целые значения от –10 000 до 10 000 включительно. 
                    ///Заполнить случайными числами. Написать программу, позволяющую найти и вывести количество пар 
                    ///элементов массива, в которых только одно число делится на 3. В данной задаче под парой 
                    ///подразумевается два подряд идущих элемента массива.
                    ///Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2.
{
    class Program
    {
        static int GetNumberOfPairs(int[] array, int length)
        {
            int amountOfPairs = 0;
            for (int i = 0; i < length - 1; i++)
            {
                if (array[i] % 3 == 0 || array[i + 1] % 3 == 0)
                {
                    amountOfPairs++;
                }
            }
            return amountOfPairs;
        }

        static void Main(string[] args)
        {
            const int arrayLength = 20;
            int[] myArray = new int[arrayLength];
            Random random = new Random();
            int result;

            Console.WriteLine("Программа подсчёта пар элементов, в которых хотя бы одно число делится на 3.");
            Console.Write("\nВ следующем массиве [ ");
            for (int i = 0; i < arrayLength; i++)
            {
                myArray[i] = random.Next(-10000, 10000);
                Console.Write(myArray[i] + ", ");
            }
            Console.WriteLine("\b\b ]\n");

            result = GetNumberOfPairs(myArray, arrayLength);

            Console.WriteLine($"Количество пар: {result}");
        }
    }
}
