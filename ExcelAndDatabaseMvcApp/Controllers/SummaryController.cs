using ExcelAndDatabaseMvcApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace ExcelAndDatabaseMvcApp.Controllers
{
    public class SummaryController : Controller
    {
        private readonly CompanyDbContext _dbContext;

        public SummaryController(CompanyDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var sql = System.IO.File.ReadAllText("wwwroot/sql/ExcelGetSummaryCte.sql");

            var summaries = await _dbContext.summares
                .FromSqlRaw(sql)
                .ToListAsync();

            foreach (var item in summaries)
            {

            }

            return View(summaries);
        }
    }
}
