using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CoreProject1._0.Model
{
    public class Employee
    {   [Key]
        public int EmpCode { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string firstName { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string lastName { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string email { get; set; }
        public int age { get; set; }

    }
}
