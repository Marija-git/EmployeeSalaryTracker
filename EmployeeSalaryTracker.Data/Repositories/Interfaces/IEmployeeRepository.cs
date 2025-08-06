using EmployeeSalaryTracker.Data.Entities;

namespace EmployeeSalaryTracker.Data.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
       Task<List<Employee>> GetAllWithSalaryHistoryAsync();
    }
}
