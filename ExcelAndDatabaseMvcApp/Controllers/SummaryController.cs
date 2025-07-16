using ExcelAndDatabaseMvcApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using System.Text;
using ExcelAndDatabaseMvcApp.Services;

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

            return View(summaries);
        }

        [Obsolete]
        public async Task<ActionResult> DownloadExcel()
        {
            var sql = System.IO.File.ReadAllText("wwwroot/sql/ExcelGetSummaryCte.sql");

            var summaries = await _dbContext.summares
                .FromSqlRaw(sql)
                .ToListAsync();

            var bytesFile = ExcelBuilder.GetExcel(summaries);

            var fileName = "Report.xlsx";       // nazwa pliku jaką zobaczy user
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";  // info o typie pliku dla przeglądarki

            // Zwróć plik do pobrania
            return File(bytesFile, contentType, fileName);
        }
    }
}
