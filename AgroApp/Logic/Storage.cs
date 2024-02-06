using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroApp.Logic
{
    public class Storage
    {
        private int id;
        private string name;
        private List<Resource> resourcesList;
        public Storage(int id, string name)
        {
            this.Id = id;
            this.Name = name;            
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        internal List<Resource> ResourcesList { get => resourcesList; set => resourcesList = value; }
    }
}
