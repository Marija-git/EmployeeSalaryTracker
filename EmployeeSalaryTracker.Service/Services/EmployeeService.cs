using EmployeeSalaryTracker.Data.Entities;
using EmployeeSalaryTracker.Data.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace EmployeeSalaryTracker.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(IEmployeeRepository employeeRepository, ILogger<EmployeeService> logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        public async Task<List<Employee>> GetAllWithSalaryHistoryAsync()
        {
            _logger.LogInformation("Start fetching employees with salary-history");

            var employees = await _employeeRepository.GetAllWithSalaryHistoryAsync();
            foreach (var e in employees)
            {
                e.SalaryHistory = e.SalaryHistory
                    .Where(h => h.Amount != e.CurrentSalary)
                    .OrderByDescending(h => h.Updated)
                    .ToList();
            }

            _logger.LogInformation("Fetched {Count} employees", employees.Count);
            return employees;

        }
    }
}
