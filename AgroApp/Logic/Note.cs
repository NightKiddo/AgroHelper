using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroApp.Logic
{
    public class Note
    {
        private int id;
        private string name;
        private string description;
        private NoteType type;        
        private DateTime start_date;
        private DateTime finish_date;
        private Field field;
        private double value;

        public Note(int id, string name, NoteType type, string description, DateTime start_date, DateTime finish_date, Field field, double value)
        {
            this.Id = id;
            this.Name = name;
            this.Type = type;
            this.Description = description;
            this.Start_date = start_date;
            this.Finish_date = finish_date;
            this.Field = field;
            this.Value = value;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public NoteType Type { get => type; set => type = value; }
        public string Description { get => description; set => description = value; }
        public DateTime Start_date { get => start_date; set => start_date = value; }
        public DateTime Finish_date { get => finish_date; set => finish_date = value; }
        public double Value { get => value; set => this.value = value; }
        internal Field Field { get => field; set => field = value; }
    }
}
