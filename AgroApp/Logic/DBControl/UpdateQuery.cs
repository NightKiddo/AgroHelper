using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroApp.Logic.DBControl
{
    public class UpdateQuery
    {
        private string query;
        private string tableName;
        private List<string> columns;
        private List<object> values;
        private int id;

        public string getQuery()
        {
            return query;
        }

        public string constructQuery()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("UPDATE ");
            builder.Append(tableName);
            builder.Append(" SET ");

            for(int i=0; i<columns.Count; i++)
            {
                builder.Append(columns[i]);
                builder.Append(" = ");
                if (values[i].GetType() == typeof(string))
                {
                    builder.Append("'");
                    builder.Append(values[i]);
                    builder.Append("'");                    
                }
                else if (values[i].GetType() == typeof(decimal))
                {
                    var value = values[i].ToString();
                    string v = value.Replace(',', '.');
                    builder.Append(v);
                }
                else
                {
                    builder.Append(values[i]);
                }
                
                builder.Append(", ");
            }

            builder.Remove(builder.Length - 2, 2);
            builder.Append(" WHERE id = ");
            builder.Append(id.ToString());
            builder.Append(';');


            return builder.ToString();
        }

        public UpdateQuery(string tableName, List<string> columns, List<object> values,int id)
        {
            this.tableName = tableName;
            this.columns = columns;
            this.values = values;
            this.id = id;
            this.query = constructQuery();
        }

        public UpdateQuery(string tableName, string column, decimal value, int id)
        {
            this.query = "UPDATE " + tableName + " SET " + column + " = " + value + " WHERE id = " + id;
        }
    }
}
