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