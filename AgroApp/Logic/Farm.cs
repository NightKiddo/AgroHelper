using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroApp.Logic
{
    public class Farm
    {
        private int id;
        private string name;
        private List<Field> fieldsList;
        private List<Garage> garagesList;
        private List<Storage> storagesList;
        private Journal journal;
        private string fieldCount, garagesCount, storagesCount;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public List<Field> FieldsList { get => fieldsList; set => fieldsList = value; }
        public List<Garage> GaragesList { get => garagesList; set => garagesList = value; }
        public List<Storage> StoragesList { get => storagesList; set => storagesList = value; }
        public Journal Journal { get => journal; set => journal = value; }
        public string FieldCount { get => fieldCount = getFieldCount(); }
        public string GaragesCount { get => garagesCount = getGaragesCount(); }
        public string StoragesCount { get => storagesCount = getStoragesCount(); }

        public List<Machine> getAllMachines()
        {
            List<Machine> allMachines = new List<Machine>();

            foreach (Garage g in GaragesList)
            {
                foreach (Machine m in g.MachinesList)
                {
                    allMachines.Add(m);
                }
            }

            return allMachines;
        }

        public List<Tool> getAllTools()
        {
            List<Tool> allTools = new List<Tool>();

            foreach (Garage g in GaragesList)
            {
                foreach (Tool t in g.ToolsList)
                {
                    allTools.Add(t);
                }
            }

            return allTools;
        }

        public List<Resource> getAllResources()
        {
            List<Resource> allResources = new List<Resource>();

            foreach (Storage s in StoragesList)
            {
                foreach (Resource r in s.ResourcesList)
                {
                    allResources.Add(r);
                }
            }

            return allResources;
        }

        private string getFieldCount()
        {
            int c = 0;
            foreach (Field f in FieldsList)
            {
                c++;
            }
            return "Ilość pól: " + c;
        }

        private string getGaragesCount()
        {
            int c = 0;
            foreach (Garage g in GaragesList)
            {
                c++;
            }
            return "Ilość garaży: " + c;
        }

        private string getStoragesCount()
        {
            int c = 0;
            foreach (Storage s in StoragesList)
            {
                c++;
            }
            return "Ilość magazynów: " + c;
        }
        public override string ToString()
        {
            return name;
        }

        public Farm(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
