using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroApp.Logic
{
    internal class Tool
    {
        private int id;
        private string name;
        private Garage garage;
        private int mileage;
        private int type;

        public Tool(int id, string name, Garage garage, int mileage, int type)
        {
            this.Id = id;
            this.Name = name;
            this.Garage = garage;
            this.Mileage = mileage;
            this.Type = type;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Mileage { get => mileage; set => mileage = value; }
        public int Type { get => type; set => type = value; }
        internal Garage Garage { get => garage; set => garage = value; }
    }
}
