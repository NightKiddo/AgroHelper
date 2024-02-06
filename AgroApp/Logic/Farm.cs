using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroApp.Logic
{
    public class Farm : ClassBase
    {
        private int id;
        private string name;
        private List<Field> fieldsList;
        private List<Garage> garagesList;
        private List<Storage> storagesList;
        private Journal journal;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public List<Field> FieldsList { get => fieldsList; set => databaseOperator.getFields(this); }
        public List<Garage> GaragesList { get => garagesList; set => databaseOperator.getGarages(this); }
        public List<Storage> StoragesList { get => storagesList; set => databaseOperator.getStorages(this); }
        public Journal Journal { get => journal; set => journal = value; }

        public List<Machine> getAllMachines()
        {
            List<Machine> allMachines = new List<Machine>();

            foreach(Garage g in GaragesList)
            {
                foreach(Machine m in g.MachinesList)
                {
                    allMachines.Add(m);
                }                
            }

            return allMachines;
        }

        public List<Tool> getAllTools()
        {
            List<Tool> allTools = new List<Tool>();

            foreach(Garage g in GaragesList)
            {
                foreach(Tool t in g.ToolsList)
                {
                    allTools.Add(t);
                }
            }

            return allTools;
        }

        public Farm(int id, string name)
        {
            this.Id = id;
            this.Name = name;

            Journal.ActivitiesList = databaseOperator.getActivities(this);
            Journal.NotesList = databaseOperator.getNotes(this);
        }
    }
}
