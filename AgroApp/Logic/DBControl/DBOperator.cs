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
    public class DBOperator
    {
        private string machineName = Environment.MachineName;
        private string connectionString;
        private SqlConnection conn;
        private SqlCommand command;
        private SqlDataReader dataReader;
        int a = 0;

        internal User user;
        private PlantsCollection plantsCollection = new PlantsCollection();
        private MachineTypesCollection machineTypesCollection = new MachineTypesCollection();
        private ToolTypesCollection toolTypesCollection = new ToolTypesCollection();
        private ResourceTypesCollection resourceTypesCollection = new ResourceTypesCollection();
        private ActivityTypesCollection activityTypesCollection = new ActivityTypesCollection();
        private NoteTypesCollection noteTypesCollection = new NoteTypesCollection();

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

        public List<Farm> getFarms(int userId)
        {
            string query = "SELECT * FROM farmsView WHERE [user] = " + userId;
            connect();
            conn.Open();

            command = new SqlCommand(query, conn);
            dataReader = command.ExecuteReader();

            List<Farm> rows = new List<Farm>();

            while (dataReader.Read())
            {
                int farmId = dataReader.GetInt32(0);
                string farmName = dataReader.GetString(1);
                Farm farm = new Farm(farmId, farmName, user);
                rows.Add(farm);
            }
            dataReader.Close();
            conn.Close();

            return rows;
        }

        public List<Field> getFields(Farm farm)
        {
            string query = "SELECT * FROM fieldsView" + farm.User.Id + "WHERE farm = " + farm.Id;
            connect();
            conn.Open();

            command = new SqlCommand(query, conn);
            dataReader = command.ExecuteReader();

            List<Field> fields = new List<Field>();

            while (dataReader.Read())
            {
                int id = dataReader.GetInt32(0);
                string name = dataReader.GetString(1);
                string description = "";
                int plantId = 0;
                Plant plant = null;
                if (dataReader.GetValue(2) != DBNull.Value)
                {
                    description = dataReader.GetString(2);
                }

                string coordinates = dataReader.GetString(3);

                if (dataReader.GetValue(4) != DBNull.Value)
                {
                    plantId = dataReader.GetInt32(4);
                    plant = plantsCollection.getPlantsList().Find(x => x.Id == plantId);
                }
                Field field = new Field(id, name, description, coordinates, farm, plant);
                fields.Add(field);
            }


            dataReader.Close();
            conn.Close();

            return fields;
        }

        public List<Plant> getPlants()
        {
            string query = "SELECT * FROM plantsView";
            connect();
            conn.Open();

            command = new SqlCommand(query, conn);
            dataReader = command.ExecuteReader();

            List<Plant> plants = new List<Plant>();
            while (dataReader.Read())
            {
                Plant plant = new Plant(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetInt32(2));
                plants.Add(plant);
            }
            dataReader.Close();
            conn.Close();

            return plants;
        }

        public List<MachineType> getMachineTypes()
        {
            string query = "SELECT * FROM machine_TypesView";
            connect();
            conn.Open();

            command = new SqlCommand(query, conn);
            dataReader = command.ExecuteReader();

            List<MachineType> machineTypes = new List<MachineType>();
            while (dataReader.Read())
            {
                MachineType type = new MachineType(dataReader.GetInt32(0), dataReader.GetString(1));
                machineTypes.Add(type);
            }
            dataReader.Close();
            conn.Close();

            return machineTypes;
        }

        public List<ToolType> getToolTypes()
        {
            string query = "SELECT * FROM tool_TypesView";
            connect();
            conn.Open();

            command = new SqlCommand(query, conn);
            dataReader = command.ExecuteReader();

            List<ToolType> toolTypes = new List<ToolType>();
            while (dataReader.Read())
            {
                ToolType type = new ToolType(dataReader.GetInt32(0), dataReader.GetString(1));
                toolTypes.Add(type);
            }
            dataReader.Close();
            conn.Close();

            return toolTypes;
        }

        public List<ResourceType> getResourceTypes()
        {
            string query = "SELECT * FROM resource_typesView";
            connect();
            conn.Open();

            command = new SqlCommand(query, conn);
            dataReader = command.ExecuteReader();

            List<ResourceType> types = new List<ResourceType>();
            while (dataReader.Read())
            {
                ResourceType type = new ResourceType(dataReader.GetInt32(0), dataReader.GetString(1));
                types.Add(type);
            }
            dataReader.Close();
            conn.Close();

            return types;
        }

        public List<ActivityType> getActivityTypes()
        {
            string query = "SELECT * FROM activity_typesView";
            connect();
            conn.Open();

            command = new SqlCommand(query, conn);
            dataReader = command.ExecuteReader();

            List<ActivityType> activityTypes = new List<ActivityType>();
            while (dataReader.Read())
            {
                ActivityType activityType = new ActivityType(dataReader.GetInt32(0), dataReader.GetString(1));
                activityTypes.Add(activityType);
            }
            dataReader.Close();
            conn.Close();

            return activityTypes;

        }

        public List<NoteType> getNoteTypes()
        {
            string query = "SELECT * FROM note_typesView";
            connect();
            conn.Open();

            command = new SqlCommand(query, conn);
            dataReader = command.ExecuteReader();

            List<NoteType> types = new List<NoteType>();
            while (dataReader.Read())
            {
                NoteType type = new NoteType(dataReader.GetInt32(0), dataReader.GetString(1));
                types.Add(type);
            }
            dataReader.Close();
            conn.Close();

            return types;

        }

        public List<Garage> getGarages(Farm farm)
        {
            string query = "SELECT * FROM garagesView" + farm.User.Id + " WHERE farm = " + farm.Id;
            connect();
            conn.Open();

            command = new SqlCommand(query, conn);
            dataReader = command.ExecuteReader();

            List<Garage> garages = new List<Garage>();
            while (dataReader.Read())
            {
                int garageId = dataReader.GetInt32(0);
                string garageName = dataReader.GetString(1);
                Garage garage = new Garage(garageId, garageName);
                garages.Add(garage);
            }
            dataReader.Close();
            conn.Close();

            return garages;
        }

        public List<Storage> getStorages(Farm farm)
        {
            string query = "SELECT * FROM storagesView" + farm.User.Id + " WHERE farm = " + farm.Id;
            connect();
            conn.Open();

            command = new SqlCommand(query, conn);
            dataReader = command.ExecuteReader();

            List<Storage> storages = new List<Storage>();
            while (dataReader.Read())
            {
                int storageId = dataReader.GetInt32(0);
                string storageName = dataReader.GetString(1);
                Storage storage = new Storage(storageId, storageName);
                storages.Add(storage);
            }
            dataReader.Close();
            conn.Close();


            return storages;
        }

        public List<Machine> getMachines(int garageId)
        {
            string queryMachines = "SELECT * FROM machinesView WHERE garage = " + garageId;

            connect();
            conn.Open();

            command = new SqlCommand(queryMachines, conn);
            dataReader = command.ExecuteReader();

            List<Machine> machines = new List<Machine>();
            Machine machine;

            while (dataReader.Read())
            {
                int machineId = dataReader.GetInt32(0);
                string machineName = dataReader.GetString(1);
                int mileage = 0;
                MachineType machineType = null;
                DateTime inspection = DateTime.MinValue;
                float fuel = 0;

                if (dataReader.GetValue(2) != DBNull.Value)
                {
                    mileage = dataReader.GetInt32(2);
                }

                if (dataReader.GetValue(3) != DBNull.Value)
                {
                    int machineTypeId = dataReader.GetInt32(3);
                    machineType = machineTypesCollection.getMachineTypesList().Find(x => x.Id == machineTypeId);
                }

                if (dataReader.GetValue(4) != DBNull.Value)
                {
                    inspection = DateTime.Parse(dataReader.GetValue(4).ToString());
                }

                if (dataReader.GetValue(5) != DBNull.Value)
                {
                    fuel = dataReader.GetFloat(5);
                }

                machine = new Machine(machineId, machineName, mileage, machineType, inspection, fuel);

                machines.Add(machine);

            }


            dataReader.Close();
            conn.Close();


            return machines;
        }

        public List<Tool> getTools(int garageId)
        {
            string queryTools = "SELECT * FROM toolsView WHERE t.garage = " + garageId;

            connect();
            conn.Open();

            command = new SqlCommand(queryTools, conn);
            dataReader = command.ExecuteReader();

            List<Tool> tools = new List<Tool>();
            while (dataReader.Read())
            {
                Tool tool = null;
                int toolId = dataReader.GetInt32(0);
                string toolName = dataReader.GetString(1);
                int mileage = 0;
                ToolType type = null;

                if (dataReader.GetValue(2) != DBNull.Value)
                {
                    mileage = dataReader.GetInt32(2);
                }

                if (dataReader.GetValue(3) != DBNull.Value)
                {
                    int toolTypeId = dataReader.GetInt32(3);
                    type = toolTypesCollection.getToolTypesList().Find(x => x.Id == toolTypeId);
                }

                tool = new Tool(toolId, toolName, mileage, type);
                tools.Add(tool);
            }
            dataReader.Close();
            conn.Close();


            return tools;
        }

        public List<Resource> getResources(Storage storage)
        {
            string query = "SELECT * WHERE storage = " + storage.Id;

            connect();
            conn.Open();

            command = new SqlCommand(query, conn);
            dataReader = command.ExecuteReader();

            List<Resource> resources = new List<Resource>();
            while (dataReader.Read())
            {
                int resourceId = dataReader.GetInt32(0);
                string resourceName = dataReader.GetString(1);
                ResourceType type = null;
                float amount = 0;

                if (dataReader.GetValue(2) != DBNull.Value)
                {
                    int resourceTypeId = dataReader.GetInt32(2);
                    type = resourceTypesCollection.getResourceTypesList().Find(x => x.Id == resourceTypeId);
                }

                if (dataReader.GetValue(3) != DBNull.Value)
                {
                    amount = dataReader.GetFloat(3);
                }


                Resource resource = new Resource(resourceId, resourceName, type, amount);
                resources.Add(resource);
            }
            dataReader.Close();
            conn.Close();


            return resources;
        }

        public List<Activity> getActivities(Farm farm)
        {
            string queryActivities = "SELECT * FROM activitiesJournalEntriesView WHERE journalId = " + farm.Journal.Id;
            connect();
            conn.Open();

            command = new SqlCommand(queryActivities, conn);
            dataReader = command.ExecuteReader();

            List<Activity> activities = new List<Activity>();

            while (dataReader.Read())
            {
                int activityId = dataReader.GetInt32(0);
                string activityName = dataReader.GetString(1);
                string activityDescription = string.Empty;

                if (dataReader.GetValue(2) != DBNull.Value)
                {
                    activityDescription = dataReader.GetString(2);
                }

                DateTime start = DateTime.Parse(dataReader.GetValue(3).ToString());
                DateTime finish = DateTime.Parse(dataReader.GetValue(4).ToString());

                Field field = null;

                if (dataReader.GetValue(5) != DBNull.Value)
                {
                    int fieldId = dataReader.GetInt32(5);
                    field = farm.FieldsList.Find(x => x.Id == fieldId);
                }

                ActivityType activityType = null;

                if (dataReader.GetValue(6) != DBNull.Value)
                {
                    int activityTypeId = dataReader.GetInt32(6);
                    activityType = activityTypesCollection.getactivityTypesList().Find(x => x.Id == activityTypeId);
                }

                Employee employee = null;

                if (dataReader.GetValue(7) != DBNull.Value)
                {
                    int employeeId = dataReader.GetInt32(7);
                    employee = user.EmployeesList.Find(x => x.Id == employeeId);
                }

                Machine machine = null;

                if (dataReader.GetValue(8) != DBNull.Value)
                {
                    int machineId = dataReader.GetInt32(8);
                    foreach (Garage g in farm.GaragesList)
                    {
                        machine = g.MachinesList.Find(x => x.Id == machineId);
                        break;
                    }
                }

                Tool tool = null;

                if (dataReader.GetValue(9) != DBNull.Value)
                {
                    int toolId = dataReader.GetInt32(9);
                    foreach (Garage g in farm.GaragesList)
                    {
                        tool = g.ToolsList.Find(x => x.Id == toolId);
                        break;
                    }
                }

                float value = 0;

                if (dataReader.GetValue(10) != DBNull.Value)
                {
                    value = dataReader.GetFloat(10);
                }

                Activity activity = new Activity(
                    activityId,
                    activityName,
                    activityDescription,
                    start, finish,
                    activityType,
                    field,
                    employee,
                    machine,
                    tool,
                    value
                    );

                activities.Add(activity);
            }

            dataReader.Close();
            conn.Close();

            return activities;
        }

        public List<Note> getNotes(Farm farm)
        {
            string queryNotes = "SELECT * FROM notesJournalEntriesView WHERE journalId = " + farm.Journal.Id;

            command = new SqlCommand(queryNotes, conn);
            dataReader = command.ExecuteReader();

            List<Note> notes = new List<Note>();

            while (dataReader.Read())
            {
                int noteId = dataReader.GetInt32(0);
                string noteName = dataReader.GetString(1);

                string noteDescrition = string.Empty;
                if (dataReader.GetValue(2) != DBNull.Value)
                {
                    noteDescrition = dataReader.GetString(2);
                }

                NoteType type = null;
                if (dataReader.GetValue(3) != DBNull.Value)
                {
                    int noteTypeId = dataReader.GetInt32(3);
                    type = noteTypesCollection.getNoteTypesList().Find(x => x.Id == noteTypeId);
                }

                DateTime start = DateTime.Parse(dataReader.GetValue(3).ToString());
                DateTime finish = DateTime.Parse(dataReader.GetValue(4).ToString());

                Field field = null;

                if (dataReader.GetValue(5) != DBNull.Value)
                {
                    int fieldId = dataReader.GetInt32(5);
                    field = farm.FieldsList.Find(x => x.Id == fieldId);
                }

                float value = 0;

                if(dataReader.GetValue(6) != DBNull.Value)
                {
                    value = dataReader.GetFloat(6);
                }

                Note note = new Note(noteId, noteName, type, noteDescrition, start, finish, field, value);
                notes.Add(note);
            }

            dataReader.Close();
            conn.Close();

            return notes;
        }

        public List<Employee> getEmployees(User user)
        {
            string query = "SELECT * FROM employeesView" + user.Id;

            connect();
            conn.Open();

            command = new SqlCommand(query, conn);
            dataReader = command.ExecuteReader();

            List<Employee> employees = new List<Employee>();
            while (dataReader.Read())
            {
                Employee employee = new Employee(dataReader.GetInt32(0), dataReader.GetString(1));
                employees.Add(employee);
            }
            dataReader.Close();
            conn.Close();


            return employees;
        }

        public object[] getActivity(int activityId)
        {
            string query = "SELECT * FROM activitiesView WHERE id = " + activityId;
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

            string queryCount = "SELECT COUNT(*) FROM activitiesView WHERE field = " + fieldId + " AND start_date BETWEEN '" + startDateString + "' AND '" + finishDateString + "'";

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
            int id = 0;

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

            int.TryParse(output, out id);

            user = new User(id, login, password);

            return id;
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

                createView = "CREATE VIEW machinesView" + userId + " AS SELECT m.id,m.garage, m.name, m.mileage, mt.type, m.inspection_date, m.fuel FROM Machines as m " +
                    "JOIN Machine_types as mt ON m.type = mt.id JOIN Garages as g ON m.garage = g.id JOIN Farms as f ON g.farm = f.id WHERE f.[user] =" + userId;
                command = new SqlCommand(createView, conn);
                command.ExecuteNonQuery();

                createView = "CREATE VIEW resourcesView" + userId + " AS SELECT r.id, r.type, rt.type, r.amount FROM Resources as r " +
                    "JOIN Storages as st ON r.storage = st.id JOIN Farms as f ON st.farm = f.id WHERE f.[user] = " + userId;
                command = new SqlCommand(createView, conn);
                command.ExecuteNonQuery();
            }



            conn.Close();

            return a;
        }
    }
}
