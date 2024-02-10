using AgroApp.Logic.DBControl;
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
        public List<Plant> plantsCollection;
        public List<PlantType> plantTypesCollection;
        public List<MachineType> machineTypesCollection;
        public List<ToolType> toolTypesCollection;
        public List<ResourceType> resourceTypesCollection;
        public List<ActivityType> activityTypesCollection;
        public List<NoteType> noteTypesCollection;

        public DBOperator()
        {
            setupCollections();
        }

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

        public int update(UpdateQuery query)
        {
            a = 0;

            connect();
            conn.Open();
            command = new SqlCommand(query.getQuery(), conn);

            if(command.ExecuteNonQuery() != 0)
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

        public void setupCollections()
        {
            plantTypesCollection = getPlantTypes();
            plantsCollection = getPlants();
            machineTypesCollection = getMachineTypes();
            toolTypesCollection = getToolTypes();
            resourceTypesCollection = getResourceTypes();
            activityTypesCollection = getActivityTypes();
            noteTypesCollection = getNoteTypes();
        }

        public Journal getJournal(Farm farm)
        {
            string query = "SELECT * FROM allJournalsView";
            connect();
            conn.Open();

            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader dataReader = command.ExecuteReader();

            Journal journal = null;

            while (dataReader.Read())
            {
                int farmId = dataReader.GetInt32(1);
                if (farm.Id == farmId)
                {
                    int journalId = dataReader.GetInt32(0);
                    journal = new Journal(journalId);
                    break;
                }
            }

            return journal;
        }

        public List<PlantType> getPlantTypes()
        {
            string query = "SELECT * FROM plantTypesView";
            connect();
            conn.Open();

            command = new SqlCommand(query, conn);
            dataReader = command.ExecuteReader();

            List<PlantType> plantTypes = new List<PlantType>();

            while (dataReader.Read())
            {
                int typeId = dataReader.GetInt32(0);
                string typeName = dataReader.GetString(1);

                PlantType plantType = new PlantType(typeId, typeName);
                plantTypes.Add(plantType);
            }

            dataReader.Close();
            conn.Close();

            return plantTypes;
        }

        public List<Farm> getFarms()
        {
            string query = "SELECT * FROM farmsView WHERE [user] = " + user.Id;
            connect();
            conn.Open();

            command = new SqlCommand(query, conn);
            dataReader = command.ExecuteReader();

            List<Farm> rows = new List<Farm>();

            while (dataReader.Read())
            {
                int farmId = dataReader.GetInt32(0);
                string farmName = dataReader.GetString(1);
                Farm farm = new Farm(farmId, farmName);
                farm.FieldsList = getFields(farm);
                farm.GaragesList = getGarages(farm);
                foreach (Garage g in farm.GaragesList)
                {
                    g.MachinesList = getMachines(g.Id);
                    g.ToolsList = getTools(g.Id);
                }
                farm.StoragesList = getStorages(farm);
                foreach (Storage s in farm.StoragesList)
                {
                    s.ResourcesList = getResources(s);
                }
                farm.Journal = getJournal(farm);
                farm.Journal.ActivitiesList = getActivities(farm);
                farm.Journal.NotesList = getNotes(farm);
                rows.Add(farm);
            }
            dataReader.Close();
            conn.Close();

            return rows;
        }

        public List<Field> getFields(Farm farm)
        {
            string query = "SELECT * FROM fieldsView WHERE farm = " + farm.Id;
            connect();
            conn.Open();

            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader dataReader = command.ExecuteReader();

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
                    plant = plantsCollection.Find(x => x.Id == plantId);
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
                PlantType type = plantTypesCollection.Find(x => x.Id == dataReader.GetInt32(2));
                Plant plant = new Plant(dataReader.GetInt32(0), dataReader.GetString(1), type);
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
            string query = "SELECT * FROM garagesView WHERE farm = " + farm.Id;
            connect();
            conn.Open();

            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader dataReader = command.ExecuteReader();

            List<Garage> garages = new List<Garage>();
            while (dataReader.Read())
            {
                int garageId = dataReader.GetInt32(0);
                string garageName = dataReader.GetString(1);
                Garage garage = new Garage(garageId, garageName);
                garage.MachinesList = getMachines(garageId);
                garage.ToolsList = getTools(garageId);
                garages.Add(garage);
            }
            dataReader.Close();
            conn.Close();

            return garages;
        }

        public List<Storage> getStorages(Farm farm)
        {
            string query = "SELECT * FROM storagesView WHERE farm = " + farm.Id;
            connect();
            conn.Open();

            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader dataReader = command.ExecuteReader();

            List<Storage> storages = new List<Storage>();
            while (dataReader.Read())
            {
                int storageId = dataReader.GetInt32(0);
                string storageName = dataReader.GetString(1);
                Storage storage = new Storage(storageId, storageName);
                storage.ResourcesList = getResources(storage);
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

            SqlCommand command = new SqlCommand(queryMachines, conn);
            SqlDataReader dataReader = command.ExecuteReader();

            List<Machine> machines = new List<Machine>();
            Machine machine;

            while (dataReader.Read())
            {
                int machineId = dataReader.GetInt32(0);
                string machineName = dataReader.GetString(2);
                int mileage = 0;
                MachineType machineType = null;
                DateTime inspection = DateTime.MinValue;
                double fuel = 0;

                if (dataReader.GetValue(3) != DBNull.Value)
                {
                    mileage = dataReader.GetInt32(3);
                }

                if (dataReader.GetValue(4) != DBNull.Value)
                {
                    int machineTypeId = dataReader.GetInt32(4);
                    machineType = machineTypesCollection.Find(x => x.Id == machineTypeId);
                }

                if (dataReader.GetValue(5) != DBNull.Value)
                {
                    inspection = DateTime.Parse(dataReader.GetValue(5).ToString());
                }

                if (dataReader.GetValue(6) != DBNull.Value)
                {
                    fuel = dataReader.GetDouble(6);
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
            string queryTools = "SELECT * FROM toolsView WHERE garage = " + garageId;

            connect();
            conn.Open();

            SqlCommand command = new SqlCommand(queryTools, conn);
            SqlDataReader dataReader = command.ExecuteReader();

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
                    type = toolTypesCollection.Find(x => x.Id == toolTypeId);
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
            string query = "SELECT * FROM resourcesView WHERE storageId = " + storage.Id;

            connect();
            conn.Open();

            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader dataReader = command.ExecuteReader();

            List<Resource> resources = new List<Resource>();
            while (dataReader.Read())
            {
                int resourceId = dataReader.GetInt32(0);
                string resourceName = dataReader.GetString(1);
                ResourceType type = null;
                double amount = 0;

                if (dataReader.GetValue(2) != DBNull.Value)
                {
                    int resourceTypeId = dataReader.GetInt32(2);
                    type = resourceTypesCollection.Find(x => x.Id == resourceTypeId);
                }

                if (dataReader.GetValue(3) != DBNull.Value)
                {
                    amount = dataReader.GetDouble(3);
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

            SqlCommand command = new SqlCommand(queryActivities, conn);
            SqlDataReader dataReader = command.ExecuteReader();

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
                    activityType = activityTypesCollection.Find(x => x.Id == activityTypeId);
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

                Resource resource = null;

                if (dataReader.GetValue(10) != DBNull.Value)
                {
                    int resourceId = dataReader.GetInt32(10);
                    foreach (Storage s in farm.StoragesList)
                    {
                        resource = s.ResourcesList.Find(x => x.Id == resourceId);
                        break;
                    }
                }

                double value = 0;

                if (dataReader.GetValue(10) != DBNull.Value)
                {
                    value = dataReader.GetDouble(10);
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
                    resource,
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
            string queryNotes = "SELECT * FROM notesJournalEntriesView WHERE journal = " + farm.Journal.Id;
            connect();
            conn.Open();

            SqlCommand command = new SqlCommand(queryNotes, conn);
            SqlDataReader dataReader = command.ExecuteReader();

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
                    type = noteTypesCollection.Find(x => x.Id == noteTypeId);
                }

                DateTime start = DateTime.Parse(dataReader.GetValue(4).ToString());
                DateTime finish = DateTime.Parse(dataReader.GetValue(5).ToString());

                Field field = null;

                if (dataReader.GetValue(6) != DBNull.Value)
                {
                    int fieldId = dataReader.GetInt32(6);
                    field = farm.FieldsList.Find(x => x.Id == fieldId);
                }

                double value = 0;

                if (dataReader.GetValue(7) != DBNull.Value)
                {
                    value = dataReader.GetDouble(7);
                }

                Note note = new Note(noteId, noteName, type, noteDescrition, start, finish, field, value);
                notes.Add(note);
            }

            dataReader.Close();
            conn.Close();

            return notes;
        }

        public List<Employee> getEmployees()
        {
            string query = "SELECT * FROM employeesView WHERE [user] = " + user.Id + ";";

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
            user.EmployeesList = getEmployees();
            user.FarmsList = getFarms();


            foreach (Farm f in user.FarmsList)
            {
                f.FieldsList = getFields(f);
                f.GaragesList = getGarages(f);
                f.StoragesList = getStorages(f);
            }

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
                
            }
            
            conn.Close();

            return a;
        }
    }
}
