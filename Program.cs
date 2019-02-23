using System;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            var mas = Common.Generate(30);
            Common.Print(mas);
            QSort.Sort(mas);
            Common.Print(mas);
        }
    }

    class QSort{
        public static void Sort(int[] mas)
        {
            Sort(mas,0, mas.Length - 1);
        }

        static void Sort(int[] mas, int start, int end)
        {
            if (start >= end)
                return;            
            var middle = Pivot(mas, start, end);            
            Sort(mas, start, middle);
            Sort(mas, middle + 1, end);                        
        }

        static int Pivot(int[] mas, int start, int end)
        {
            var middle = (start + end) / 2;
            var middleVal = mas[middle];
            var less = start;
            var grater = end;

            while (true)
            {
                while(mas[less] < middleVal)
                {
                    less ++;
                }

                while(mas[grater] > middleVal)
                {
                    grater--;
                } 

                if (less >= grater)
                {
                    return grater;
                }                
                Common.Swap(mas, less, grater);
                grater--;                                             
                less++;
            }
        }
    }

    static class Common
    {
        public static void Swap(int[] mas, int i, int j)        
        {
            var tmp = mas[i];
            mas[i] = mas[j];
            mas[j] = tmp;
        }

        public static int[] Generate(int len)
        {
            int[] result=new int[len];
            for(int i = 0; i< len; i++)
            {
                result[i] = i;
            }

            Random rnd = new Random();
            for(int i = 0; i< len; i++)
            {
                var ir = rnd.Next(len);
                var jr = rnd.Next(len);

                Swap(result, ir, jr);
            }

            return result;
        }

        public static void Print(int[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                Console.Write($"<-{mas[i]}");
            }
            System.Console.WriteLine();
        }
    }
}

