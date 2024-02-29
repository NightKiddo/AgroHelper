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
        private List<string> columnsToUpdate;
        private List<object> valuesToUpdate;
        private int id;


        //used when updating with only one value (for example in FormAddActivity)
        private string columnToUpdate;
        private object valueToUpdate;

        public string getQuery()
        {
            return query;
        }

        public void constructQuery(int option)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("UPDATE ");
            builder.Append(tableName);
            builder.Append(" SET ");

            if (option == 1)
            {
                for (int i = 0; i < columnsToUpdate.Count; i++)
                {
                    builder.Append(columnsToUpdate[i]);
                    builder.Append(" = ");
                    if (valuesToUpdate[i].GetType() == typeof(string))
                    {
                        builder.Append("'");
                        builder.Append(valuesToUpdate[i]);
                        builder.Append("'");
                    }
                    else if (valuesToUpdate[i].GetType() == typeof(decimal))
                    {
                        var value = valuesToUpdate[i].ToString();
                        string v = value.Replace(',', '.');
                        builder.Append(v);
                    }
                    else
                    {
                        builder.Append(valuesToUpdate[i]);
                    }

                    builder.Append(", ");
                }
            }
            else
            {
                builder.Append(columnToUpdate);
                builder.Append(" = ");

                if (valueToUpdate.GetType() == typeof(string))
                {
                    builder.Append("'");
                    builder.Append(valueToUpdate);
                    builder.Append("'");
                }
                else if (valueToUpdate.GetType() == typeof(decimal) | valueToUpdate.GetType() == typeof(double))
                {
                    var value = valueToUpdate.ToString();
                    string v = value.Replace(',', '.');
                    builder.Append(v);
                }
                else
                {
                    builder.Append(valueToUpdate);
                }

                builder.Append(", ");
            }

            builder.Remove(builder.Length - 2, 2);
            builder.Append(" WHERE id = ");
            builder.Append(id.ToString());
            builder.Append(';');


            this.query = builder.ToString();
        }

        public void setTable(string table)
        {
            this.tableName = table;
        }
        public void setColumn(string column)
        {
            this.columnToUpdate = column;
        }

        public void setValue(object value)
        {
            this.valueToUpdate = value;
        }

        public void setId(int id)
        {
            this.id = id;
        }
        public UpdateQuery(string tableName, List<string> columns, List<object> values, int id)
        {
            this.tableName = tableName;
            this.columnsToUpdate = columns;
            this.valuesToUpdate = values;
            this.id = id;
            constructQuery(1);
        }

        public UpdateQuery()
        {

        }
    }
}
