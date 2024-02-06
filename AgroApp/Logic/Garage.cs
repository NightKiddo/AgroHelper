using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroApp.Logic
{
    public class Garage
    {
        private int id;
        private string name;
        private List<Machine> machinesList;
        private List<Tool> toolsList;

        public Garage(int id, string name)
        {
            this.Id = id;
            this.Name = name;            
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public List<Machine> MachinesList { get => machinesList; set => machinesList = value; }
        public List<Tool> ToolsList { get => toolsList; set => toolsList = value; }
    }
}
