using EmployeeSalaryTracker.Data.Entities;


namespace EmployeeSalaryTracker.Service.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllWithSalaryHistoryAsync();
    }
}
