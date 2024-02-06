using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public int Id { get => id; set => id = value; }
        public List<Activity> ActivitiesList { get => activitiesList; set => activitiesList = value; }
        internal List<Note> NotesList { get => notesList; set => notesList = value; }
    }
}
