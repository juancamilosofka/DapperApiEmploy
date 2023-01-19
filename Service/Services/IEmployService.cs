using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;

namespace Service.Services
{
    public interface IEmployService
    {

        public  Task<IEnumerable<Employee>> GetallEmployee();


        public  Task<Employee> GetSingleEmployee(int EmployeeId);


        public  Task<String> PostEmployee(Employee employee);


        public  Task<String> PutEmployee(Employee employee);


        public  Task<String> DeleteEmployee(int Id);

    }
}
