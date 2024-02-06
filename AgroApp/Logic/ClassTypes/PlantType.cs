using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroApp.Logic
{
    public class PlantType
    {
        private int id;
        private string type;

        public PlantType(int id, string type)
        {
            Id = id;
            Type = type;
        }

        public int Id { get => id; set => id = value; }
        public string Type { get => type; set => type = value; }
    }
}
