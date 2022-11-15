using System.Diagnostics;
using System.Drawing;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int x = 1;
            int[] result;

            try
            {

            Console.WriteLine("Введите k:");
            int k = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите размерность массива :");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[n];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 5);
                Console.WriteLine($" A [ {i} ] = {array[i]} ");
            }

           
                while (x != 0)
                {

                    Console.WriteLine("Введите код функции для выполнения, если хотите завершить программу введите 0:");
                    x = Convert.ToInt32(Console.ReadLine());

                    switch (x)
                    {
                        case 1:
                            result = one(array, k);
                            Console.WriteLine($"[{result[0]}, {result[1]}]");
                            break;
                        case 2:
                            result = two(array, k);
                            Console.WriteLine($"[{result[0]}, {result[1]}]");
                            break;
                        case 3:
                            result = three(array, k);
                            Console.WriteLine($"[{result[0]}, {result[1]}]");
                            break;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Чтобы выйти нужно нажать ноль!");
            }
        }


        static int[] one(int[] array, int k)
        {
            int[] all_valid = new int[2];
            for (int i = 0, s = 0; i <= array.Length - 2 && s < 1; i++)
                for (int j = i + 1; j <= array.Length - 1 && s < 1; j++)
                {
                    if (array[i] + array[j] == k)
                    {
                        all_valid[0] = array[i];
                        all_valid[1] = array[j];
                        s = 1;
                    }
                }
            return all_valid;
        }

        static int[] two(int[] array, int k) // рядом стоящие 
        {
            int[] all_valid = new int[2];
            int lt = 0;
            int rt = array.Length - 1;
            while (lt != rt)
            {
                int cursum = array[lt] + array[rt];
                if (cursum < k)
                    lt++;
                else if (cursum > k)
                    rt--;
                else
                {
                    all_valid[0] = array[lt];
                    all_valid[1] = array[rt];
                    return all_valid;
                }
            }
            Console.WriteLine("Рядом стоящих элементов нет");
            return all_valid;
        }

        static int[] three(int[] array, int k)
        {
            int[] all_valid = new int[2];
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] + array[j] == k)
                    {
                        all_valid[0] = array[i];
                        all_valid[1] = array[j];
                        return all_valid;
                    }
                }
            }
            Console.WriteLine("Таких элементов нет");
            return all_valid;
        }
    }
}