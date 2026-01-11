using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TutorialProject.ToDoList;
using WindowsInput;

namespace CSTestGround.MainMenu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();

            menu.Start();

        }
    }
}
