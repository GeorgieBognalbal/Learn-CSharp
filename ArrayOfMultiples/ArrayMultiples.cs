using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialProject.ArrayOfMultiples
{
    internal class ArrayMultiples
    {
        public void Start()
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());
            
            Console.Write("Enter length of array: ");
            int length = int.Parse(Console.ReadLine());

            int[] multiplesArray = new int[length];

            Console.Write("ARRAY: ");
            for (int i = 0; i < multiplesArray.Length; i++)
            {
                Console.Write($"{multiplesArray[i] = number * (i + 1)}, ");
            }

            Console.WriteLine("\n\nPRESS ANYKEY TO RETURN TO MENU.....");
            Console.ReadKey();
        }
    }
}
