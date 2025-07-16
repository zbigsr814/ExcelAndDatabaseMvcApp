using ExcelAndDatabaseMvcApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExcelAndDatabaseMvcApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly CompanyDbContext _dbContext;

        public OrderController(CompanyDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        public IActionResult Index()
        {
            var orders = _dbContext.orders
                .Include(o => o.Items)
                .ToList();

            return View(orders);
        }

        public IActionResult OrderItem([FromRoute] int Id)
        {
            var orders = _dbContext.orders
                .Include(wl => wl.Items)
                .Where(wl => wl.Id == Id)
                .ToList();

            return View(orders);
        }
    }
}
