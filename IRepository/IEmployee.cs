using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreProject1._0.Model;

namespace CoreProject1._0.IRepository
{
    public interface IEmployee
    {

        public  Task<IEnumerable<Employee>> GetEmployee();
    }
}
