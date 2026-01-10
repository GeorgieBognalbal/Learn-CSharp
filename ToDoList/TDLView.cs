using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialProject.ToDoList
{
    public class TDLView
    {
        public Style style = new Style();
        public void display()
        {
            style.loginPage();

            Console.CursorVisible = true;

            Console.SetCursorPosition(46, 15);
            Console.ReadLine();

            Console.SetCursorPosition(46, 18);
            Console.ReadLine();
        }
    }
}
