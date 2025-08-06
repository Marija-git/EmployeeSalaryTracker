using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSalaryTracker.Data.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal CurrentSalary { get; set; }
        public List<SalaryHistory> SalaryHistory { get; set; } = new();
    }
}
