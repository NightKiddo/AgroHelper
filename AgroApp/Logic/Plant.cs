using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroApp.Logic
{
    public class Plant
    {
        private int id;
        private string name;
        private PlantType type;

        public Plant(int id, string name, PlantType type)
        {
            this.Id = id;
            this.Name = name;
            this.Type = type;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public PlantType Type { get => type; set => type = value; }
    }
}
