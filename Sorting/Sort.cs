using Sprache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CSTestGround.Sorting
{
    public class Sort
    {
        public void start()
        {
            Console.Write("Enter numbers separated by space: ");
            var input = Console.ReadLine();

            string[] separate = input.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);

            int[] numbers = separate.Select(int.Parse).ToArray();

            BubbleSort(numbers);

            foreach (int number in numbers)
            {
                Console.Write($"SORTED: {number}");
            }

            Console.ReadLine();
        }

        public void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j+ 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }
        }

        public void UnknownSort(int[] array)
        {
            int[] 
            for (int i = 0; i < array.Length; i++)
            {

            }
        }

    }
}
