using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroApp.Logic
{
    class DeleteQuery
    {
        private string tableName;
        private string whereColumn;
        private int whereValueInt;
        private string whereValueString;
        private string query;

        public string getQuery() 
        {
            return query;
        }

        public DeleteQuery(string tableName, string whereColumn, int whereValueInt)
        {
            this.tableName = tableName;
            this.whereColumn = whereColumn;
            this.whereValueInt = whereValueInt;
            this.query = "DELETE FROM "+ tableName + " WHERE " + this.whereColumn+" = " + whereValueInt;
        }

        public DeleteQuery(string tableName, string whereColumn, string whereValueString)
        {
            this.tableName = tableName;
            this.whereColumn = whereColumn;
            this.whereValueString = whereValueString;
            this.query = "DELETE FROM " + tableName + " WHERE " + this.whereColumn + " LIKE '" + whereValueInt+"'";
        }
    }
}
