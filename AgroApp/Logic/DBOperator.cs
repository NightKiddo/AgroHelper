using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
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

        public void connect() {
            connectionString = @"Data Source = " + machineName + ";Initial Catalog=agro;User ID=agro;Password=demo123";
            conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                Console.Out.WriteLine("Połączenie udane");
                conn.Close();
            }catch(Exception ex)
            {
                Console.Out.WriteLine("\nBŁĄD POŁĄCZENIA Z BAZĄ\n"+ex.ToString());
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
            string query = "SELECT id, [name] FROM Farms WHERE [user] = " + userId;
            connect();
            conn.Open();

            command = new SqlCommand(query, conn);
            dataReader = command.ExecuteReader();

            List<object[]> rows = new List<object[]>();

            while (dataReader.Read()) 
            {
                object[] row = new object[] { dataReader.GetInt32(0), dataReader.GetString(1)};
                rows.Add(row);
            }
            dataReader.Close();
            conn.Close();

            return rows;
        }

        public List<object[]> getFields(int farmId)
        {
            string query = "SELECT id, [name], [description], plant FROM Fields WHERE farm = " + farmId;
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
                if (dataReader.GetString(2) != null) 
                {
                    description = dataReader.GetString(2);
                }

                if (dataReader.GetValue(3) != DBNull.Value)
                {
                    plantId = dataReader.GetInt32(3);
                    string queryPlant = "SELECT p.[name] FROM Fields as f JOIN Plants as p ON f.plant = p.id WHERE f.plant = "+plantId+ " GROUP BY p.[name]";
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
                object[] row = new object[] { id, name, description, plantName};
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

            string query = "IF EXISTS (SELECT id FROM Users WHERE login LIKE '"+login+"' AND password LIKE '"+password+"') " +
                "BEGIN (SELECT id FROM Users WHERE login LIKE '"+login+"' AND password LIKE '"+password+"') END " +
                "ELSE BEGIN SELECT 0 END";

            string output = "";
            connect();
            conn.Open();
            command = new SqlCommand(query, conn);

            dataReader = command.ExecuteReader();

            while(dataReader.Read()){
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
            connect();
            conn.Open();
            string check = "IF EXISTS (SELECT id FROM Users WHERE login LIKE '"+login+"') " +
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

            if (checkValue == "2") {
                string query = "INSERT INTO Users(login,password) VALUES ('" + login + "','" + password + "')";
                command = new SqlCommand(query, conn);
                if (command.ExecuteNonQuery() != 0)
                {
                    a = 1;
                };
            }
            conn.Close();

            return a;
        }
    }
}
