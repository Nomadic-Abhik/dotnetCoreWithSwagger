using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreProject1._0.IRepository;
using CoreProject1._0.Model;

namespace CoreProject1._0.Repository
{
    public class EmployeeRepo :IEmployee
    {
        private readonly DALDbContext _context;
        public EmployeeRepo(DALDbContext context)
        {
            // this._context = context;
            this._context = context;
        }
        public async Task<IEnumerable<Employee>> GetEmployee()
        {
            try
            {
                var employeeList = (from item in _context.EmployeeTable
                                 select new Employee()
                                 {
                                     EmpCode = item.EmpCode,
                                     firstName = item.firstName,
                                     lastName = item.lastName,
                                     age = item.age,
                                     email = item.email
                                 }).ToList();
                return await Task.Run(() => employeeList);
            }
            catch(Exception ex)
            {
                return null;
                //Exception Handling Logic- may be DB Log, returning null as of now
            }
        }
    }
}
