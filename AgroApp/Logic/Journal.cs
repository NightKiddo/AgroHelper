using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroApp.Logic
{
    internal class Journal
    {
        private int id;
        private Farm farm;

        public Journal(int id, Farm farm)
        {
            this.Id = id;
            this.Farm = farm;
        }

        public int Id { get => id; set => id = value; }
        internal Farm Farm { get => farm; set => farm = value; }
    }
}
