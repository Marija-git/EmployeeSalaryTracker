
namespace EmployeeSalaryTracker.Data.Entities
{
    public class SalaryHistory
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Updated { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

    }
}
