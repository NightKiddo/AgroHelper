using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroApp.Logic
{
    public class CollectionBase
    {
        internal DBOperator databaseOperator = new DBOperator();
        internal User user;
        
        public CollectionBase()
        {
            user = databaseOperator.user;
        }
    }
}
