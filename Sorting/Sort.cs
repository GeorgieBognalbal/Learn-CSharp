using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
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

            Console.Write("TYPE OF SORT: ");
            Console.WriteLine("1. BUBBLE SORT");
            Console.WriteLine("2. BUILT-IN ARRAY METHOD");

            Console.Write("Selected Number: ");
            switch (Console.ReadLine())
            {
                case "1":
                    BubbleSort(numbers);
                    break;
                case "2":
                    FindMinMax(numbers);
                    break;
                default:
                    Console.WriteLine("INVALID OPTION");
                    break;
            }

            Console.WriteLine("PRESS ANYKEY TO RETURN TO MENU.....");
            Console.ReadKey();
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

            Console.Write($"SORTED WITH BUBBLE SORT: ");
            foreach (int number in array)
            {
                Console.Write($"{number} ");
            }

            Console.ReadLine();
        }

        public static void FindMinMax(int[] values) // Built-in Array methods
        {
            int[] sorted = { };

            Array.Sort(values);

            for (int i = 0; i < values.Length; i++)
            {
                sorted[i] = values[i];
            }

            Console.Write("SORTED WITH ARRAY METHOD: ");
            foreach (double number in sorted)
            {
                Console.Write($"{number} ");
            }
        }

    }
}
