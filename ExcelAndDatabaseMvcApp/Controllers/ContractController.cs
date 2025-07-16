using ExcelAndDatabaseMvcApp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ExcelAndDatabaseMvcApp.Controllers
{
    public class ContractController : Controller
    {
        private readonly CompanyDbContext _dbContext;

        public ContractController(CompanyDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        public IActionResult Index()
        {
            var contracts = _dbContext.contracts.ToList();

            return View(contracts);
        }
    }
}
