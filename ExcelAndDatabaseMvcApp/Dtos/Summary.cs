namespace ExcelAndDatabaseMvcApp.Dtos
{
    public class Summary
    {
        public DateTime? YearMonth { get; set; }
        public decimal? EmployeesExpenses { get; set; } = 0;
        public decimal? OrdersExpenses { get; set; } = 0;
        public decimal? CompanyIncomes { get; set; } = 0;
        public decimal? ProfitBrutto { get; set; }
        public decimal? ProfitNetto { get; set; }
    }
}
