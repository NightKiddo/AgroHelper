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
        private MachineType type;
        private DateTime inspection_date;
        private double fuel;

        public Machine(int id, string name, int mileage, MachineType type, DateTime inspection_date, double fuel)
        {
            this.Id = id;
            this.Name = name;
            this.Mileage = mileage;
            this.Type = type;
            this.Inspection_date = inspection_date;
            this.Fuel = fuel;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get { return name.ToUpper(); } set => name = value; }
        public int Mileage { get => mileage; set => mileage = value; }
        public MachineType Type { get => type; set => type = value; }
        public DateTime Inspection_date { get => inspection_date; set => inspection_date = value; }
        public double Fuel
        {
            get => fuel;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Paliwo nie może być mniejsze od 0");
                }
                else
                {
                    fuel = value;
                }
            }
        }

        public override string ToString()
        {
            return "Nazwa: " + name + ", Typ: " + type.Type + ", Przebieg: " + mileage + " mth, Stan paliwa: " + fuel + " L, Data przeglądu: " + inspection_date.ToString("dd-MM-yyyy");
        }
    }
}
