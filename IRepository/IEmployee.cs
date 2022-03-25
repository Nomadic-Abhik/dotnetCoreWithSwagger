using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using CoreProject1._0.Model;

namespace CoreProject1._0.IRepository
{
    public interface IEmployee
    {

        public  Task<IEnumerable<Employee>> GetEmployee();
        public Task<IEnumerable<Employee>> GetEmployeebyInput(string searchData);
        public Task<HttpStatusCode> AddEmployee(Employee model);
        public Task<HttpStatusCode> UpdateEmployee(Employee model);
    }
}
