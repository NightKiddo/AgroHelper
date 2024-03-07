using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroApp.Logic
{
    public class DeleteQuery
    {

        private string query;

        public string getQuery()
        {
            return query;
        }

        public DeleteQuery(string tableName, string whereColumn, int whereValueInt)
        {
            this.query = "DELETE FROM " + tableName + " WHERE " + whereColumn + " = " + whereValueInt;
        }
    }
}
