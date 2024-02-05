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
        private User user;
        private List<Field> fieldsList;
        private List<Garage> garagesList;
        private List<Storage> storagesList;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public User User { get => user; set => user = value; }
        public List<Field> FieldsList { get => fieldsList; set => databaseOperator.getFields(this); }
        public List<Garage> GaragesList { get => garagesList; set => databaseOperator.getGarages(this); }
        public List<Storage> StoragesList { get => storagesList; set => databaseOperator.getStorages(this); }

        public Farm(int id, string name, User user)
        {
            this.Id = id;
            this.Name = name;
            this.User = user;            
        }
    }
}
