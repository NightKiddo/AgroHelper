using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroApp.Logic
{
    internal class Resource
    {
        private int id;
        private int type;
        private Storage storage;
        private float amount;

        public Resource(int id, int type, Storage storage, float amount)
        {
            this.Id = id;
            this.Type = type;
            this.Storage = storage;
            this.Amount = amount;
        }

        public int Id { get => id; set => id = value; }
        public int Type { get => type; set => type = value; }
        public float Amount { get => amount; set => amount = value; }
        internal Storage Storage { get => storage; set => storage = value; }
    }
}
