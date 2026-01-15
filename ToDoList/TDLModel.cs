using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TutorialProject.ToDoList
{
    [Table("User")]
    internal class TDLModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int description { get; set; }
    }
}
