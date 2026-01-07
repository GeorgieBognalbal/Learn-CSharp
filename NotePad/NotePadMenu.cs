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

            if (!File.Exists(filePath)) // just in case json file is missing :)
            {
                Console.Clear();
                Console.WriteLine(@"NO NOTES FOUND CREATE A 'NoteDB.json' file on NotePad Folder, Copy the path and paste it in > filePath");
                Console.ReadKey();
                return;
            }

            string json = File.ReadAllText(filePath);
            List<NoteElements> notes = JsonSerializer.Deserialize<List<NoteElements>>(json);

            if (notes == null || notes.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("NO NOTES FOUND PRESS ANY KEY TO ADD NOTES...");
                Console.ReadKey();
                pad.TakeNotes();
            }

            int selectedIndex = 0;

            List<object> notesSaved = new List<object>(); // the note count and title is stored here <---- will be used for DisplayMenu

            // to save the title and count to the list
            LoadMenu(notes, notesSaved);

            while (notesSaved.Count > 0)
            {
                Console.Clear();

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

                if (key == ConsoleKey.A)
                {
                    pad.TakeNotes();
                }

                if (key == ConsoleKey.X)
                {
                    DeleteNoteAt(filePath, selectedIndex, notes, notesSaved);
                }

                if (key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.WriteLine(notes[selectedIndex]);
                    Console.ReadKey();
                }
            }
        }

        public void DrawMenu(List<object> list, int selectedIndex)
        {
            Console.WriteLine("\n--- Saved Notes ------------------------------- 'A' add  -  'D' delete\n");

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

        public void LoadMenu(List<NoteElements> notes, List<Object> notesSaved)
        {
            for (int i = 0; i < notes.Count; i++)
            {
                var notesInfo = $"{i + 1} : {notes[i].title}";
                notesSaved.Add(notesInfo);
            }

        }

        public void DeleteNoteAt(string filePath, int selectedIndex, List<NoteElements> mainList, List<object> menuList)
        {
            if (selectedIndex >= 0 && selectedIndex < mainList.Count)
            {
                mainList.RemoveAt(selectedIndex);
                menuList.RemoveAt(selectedIndex);

                for (int i = 0; i < menuList.Count; i++)
                {
                    menuList[i] = $"{i + 1}";
                }

                string editedJsonNotes = JsonSerializer.Serialize(mainList, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, editedJsonNotes);
                DisplayNotes();
            }
        }

    }
}