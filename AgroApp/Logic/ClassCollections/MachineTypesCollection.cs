using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroApp.Logic
{
    public class MachineTypesCollection : CollectionBase
    {
        private List<MachineType> machineTypesList;

        public List<MachineType> getMachineTypesList()
        {
            return machineTypesList;
        }

        public MachineTypesCollection() 
        {
            machineTypesList = databaseOperator.getMachineTypes();
        }
    }
}
