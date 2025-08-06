using EmployeeSalaryTracker.Data.Data;
using EmployeeSalaryTracker.Data.Entities;
using EmployeeSalaryTracker.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeSalaryTracker.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeSalaryTrackerData _data;
        public EmployeeRepository(EmployeeSalaryTrackerData data)
        {
            _data = data;
        }
        public async Task<List<Employee>> GetAllWithSalaryHistoryAsync()
        {
            return await _data.Employees.Include(e=>e.SalaryHistory).ToListAsync();
        }
    }
}
