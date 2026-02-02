using System;
using System.Threading.Tasks;
using CSTestGround.NotePad;
using CSTestGround.Sorting;
using CSTestGround.Weather;
using TutorialProject;
using TutorialProject.Gemini;
using TutorialProject.ToDoList;
using TutorialProject.Collision;

namespace CSTestGround.MainMenu
{
    class Menu
    {
        public NotePadMenu notePad = new NotePadMenu();
        public GetWeather weather = new GetWeather();
        public Sort sort = new Sort();
        public TDLView toDoList = new TDLView();
        public DBtest dBtest = new DBtest();
        public Manager gemini = new Manager();
        public Movement collision = new Movement();
        public async Task Start()
        {
            string[] options =
            {
            "NotePad",
            "Weather",
            "Sort",
            "To Do List (Test)",
            "DBconnect (test)",
            "Gemini",
            "Collision",
            };

            int selectedIndex = 0;
            Console.CursorVisible = false;

            while (true)
            {
                DrawMenu(options, selectedIndex);

                ConsoleKey key = Console.ReadKey().Key;

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
                    if (selectedIndex == 0) notePad.DisplayNotes();

                    //Weather
                    if (selectedIndex == 1) weather.Display();

                    //Sort
                    if (selectedIndex == 2) sort.start();

                    //To Do List (testing With MySQL)
                    if (selectedIndex == 3) toDoList.display();

                    //MySQL test connection
                    if (selectedIndex == 4) dBtest.dbConnection();

                    //Gemini
                    if (selectedIndex == 5) gemini.Start();

                    //Collision 
                    if (selectedIndex == 6) collision.Start();

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