using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroApp.Logic
{
    public class FarmsCollection : CollectionBase
    {
        private List<Farm> farmsList;

        public List<Farm> getFarmsList()
        {
            return farmsList;
        }

        public FarmsCollection() 
        {
            farmsList = databaseOperator.getFarms(user.Id);
        }
    }
}
