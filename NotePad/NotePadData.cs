using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace CSTestGround.NotePad
{
    public class NoteElements
    {
        public string dateTime { get; set; }
        public string title { get; set; }
        public string description { get; set; } 
        public override string ToString()
        {
            return $"\nTime: {dateTime}\nTitle: {title}\nNote: {description}";
        }
    }
    public class NotePadData
    {
        public void TakeNotes()
        {
            NotePadMenu padMenu = new NotePadMenu();

            Console.Clear();

            Console.Write("Title: ");
            string title = Console.ReadLine();

            Console.Write("Notes: ");
            string description = Console.ReadLine();

            NoteElements noteElements = new NoteElements
            {
                dateTime = DateTime.Now.ToString("dddd, MMMM/dd/yyyy, h:mm:ss tt"),
                title = title,
                description = description
            };

            SaveNotes(noteElements);
            Console.WriteLine("Note saved successfully!");

            padMenu.DisplayNotes();
        }

        public void SaveNotes(NoteElements newNote)
        {
            string filePath = @"C:\Users\Georgie\Source\Repos\Learn-CSharp\NotePad\NotesDB.json";

            List<NoteElements> notes; // preparation for use

            if (File.Exists(filePath)) // check if the file is empty
            {
                string json = File.ReadAllText(filePath);
                if (string.IsNullOrEmpty(json))
                {
                    notes = new List<NoteElements>();
                }
                else // if not empty deserialize content
                {
                    notes = JsonSerializer.Deserialize<List<NoteElements>>(json);
                }
            }
            else
            {
                notes = new List<NoteElements>();
            }

            notes.Add(newNote);

            string updatedJson = JsonSerializer.Serialize(notes, new JsonSerializerOptions // after adding the notes -> Serialize back to json
            {
                WriteIndented = true
            });

            File.WriteAllText(filePath, updatedJson);
        }
    }
}
