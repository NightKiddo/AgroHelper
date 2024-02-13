using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroApp.Logic
{
    public class Journal
    {
        private int id;
        private List<Activity> activitiesList;
        private List<Note> notesList;

        public Journal(int id)
        {
            this.Id = id;
        }

        public List<object[]> getJournalEntries(Farm farm)
        {
            List<object[]> journalEntries = new List<object[]>();

            for (int i = 0; i < farm.Journal.ActivitiesList.Count; i++)
            {
                Activity activity = farm.Journal.ActivitiesList[i];

                object type = "";

                if (activity.Type != null)
                {
                    type = activity.Type.Type;
                }

                object[] activityString = new object[]
                { activity.Id,
                activity.Name,
                activity.Start_date.ToString("dd/MM/yyyy"),
                activity.Finish_date.ToString("dd/MM/yyyy"),
                activity.Field.Name,
                type,
                "1"
                };

                journalEntries.Add(activityString);
            }

            for (int i = 0; i < farm.Journal.NotesList.Count; i++)
            {
                Note note = farm.Journal.NotesList[i];
                object[] noteString = new object[]
                {
                    note.Id,
                    note.Name,
                    note.Start_date.ToString("dd/MM/yyyy"),
                    note.Finish_date.ToString("dd/MM/yyyy"),
                    note.Field.Name,
                    note.Type.Type,
                    "0"
                };

                journalEntries.Add(noteString);
            }

            return journalEntries;
        }

        public int Id { get => id; set => id = value; }
        public List<Activity> ActivitiesList { get => activitiesList; set => activitiesList = value; }
        internal List<Note> NotesList { get => notesList; set => notesList = value; }
    }
}
