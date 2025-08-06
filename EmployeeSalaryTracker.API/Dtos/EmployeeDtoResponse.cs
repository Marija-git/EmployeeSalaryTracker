namespace EmployeeSalaryTracker.API.Dtos
{
    public class EmployeeDtoResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal CurrentSalary { get; set; }
        public List<SalaryHistoryDtoResponse> SalaryHistory { get; set; }
    }
}
