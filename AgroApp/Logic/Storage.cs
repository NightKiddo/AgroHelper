using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroApp.Logic
{
    internal class Storage
    {
        private int id;
        private string name;
        private Farm farm;



        public Storage(int id, string name, Farm farm)
        {
            this.Id = id;
            this.Name = name;
            this.Farm = farm;            
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        internal Farm Farm { get => farm; set => farm = value; }
    }
}
