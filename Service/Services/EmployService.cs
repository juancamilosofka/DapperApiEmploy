using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;

using Dapper;



namespace Service.Services
{
    public class EmployService : IEmployService
    {
        String ConnectionString;
        public EmployService()
        {
            ConnectionString = "server=PSOFKA0864;database=Employdb;trusted_connection=True;Encrypt=false";

        }

 
        public async Task<IEnumerable<Employee>> GetallEmployee()
        {
            using var connection = new SqlConnection(ConnectionString);
            var employees = await connection.QueryAsync<Employee>("select * from Employee");
            return employees;
        }

        public async Task<Employee> GetSingleEmployee(int EmployeeId)
        {
            using var connection = new SqlConnection(ConnectionString);
            var employee = await connection.QueryFirstAsync<Employee>("select * from Employee where id = @Id",
                new { Id = EmployeeId });
            return employee;
        }

        public async Task<String> PostEmployee(Employee employee)
        {
            using var connection = new SqlConnection(ConnectionString);
            var rows = await connection.ExecuteAsync("" +
                "insert into Employee " +
                "(Name ,EmployCode ,Email ,Age ,EmployUpDate, EmployDownDate) " +
                "values  (@Name ,@EmployCode ,@Email ,@Age ,@EmployUpDate, @EmployDownDate) ", employee);

            return rows + " row(s) added";
        }

        public async Task<String> PutEmployee(Employee employee)
        {
            using var connection = new SqlConnection(ConnectionString);
            var rows = await connection.ExecuteAsync(
                "update Employee set " +
                "Name = @Name , EmployCode = @EmployCode , Email = @Email , Age =  @Age , EmployUpDate = @EmployUpDate,  EmployDownDate = @EmployDownDate " +
                "where Id = @Id  ", employee);
            return rows + " row(s) modified";
        }

        public async Task<String> DeleteEmployee(int Id)
        {
            using var connection = new SqlConnection(ConnectionString);
            var rows = await connection.ExecuteAsync("delete from Employee where Id = @Id", new { Id = Id });
            return rows + " row(s) deleted";
        }
    }
}
