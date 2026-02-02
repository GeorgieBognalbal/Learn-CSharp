using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialProject.Collision
{
    public class Movement
    {
        public void Start()
        {
            int x = 20, y = 10;
            
            while (true)
            {
                Console.Clear();

                Console.SetCursorPosition(x, y);
                Console.Write("O");

                var key = Console.ReadKey().Key;

                if (key == ConsoleKey.UpArrow) y--;
                if (key == ConsoleKey.DownArrow) y++;
                if (key == ConsoleKey.LeftArrow) x--;
                if (key == ConsoleKey.RightArrow) x++;

            }
        }
    }
}


public class Solution
{
    public int RomanToInt(string s)
    {

        string[] symbol = {"I", "V", "X", "L", "C", "M"};
        int index = Array.IndexOf(symbol,s);

        return -1;
    }

    public void start()
    {
        Console.Write("Enter Roman Numeral: ");
        var input = Console.ReadLine();

        int result = RomanToInt(input);

        if(result == -1)
        {
            Console.WriteLine($"Invalid Roman Combination Result: {result}");
        } 
        else
        {

        //Input: s = "MCMXCIV"
        //Output: 1994
        //Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.

        }


    }


}