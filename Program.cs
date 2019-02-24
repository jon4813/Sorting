using System;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            var mas = Common.Generate(10);
            Common.Print(mas);
            PyramidSort.Sort(mas);
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

    class InsertionSort
    {
        public static void Sort(int[] mas)
        {
            for(int i = 1; i < mas.Length; i++)
            {                                
                for (int j = i; j > 0; j--)
                {
                    if (mas[j-1] > mas[j])
                    {
                        Common.Swap(mas,j,j-1);
                    }
                    
                }                
            }
        }
    }

    public class PyramidSort
    {
        public static void Sort(int[] mas)
        {
            CreateHeap(mas);
            for(int i = mas.Length - 1; i >= 0; i-- )
            {
                mas[i] = RemoveRoot(mas, i);
            }
        }
        private static void CreateHeap(int[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                var index = i;
                while(index != 0)
                {
                    var parent = (index - 1) / 2;
                    if (mas[index] <= mas[parent]) break;

                    Common.Swap(mas, index, parent);

                    index = parent;
                }
            }
        }
        private static int RemoveRoot(int[] mas, int count)
        {
            var result = mas[0];

            mas[0] = mas[count];
            var index = 0;

            while (true)
            {
                var child1 = (index * 2) + 1;
                var child2 = (index *2) + 2;

                if (child1 > count) { child1 = index;}
                if (child2 > count) { child2 = index;}

                if (mas[index] >= mas[child1] && mas[index] >= mas[child2])
                    break;

                int swap_child = 0;
                if (mas[child1] > mas[child2])
                    swap_child = child1;
                else
                    swap_child = child2;
                
                Common.Swap(mas, index, swap_child);
                index = swap_child;
            }

            return result;
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

