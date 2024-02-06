using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroApp.Logic
{
    public class User : ClassBase
    {
        private int id;
        private string login;
        private string password;
        private List<Employee> employeesList;

        public int Id { get => id; set => id = value; }
        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }
        public List<Employee> EmployeesList { get => employeesList; set => employeesList = databaseOperator.getEmployees(this); }

        public User(int id, string login, string password)
        {
            this.id = id;
            this.login = login;
            this.password = password;            
        }
    }
}
