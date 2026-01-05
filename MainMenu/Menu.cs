using System;
using CSTestGround.NotePad;

namespace CSTestGround.MainMenu
{
    class Menu
    {
        public NotePadMenu notePad = new NotePadMenu();
        public void Start()
        {
            string[] options =
            {
            "NotePad"
            };

            int selectedIndex = 0;
            Console.CursorVisible = false;

            while (true)
            {
                DrawMenu(options, selectedIndex);

                ConsoleKey key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                {
                    selectedIndex--;
                    if (selectedIndex < 0)
                    {
                        selectedIndex = options.Length - 1;
                    }
                }

                if (key == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex >= options.Length)
                    {
                        selectedIndex = 0;
                    }
                }

                if (key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    //NotePad
                    if (selectedIndex == 0)
                    {
                        notePad.DisplayNotes();
                    }

                    //-----
                    if (selectedIndex == 1)
                    {
                        //-----
                    }
                }
            }
        }

        static void DrawMenu(string[] options, int selectedIndex)
        {
            Console.Clear();
            Console.WriteLine("=== CONSOLE MENU ===\n");

            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine($"> {options[i]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"  {options[i]}");
                }
            }
        }
    }
}