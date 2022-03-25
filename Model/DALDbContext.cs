using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using CoreProject1._0.Model;

namespace CoreProject1._0.Model
{
    public class DALDbContext : DbContext
    {
        public DALDbContext(DbContextOptions<DALDbContext> options) : base(options)
        { }
        public DbSet<Employee> EmployeeTable { get; set; }
    }
}
