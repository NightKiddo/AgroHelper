using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace AgroApp.Logic
{
    internal class DBOperator
    {
        private string machineName = Environment.MachineName;
        private string connectionString;
        private SqlConnection conn;
        private SqlCommand command;
        private SqlDataReader dataReader;
        int a = 0;

        public void connect()
        {
            connectionString = @"Data Source = " + machineName + ";Initial Catalog=agro;User ID=agro;Password=demo123";
            conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                Console.Out.WriteLine("Połączenie udane");
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("\nBŁĄD POŁĄCZENIA Z BAZĄ\n" + ex.ToString());
                MessageBox.Show("Nie można połączyć z bazą!");
            }
        }
        public SqlConnection getConn()
        {
            return conn;
        }

        public SqlCommand getCommand()
        {
            return command;
        }
        public int insert(InsertQuery query)
        {
            a = 0;

            connect();
            conn.Open();
            command = new SqlCommand(query.getQuery(), conn);

            if (command.ExecuteNonQuery() != 0)
            {
                a = 1;
            }

            conn.Close();
            return a;
        }

        public int insertWithIdOutput(InsertQuery query)
        {
            int output = 0;
            connect();
            conn.Open();

            command = new SqlCommand(query.getQuery(), conn);

            dataReader = command.ExecuteReader();

            if (dataReader.HasRows)
            {
                dataReader.Read();
                output = dataReader.GetInt32(0);
            }

            dataReader.Close();
            return output;
        }

        public object select(string query)
        {
            connect();
            conn.Open();

            command = new SqlCommand(query, conn);
            dataReader = command.ExecuteReader();

            string output = "";

            while (dataReader.Read())
            {
                output = output + dataReader.GetValue(0);
            }

            conn.Close();
            return output;

        }

        public List<object[]> getFarms(int userId)
        {
            string query = "SELECT * FROM farmsView" + userId;
            connect();
            conn.Open();

            command = new SqlCommand(query, conn);
            dataReader = command.ExecuteReader();

            List<object[]> rows = new List<object[]>();

            while (dataReader.Read())
            {
                object[] row = new object[] { dataReader.GetInt32(0), dataReader.GetString(1) };
                rows.Add(row);
            }
            dataReader.Close();
            conn.Close();

            return rows;
        }

        public List<object[]> getFields(int farmId, int userId)
        {
            string query = "SELECT * FROM fieldsView" + userId + " WHERE farm = " + farmId;
            connect();
            conn.Open();

            command = new SqlCommand(query, conn);
            dataReader = command.ExecuteReader();

            List<object[]> rows = new List<object[]>();

            while (dataReader.Read())
            {
                int id = dataReader.GetInt32(0);
                string name = dataReader.GetString(1);
                string description = "";
                int plantId = 0;
                string plantName = "";
                if (dataReader.GetValue(2) != DBNull.Value)
                {
                    description = dataReader.GetString(2);
                }

                if (dataReader.GetValue(3) != DBNull.Value)
                {
                    plantId = dataReader.GetInt32(3);
                    string queryPlant = "SELECT p.[name] FROM Fields as f JOIN Plants as p ON f.plant = p.id WHERE f.plant = " + plantId + " GROUP BY p.[name]";
                    SqlConnection conn2 = new SqlConnection(connectionString);
                    SqlCommand command2 = new SqlCommand(queryPlant, conn2);
                    conn2.Open();
                    SqlDataReader dataReader2 = command2.ExecuteReader();
                    while (dataReader2.Read())
                    {
                        plantName = dataReader2.GetString(0);
                    }
                    dataReader2.Close();
                    conn2.Close();
                }
                object[] row = new object[] { id, name, description, plantName };
                rows.Add(row);
            }


            dataReader.Close();
            conn.Close();

            return rows;
        }

        public List<object[]> getPlants()
        {
            string query = "SELECT id, [name] FROM Plants";
            connect();
            conn.Open();

            command = new SqlCommand(query, conn);
            dataReader = command.ExecuteReader();

            List<object[]> rows = new List<object[]>();
            while (dataReader.Read())
            {
                object[] row = new object[] { dataReader.GetInt32(0), dataReader.GetString(1) };
                rows.Add(row);
            }
            dataReader.Close();
            conn.Close();

            return rows;
        }

        public List<object[]> getMachineTypes()
        {
            string query = "SELECT id, type FROM Machine_types";
            connect();
            conn.Open();

            command = new SqlCommand(query, conn);
            dataReader = command.ExecuteReader();

            List<object[]> rows = new List<object[]>();
            while (dataReader.Read())
            {
                object[] row = new object[] { dataReader.GetInt32(0), dataReader.GetString(1) };
                rows.Add(row);
            }
            dataReader.Close();
            conn.Close();

            return rows;
        }

        public List<object[]> getToolTypes()
        {
            string query = "SELECT id, type FROM Tool_types";
            connect();
            conn.Open();

            command = new SqlCommand(query, conn);
            dataReader = command.ExecuteReader();

            List<object[]> rows = new List<object[]>();
            while (dataReader.Read())
            {
                object[] row = new object[] { dataReader.GetInt32(0), dataReader.GetString(1) };
                rows.Add(row);
            }
            dataReader.Close();
            conn.Close();

            return rows;
        }

        public List<object[]> getResourceTypes()
        {
            string query = "SELECT id, type FROM Resource_types";
            connect();
            conn.Open();

            command = new SqlCommand(query, conn);
            dataReader = command.ExecuteReader();

            List<object[]> rows = new List<object[]>();
            while (dataReader.Read())
            {
                object[] row = new object[] { dataReader.GetInt32(0), dataReader.GetString(1) };
                rows.Add(row);
            }
            dataReader.Close();
            conn.Close();

            return rows;
        }

        public List<object[]> getActivityTypes()
        {
            string query = "SELECT id, type FROM Activity_types";
            connect();
            conn.Open();

            command = new SqlCommand(query, conn);
            dataReader = command.ExecuteReader();

            List<object[]> rows = new List<object[]>();
            while (dataReader.Read())
            {
                object[] row = new object[] { dataReader.GetInt32(0), dataReader.GetString(1) };
                rows.Add(row);
            }
            dataReader.Close();
            conn.Close();

            return rows;

        }

        public List<object[]> getNoteTypes()
        {
            string query = "SELECT id, type FROM Note_types";
            connect();
            conn.Open();

            command = new SqlCommand(query, conn);
            dataReader = command.ExecuteReader();

            List<object[]> rows = new List<object[]>();
            while (dataReader.Read())
            {
                object[] row = new object[] { dataReader.GetInt32(0), dataReader.GetString(1) };
                rows.Add(row);
            }
            dataReader.Close();
            conn.Close();

            return rows;

        }

        public List<object[]> getGarages(int farmId, int userId)
        {
            string query = "SELECT * FROM garagesView"+userId + " WHERE farm = " + farmId;
            connect();
            conn.Open();

            command = new SqlCommand(query, conn);
            dataReader = command.ExecuteReader();

            List<object[]> rows = new List<object[]>();
            while (dataReader.Read())
            {
                object[] row = new object[] { dataReader.GetInt32(0), dataReader.GetString(1) };
                rows.Add(row);
            }
            dataReader.Close();
            conn.Close();

            return rows;
        }

        public List<object[]> getStorages(int farmId, int userId)
        {
            string query = "SELECT * FROM storagesView" + userId + " WHERE Farm = " + farmId;
            connect();
            conn.Open();

            command = new SqlCommand(query, conn);
            dataReader = command.ExecuteReader();

            List<object[]> rows = new List<object[]>();
            while (dataReader.Read())
            {
                object[] row = new object[] { dataReader.GetInt32(0), dataReader.GetString(1) };
                rows.Add(row);
            }
            dataReader.Close();
            conn.Close();


            return rows;
        }

        public List<object[]> getMachines(int garageId, int userId)
        {
            string queryMachines = "SELECT * FROM machinesView" + userId + " WHERE garage = " + garageId;

            connect();
            conn.Open();

            command = new SqlCommand(queryMachines, conn);
            dataReader = command.ExecuteReader();

            List<object[]> rows = new List<object[]>();
            object[] row;

            while (dataReader.Read())
            {

                if (dataReader.GetValue(4) != DBNull.Value)
                {
                    DateTime inspection = DateTime.Parse(dataReader.GetValue(4).ToString());

                    row = new object[] { dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetInt32(2), dataReader.GetString(3), inspection.ToString("dd/MM/yyyy"), dataReader.GetValue(5) };
                    rows.Add(row);
                }
                else
                {
                    row = new object[] { dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetInt32(2), dataReader.GetString(3), String.Empty, dataReader.GetValue(5) };
                    rows.Add(row);
                }
            }


            dataReader.Close();
            conn.Close();


            return rows;
        }

        public List<object[]> getMachines()
        {
            string query = "SELECT id, name FROM Machines";

            connect();
            conn.Open();

            command = new SqlCommand(query, conn);
            dataReader = command.ExecuteReader();

            List<object[]> rows = new List<object[]>();
            object[] row;

            while (dataReader.Read())
            {
                row = new object[] { dataReader.GetInt32(0), dataReader.GetString(1) };
                rows.Add(row);
            }

            return rows;
        }

        public List<object[]> getTools(int garageId)
        {
            string queryTools = "SELECT t.id,t.name,t.mileage,tt.type FROM Tools as t JOIN Tool_types as tt on t.type = tt.id WHERE t.garage = " + garageId;

            connect();
            conn.Open();

            command = new SqlCommand(queryTools, conn);
            dataReader = command.ExecuteReader();

            List<object[]> rows = new List<object[]>();
            while (dataReader.Read())
            {
                object[] row;
                row = new object[] { dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetInt32(2), dataReader.GetString(3) };
                rows.Add(row);
            }
            dataReader.Close();
            conn.Close();


            return rows;
        }

        public List<object[]> getTools()
        {
            string queryTools = "SELECT id, name FROM Tools";

            connect();
            conn.Open();

            command = new SqlCommand(queryTools, conn);
            dataReader = command.ExecuteReader();

            List<object[]> rows = new List<object[]>();
            while (dataReader.Read())
            {
                object[] row;
                row = new object[] { dataReader.GetInt32(0), dataReader.GetString(1) };
                rows.Add(row);
            }
            dataReader.Close();
            conn.Close();


            return rows;
        }

        public List<object[]> getResources(int storageId)
        {
            string query = "SELECT r.id, r.type, rt.type, r.amount FROM Resources as r JOIN Resource_types as rt ON r.type = rt.id WHERE storage = " + storageId;

            connect();
            conn.Open();

            command = new SqlCommand(query, conn);
            dataReader = command.ExecuteReader();

            List<object[]> rows = new List<object[]>();
            while (dataReader.Read())
            {
                object[] row = new object[] { dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetValue(3) };
                rows.Add(row);
            }
            dataReader.Close();
            conn.Close();


            return rows;
        }

        public List<object[]> getJournalEntries(int journalId)
        {
            string queryActivities = "SELECT " +
                "a.id, 1, a.name, a.start_date, a.finish_date, f.name, at.type " +
                "FROM Activities as a " +
                "JOIN Fields as f ON a.field = f.id " +
                "JOIN Journals as j on a.journal = j.id " +
                "JOIN Activity_types as at ON a.type = at.id " +
                "WHERE j.id = " + journalId;
            string queryNotes = "SELECT " +
                "n.id, 0, n.name, n.start_date, n.finish_date, f.name, nt.type " +
                "FROM Notes as n " +
                "JOIN Fields as f ON n.field = f.id " +
                "JOIN Journals as j on n.journal = j.id " +
                "JOIN Note_types as nt ON n.type = nt.id " +
                "WHERE j.id = " + journalId;

            connect();
            conn.Open();

            command = new SqlCommand(queryActivities, conn);
            dataReader = command.ExecuteReader();

            List<object[]> rows = new List<object[]>();

            while (dataReader.Read())
            {
                DateTime start = DateTime.Parse(dataReader.GetValue(3).ToString());
                DateTime finish = DateTime.Parse(dataReader.GetValue(4).ToString());
                object[] row = new object[] { dataReader.GetInt32(0), dataReader.GetInt32(1), dataReader.GetString(2), start.ToString("dd/MM/yyyy"), finish.ToString("dd/MM/yyyy"), dataReader.GetString(5), dataReader.GetString(6) };
                rows.Add(row);
            }

            dataReader.Close();

            command = new SqlCommand(queryNotes, conn);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {

                DateTime start = DateTime.Parse(dataReader.GetValue(3).ToString());
                DateTime finish = DateTime.Parse(dataReader.GetValue(4).ToString());
                object[] row = new object[] { dataReader.GetInt32(0), dataReader.GetInt32(1), dataReader.GetString(2), start.ToString("dd/MM/yyyy"), finish.ToString("dd/MM/yyyy"), dataReader.GetString(5), dataReader.GetString(6) };
                rows.Add(row);
            }

            dataReader.Close();
            conn.Close();

            return rows;
        }

        public List<object[]> getEmployees(int userId)
        {
            string query = "SELECT * FROM employeesView" + userId;

            connect();
            conn.Open();

            command = new SqlCommand(query, conn);
            dataReader = command.ExecuteReader();

            List<object[]> rows = new List<object[]>();
            while (dataReader.Read())
            {
                object[] row = new object[] { dataReader.GetInt32(0), dataReader.GetString(1) };
                rows.Add(row);
            }
            dataReader.Close();
            conn.Close();


            return rows;
        }

        public object[] getActivity(int activityId)
        {
            string query = "SELECT name, description, start_date, finish_date, field, type, employee, machine, tool FROM Activities WHERE id = " + activityId;
            connect();
            conn.Open();

            command = new SqlCommand(query, conn);
            dataReader = command.ExecuteReader();

            object[] row = new object[0];

            while (dataReader.Read())
            {
                row = new object[] { dataReader.GetString(0), dataReader.GetString(1), dataReader.GetValue(2), dataReader.GetValue(3), dataReader.GetInt32(4), dataReader.GetInt32(5), dataReader.GetValue(6), dataReader.GetValue(7), dataReader.GetValue(8) };
            }

            dataReader.Close();
            conn.Close();

            return row;
        }

        public object[] getNote(int noteId)
        {
            string query = "SELECT name, description, start_date, finish_date, field FROM Notes WHERE id = " + noteId;
            connect();
            conn.Open();

            command = new SqlCommand(query, conn);
            dataReader = command.ExecuteReader();

            object[] row = new object[0];

            while (dataReader.Read())
            {
                row = new object[] { dataReader.GetString(0), dataReader.GetString(1), dataReader.GetValue(2), dataReader.GetValue(3), dataReader.GetInt32(4) };
            }

            dataReader.Close();
            conn.Close();

            return row;
        }

        public object[,] getChartValues(int fieldId, int valueType, int valueTypeId, DateTime startDate, DateTime finishDate)
        {
            int rowCount = 0;

            string dateFormat = "yyyy-MM-dd";

            DateTime dateParse = DateTime.ParseExact(startDate.ToString(), "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            string startDateString = dateParse.ToString(dateFormat);


            dateParse = DateTime.ParseExact(finishDate.ToString(), "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            string finishDateString = dateParse.ToString(dateFormat);

            string queryCount = "SELECT COUNT(*) FROM Activities WHERE field = " + fieldId + " AND start_date BETWEEN '" + startDateString + "' AND '" + finishDateString + "'";

            Int32.TryParse((string)select(queryCount), out rowCount);

            if (rowCount != 0)
            {

                object[,] values = new object[rowCount, 2];

                connect();
                conn.Open();

                string query = "";

                if (valueType == 1)
                {
                    query = "SELECT finish_date, value FROM Notes WHERE field = " + fieldId + " AND type = " + valueTypeId + " AND start_date BETWEEN '" + startDateString + "' AND '" + finishDateString + "'";
                }
                else
                {
                    query = "SELECT finish_date, value FROM Activities WHERE field = " + fieldId + " AND type = " + valueTypeId + " AND start_date BETWEEN '" + startDateString + "' AND '" + finishDateString + "'";
                }

                command = new SqlCommand(query, conn);
                dataReader = command.ExecuteReader();

                int i = 0;

                while (dataReader.Read())
                {
                    values[i, 0] = dataReader.GetValue(0);
                    values[i, 1] = dataReader.GetValue(1);
                    i++;
                }

                return values;
            }
            else
            {
                return null;
            }
        }

        public int delete(DeleteQuery query)
        {
            a = 0;

            connect();
            conn.Open();
            command = new SqlCommand(query.getQuery(), conn);

            if (command.ExecuteNonQuery() != 0)
            {
                a = 1;
            }

            conn.Close();
            return a;
        }

        public SqlDataReader getReader()
        {
            return dataReader;
        }
        public int login(string login, string password)
        {
            a = 0;

            string query = "IF EXISTS (SELECT id FROM Users WHERE login LIKE '" + login + "' AND password LIKE '" + password + "') " +
                "BEGIN (SELECT id FROM Users WHERE login LIKE '" + login + "' AND password LIKE '" + password + "') END " +
                "ELSE BEGIN SELECT 0 END";

            string output = "";
            connect();
            conn.Open();
            command = new SqlCommand(query, conn);

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                output += dataReader.GetValue(0);

                if (output == "0")
                {
                    MessageBox.Show("Błąd logowania!");
                    break;
                }
                else
                {
                    MessageBox.Show("Zalogowano pomyślnie");
                }
            }

            dataReader.Close();
            conn.Close();

            int.TryParse(output, out a);

            return a;
        }

        public int register(string login, string password)
        {
            a = 0;
            int userId = 0;
            connect();
            conn.Open();
            string check = "IF EXISTS (SELECT id FROM Users WHERE login LIKE '" + login + "') " +
                "BEGIN SELECT 1 END " +
                "ELSE BEGIN SELECT 2 END";
            string checkValue = "";
            command = new SqlCommand(check, conn);
            dataReader = command.ExecuteReader();


            while (dataReader.Read())
            {
                checkValue += dataReader.GetValue(0);
            }

            dataReader.Close();

            if (checkValue == "2")
            {
                string values = "'" + login + "', '" + password + "'";
                InsertQuery insertQuery = new InsertQuery("Users", "login,password", values, "id");
                userId = insertWithIdOutput(insertQuery);
                a = 1;

                //tworzenie wszystkich widokow dla uzytkownika

                string createView = "CREATE VIEW farmsView" + userId + " AS SELECT id, [name] FROM Farms WHERE [user] = " + userId;
                command = new SqlCommand(createView, conn);
                command.ExecuteNonQuery();

                createView = "CREATE VIEW employeesView" + userId + " AS SELECT id, name FROM Employees WHERE [user] = " + userId;
                command = new SqlCommand(createView, conn);
                command.ExecuteNonQuery();

                createView = "CREATE VIEW fieldsview" + userId + " AS SELECT fld.id, fld.[name], fld.[description], fld.plant, fld.farm " +
                    "FROM Fields as fld JOIN Farms AS frm ON frm.id = fld.farm WHERE frm.[user] = " + userId;
                command = new SqlCommand(createView, conn);
                command.ExecuteNonQuery();

                createView = "CREATE VIEW garagesView" + userId + " AS SELECT g.id, g.[name] FROM Garages as g JOIN Farms AS frm ON frm.id = g.farm WHERE frm.[user] = " + userId;
                command = new SqlCommand(createView, conn);
                command.ExecuteNonQuery();

                createView = "CREATE VIEW storagesView" + userId + " AS SELECT s.id, s.[name] FROM Storages as s JOIN Farms AS frm ON frm.id = s.farm WHERE frm.[user] = " + userId;
                command = new SqlCommand(createView, conn);
                command.ExecuteNonQuery();

                createView = "CREATE VIEW machinesView" + userId + " AS SELECT m.id,m.garage, m.name, m.mileage, mt.type, m.inspection_date, m.fuel FROM Machines as m JOIN Machine_types as mt ON m.type = mt.id JOIN Garages as g ON m.garage = g.id JOIN Farms as f ON g.farm = f.id WHERE f.[user] =" + userId;
            }



            conn.Close();

            return a;
        }
    }
}
