using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroApp.Logic
{
    public class Tool
    {
        private int id;
        private string name;        
        private int mileage;
        private ToolType type;

        public Tool(int id, string name,int mileage, ToolType type)
        {
            this.Id = id;
            this.Name = name;            
            this.Mileage = mileage;
            this.Type = type;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Mileage { get => mileage; set => mileage = value; }
        public ToolType Type { get => type; set => type = value; }
    }
}
