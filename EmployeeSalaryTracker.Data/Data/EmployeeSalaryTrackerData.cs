using EmployeeSalaryTracker.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeSalaryTracker.Data.Data
{
    public class EmployeeSalaryTrackerData : DbContext
    {
        public EmployeeSalaryTrackerData(DbContextOptions<EmployeeSalaryTrackerData> options): base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<SalaryHistory> SalaryHistories { get; set; }
    }
}
