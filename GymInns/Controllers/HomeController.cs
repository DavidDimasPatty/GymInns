using GymInns.Data;
using GymInns.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GymInns.Controllers
{
    public class HomeController : Controller
    {
        private readonly MVCDemoDbContext mvcdemoDbContext;
        public HomeController(MVCDemoDbContext mvcdemoDbContext)
        {
            this.mvcdemoDbContext = mvcdemoDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var product = await mvcdemoDbContext.Products.ToListAsync();
            return View(product);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}