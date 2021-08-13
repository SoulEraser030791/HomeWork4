using System;
using System.IO;

namespace Ex3 //// Реализовать библиотеку с классом для работы с двумерным массивом.
              //// Реализовать конструктор, заполняющий массив случайными числами. 
///Создать методы, которые возвращают сумму всех элементов массива, сумму всех элементов массива 
///больше заданного, свойство, возвращающее минимальный элемент массива, свойство, возвращающее 
///максимальный элемент массива, метод, возвращающий номер максимального элемента массива 
///(через параметры, используя модификатор ref или out).
{
    class myDimensionalArray
    {
        public int[,] a;
        public myDimensionalArray() { }

        public myDimensionalArray(int n, int m)
        {
            a = new int[n, m];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    a[i, j] = rnd.Next();
        }

        public myDimensionalArray(string filename)
        {
            filename = "..\\..\\" + filename;
            string[] ss = new string[0];
            try
            {
                ss = File.ReadAllLines(filename);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File doesnt exist in : " + filename);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Exception catched: " + ex.Message);
            }

            a = new int[ss.Length, ss.Length];

            for (int i = 0; i < ss.Length; i++)
            {
                string[] tempArray = ss[i].Split(' ');
                for (int j = 0; j < ss.Length; j++)
                {
                    a[i, j] = int.Parse(tempArray[j]);
                }
            }

        }

        public int Max
        {
            get
            {
                int max = a[0, 0];
                for (int i = 0; i < a.GetLength(0); i++)
                    for (int j = 0; j < a.GetLength(1); j++)
                        if (a[i, j] > max) max = a[i, j];

                return max;
            }
        }

        public void Sum(out long sum)
        {
            sum = 0;
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    sum += a[i, j];
        }

        public void IndexOfMax(out string index)
        {
            index = "-1, -1";
            int max = Max;
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    if (a[i, j] == max)
                        index = i + ", " + j;
        }

        public void SumMoreThan(out long sum, int min)
        {
            sum = 0;
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] > min)
                        sum += a[i, j];
                }
        }
        public int Min
        {
            get
            {
                int min = a[0, 0];
                for (int i = 0; i < a.GetLength(0); i++)
                    for (int j = 0; j < a.GetLength(1); j++)
                        if (a[i, j] < min) min = a[i, j];

                return min;
            }
        }


        public string[] toString()
        {
            string[] s = new string[a.GetLength(0)];

            for (int i = 0; i < a.GetLength(0); i++)
            {
                s[i] += "[ ";
                for (int j = 0; j < a.GetLength(1); j++)
                    s[i] += String.Format($"{a[i, j]:D10} ");
                s[i] += " ]";
            }
            return s;
        }

        public void PrintDinArr(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
