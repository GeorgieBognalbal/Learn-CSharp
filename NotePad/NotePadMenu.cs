using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CSTestGround.NotePad
{
    public class NotePadMenu
    {
        public NotePadData pad = new NotePadData();
        public void DisplayNotes()
        {

            string filePath = @"C:\Users\Georgie\source\repos\Learn-CSharp\NotePad\NotesDB.json";

            if (!File.Exists(filePath))
            {
                Console.WriteLine(@"NO NOTES FOUND CREATE A 'NoteDB.json' file on NotePad Folder, Copy the path and paste it in > filePath");
                Console.ReadKey();
                return;
            }

            string json = File.ReadAllText(filePath);

            List<NoteElements> notes = JsonSerializer.Deserialize<List<NoteElements>>(json);
            if (notes == null || notes.Count == 0)
            {
                Console.WriteLine("NO NOTES FOUND");
                pad.TakeNotes();
            }

            Console.Clear();

            Console.WriteLine("\n--- Saved Notes ---                                                PRESS 'A' to add notes");
            foreach (var note in notes)
            {
                Console.WriteLine(note.ToString());
                Console.WriteLine("-----------------------------------------------------------------------------------------");
            }

            var key = Console.ReadKey();

            if (key.Key == ConsoleKey.A)
            {
                pad.TakeNotes();
            }
        }
    }
}