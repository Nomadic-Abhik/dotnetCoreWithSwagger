using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreProject1._0.IRepository;
using CoreProject1._0.Model;
using System.Net;

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
        public async Task<IEnumerable<Employee>> GetEmployeebyInput(string searchData)
        {
            try
            {
                var employeeList = (from item in _context.EmployeeTable
                                    where item.firstName.Contains(searchData) || item.lastName.Contains(searchData)
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
            catch (Exception ex)
            {
                return null;
                //Exception Handling Logic- may be DB Log, returning null as of now
            }
        }
        public async Task<HttpStatusCode> AddEmployee(Employee model)
        {
            try
            {
                var existingRecord = _context.EmployeeTable.Where(item => item.email == model.email).FirstOrDefault();

                if (existingRecord == null)
                {
                    _context.EmployeeTable.Add(model);
                    await _context.SaveChangesAsync();
                    return HttpStatusCode.Created;
                }
                else
                {
                    return HttpStatusCode.Ambiguous;
                }
            }
            catch(Exception ex)
            {
                return HttpStatusCode.InternalServerError;
            }
        }
        public async Task<HttpStatusCode> UpdateEmployee(Employee model)
        {
            try
            {
                var existingRecord = _context.EmployeeTable.Where(item => item.email == model.email).FirstOrDefault();

                if (existingRecord != null)
                {
                    existingRecord.firstName = model.firstName;
                    existingRecord.lastName = model.lastName;
                    existingRecord.age = model.age;
                    existingRecord.EmpCode = existingRecord.EmpCode;
                    existingRecord.email = existingRecord.email;
                    await _context.SaveChangesAsync();
                    return HttpStatusCode.OK;
                }
                else
                {
                    return HttpStatusCode.NotFound;
                }
            }
            catch (Exception ex)
            {
                return HttpStatusCode.InternalServerError;
            }
        }

    }
}
