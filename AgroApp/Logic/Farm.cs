using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroApp.Logic
{
    internal class Farm
    {
        private int id;
        private string name;
        private User user;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        internal User User { get => user; set => user = value; }

        public Farm(int id, string name, User user)
        {
            this.Id = id;
            this.Name = name;
            this.User = user;
        }
    }
}
