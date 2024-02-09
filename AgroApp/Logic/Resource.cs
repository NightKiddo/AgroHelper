using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroApp.Logic
{
    public class Resource
    {
        private int id;
        private string name;
        private ResourceType type;
        private double amount;

        public Resource(int id, string name, ResourceType type, double amount)
        {
            this.Id = id;
            this.Name = name;
            this.Type = type;
            this.Amount = amount;
        }

        public override string ToString()
        {
            return Name;
        }

        public int Id { get => id; set => id = value; }
        public ResourceType Type { get => type; set => type = value; }
        public double Amount { get => amount; set => amount = value; }
        public string Name { get => name; set => name = value; }
    }
}
