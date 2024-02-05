using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroApp.Logic
{
    public class InsertQuery
    {
        private string tableName;
        private string columns;
        private string values;
        private string query;

        public string getQuery()
        {
            return query;
        }
        public InsertQuery(string tableName, string columns, string values)
        {
            this.tableName = tableName;
            this.columns = columns;
            this.values = values;
            this.query = "INSERT INTO " + tableName + " (" + columns + ") VALUES (" + values + ")";
        }

        public InsertQuery(string tableName, string columns, string values, string columnToOutput)
        {
            this.tableName = tableName;
            this.columns = columns;
            this.values = values;
            this.query = "INSERT INTO " + tableName + " (" + columns + ") OUTPUT INSERTED.[" + columnToOutput+"] VALUES (" + values + ")";
        }
    }
}
