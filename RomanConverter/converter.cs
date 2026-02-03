using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialProject.RomanConverter
{
    public class converter
    {
        public void start()
        {
            /*Symbol       Value
              I             1
              V             5
              X             10
              L             50
              C             100
              D             500
              M             1000*/

            Console.Write("Enter a Roman Numeral: ");
            string romanNumeral = Console.ReadLine().ToUpper();

            char[] digits = romanNumeral.ToCharArray();

            foreach (char digit in digits)
            {
                switch (digit)
                {
                    case 'I':
                        Console.WriteLine("1");
                        break;
                    case 'V':
                        Console.WriteLine("5");
                        break;
                    case 'X':
                        Console.WriteLine("10");
                        break;
                    case 'L':
                        Console.WriteLine("50");
                        break;
                    case 'C':
                        Console.WriteLine("100");
                        break;
                    case 'D':
                        Console.WriteLine("500");
                        break;
                    case 'M':
                        Console.WriteLine("1000");
                        break;
                    default:
                        Console.WriteLine("Invalid Roman Numeral");
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}
