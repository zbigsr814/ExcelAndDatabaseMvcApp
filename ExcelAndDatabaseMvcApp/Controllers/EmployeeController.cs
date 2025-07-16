using ExcelAndDatabaseMvcApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExcelAndDatabaseMvcApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly CompanyDbContext _dbContext;

        public EmployeeController(CompanyDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        public IActionResult Index()
        {
            var employees = _dbContext.employees.ToList();

            return View(employees);
        }

        public IActionResult WorkLog([FromRoute] int Id)
        {
            var employees = _dbContext.employees
                .Include(wl => wl.WorkLogs)
                .Where(wl => wl.Id == Id)
                .ToList();

            return View(employees);
        }
    }
}
