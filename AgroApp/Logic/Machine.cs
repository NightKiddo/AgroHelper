using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroApp.Logic
{
    public class Machine
    {
        private int id;
        private string name;
        private int mileage;
        private int type;
        private DateTime inspection_date;
        private float fuel;

        public Machine(int id, string name, int mileage, int type, DateTime inspection_date, float fuel)
        {
            this.Id = id;
            this.Name = name;
            this.Mileage = mileage;
            this.Type = type;
            this.Inspection_date = inspection_date;
            this.Fuel = fuel;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Mileage { get => mileage; set => mileage = value; }
        public int Type { get => type; set => type = value; }
        public DateTime Inspection_date { get => inspection_date; set => inspection_date = value; }
        public float Fuel { get => fuel; set => fuel = value; }
    }
}
