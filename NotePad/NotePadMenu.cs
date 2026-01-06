using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Channels;
using System.Threading.Tasks;
using TutorialProject;

namespace CSTestGround.NotePad
{
    public class NotePadMenu
    {
        public NotePadData pad = new NotePadData();
        public Style style = new Style();
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

            int selectedIndex = 0;

            List<object> notesSaved = new List<object>(); // the note count and title is stored here <---- will be used for DisplayMenu

            // to save the title and count to the list
            foreach (var note in notes)
            {
                var notesInfo = $"{notes.Count} : {note.title}";
                notesSaved.Add(notesInfo);
            }

            DrawMenu(notesSaved, selectedIndex);

            var key = Console.ReadKey().Key;

            if (key == ConsoleKey.DownArrow)
            {
                selectedIndex++;
            }

            if (key == ConsoleKey.UpArrow)
            {
                selectedIndex--;
            }

            if (key == ConsoleKey.Enter)
            {
                Console.Clear();
                if (selectedIndex == 0)
                {
                    Console.WriteLine(notes[0]);
                    Console.ReadKey();
                }
            }
        }

        public void DrawMenu(List<object> list, int selectedIndex)
        {
            Console.WriteLine("\n--- Saved Notes ---\n");

            for (int i = 0; i < list.Count; i++)
            {
                if (i == selectedIndex)
                {
                    Console.WriteLine(style.GREEN + list[i] + style.RESET);
                }
                else
                {
                    Console.WriteLine(list[i]);
                }
            }
        }

        
    }
}