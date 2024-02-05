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
        private float amount;

        public Resource(int id, string name, ResourceType type, float amount)
        {
            this.Id = id;
            this.name = name;
            this.Type = type;
            this.Amount = amount;
        }

        public int Id { get => id; set => id = value; }
        public ResourceType Type { get => type; set => type = value; }
        public float Amount { get => amount; set => amount = value; }
    }
}
