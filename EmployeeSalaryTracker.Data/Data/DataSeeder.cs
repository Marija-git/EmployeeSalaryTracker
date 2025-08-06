using EmployeeSalaryTracker.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSalaryTracker.Data.Data
{
    public static class DataSeeder
    {
        public static void SeedData(IServiceProvider serviceProvider)
        {
            var options = serviceProvider.GetRequiredService<DbContextOptions<EmployeeSalaryTrackerData>>();
            using var context = new EmployeeSalaryTrackerData(options);

            if (!context.Employees.Any())
            {
                var employees = new[]
                {
                    new Employee
                    {
                        Name = "Marko Marković",
                        CurrentSalary = 50000m
                    },
                    new Employee
                    {
                        Name = "Jelena Janković",
                        CurrentSalary = 60000m
                    },
                    new Employee
                    {
                        Name = "Ivan Ilić",
                        CurrentSalary = 70000m
                    }
                };

                context.Employees.AddRange(employees);
                context.SaveChanges();
            }
            if (!context.SalaryHistories.Any())
            {
                var employees = context.Employees.ToList();
                var histories = new List<SalaryHistory>();

                foreach (var e in employees)
                {
                    histories.Add(new SalaryHistory
                    {
                        EmployeeId = e.Id,
                        Amount = e.CurrentSalary - 5000m, 
                        Updated = DateTime.UtcNow.AddMonths(-6)
                    });
                    histories.Add(new SalaryHistory
                    {
                        EmployeeId = e.Id,
                        Amount = e.CurrentSalary,  
                        Updated = DateTime.UtcNow
                    });
                }

                context.SalaryHistories.AddRange(histories);
                context.SaveChanges();
            }
        }
    }
}
