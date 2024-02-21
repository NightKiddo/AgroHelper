using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroApp.Logic
{
    public class Activity
    {
        private int id;
        private string name;
        private string description;
        private DateTime start_date;
        private DateTime finish_date;
        private ActivityType type;
        private Field field;
        private Employee employee;
        private Machine machine;
        private Tool tool;
        private Resource resource;
        private double value;

        public Activity(int id, string name, string description, DateTime start_date, DateTime finish_date, ActivityType type, Field field, Employee employee, Machine machine, Tool tool,  Resource resource, double value)
        {
            this.Id = id;
            this.Name = name;            
            this.Description = description;
            this.Start_date = start_date;
            this.Finish_date = finish_date;
            this.Type = type;
            this.Field = field;
            this.Employee = employee;
            this.Machine = machine;
            this.Tool = tool;
            this.Resource = resource;
            this.Value = value;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public DateTime Start_date { get => start_date; set => start_date = value; }
        public DateTime Finish_date { get => finish_date; set => finish_date = value; }
        public ActivityType Type { get => type; set => type = value; }
        public double Value { get => value; set => this.value = value; }
        public Resource Resource { get => resource; set => resource = value; }
        internal Field Field { get => field; set => field = value; }
        internal Employee Employee { get => employee; set => employee = value; }
        internal Machine Machine { get => machine; set => machine = value; }
        internal Tool Tool { get => tool; set => tool = value; }

    }
}
