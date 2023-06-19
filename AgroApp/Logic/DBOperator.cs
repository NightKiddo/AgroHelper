using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroApp.Logic
{
    internal class DBOperator
    {
        private string connectionString = @"Data Source=DESKTOP-JEIV910;Initial Catalog=agro;User ID=agro;Password=demo123";
        private SqlConnection conn;
        private SqlCommand command;
        private SqlDataReader dataReader;
        int a = 0;

        public void connect() {
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
