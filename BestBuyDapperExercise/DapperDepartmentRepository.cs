using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyDapperExercise
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _connection;
        //Constructor

        public DapperDepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Department> GetAllDepartments()
        {
            return _connection.Query<Department>("SELECT * FROM Departments;").ToList();
        }

        public void InsertDepartments(string newDepartmentName)
        {
            _connection.Execute("INSERT INTO departments(Name) VALUES (@departmentName);",
                new { departmentName= newDepartmentName});
        }
    }
}
