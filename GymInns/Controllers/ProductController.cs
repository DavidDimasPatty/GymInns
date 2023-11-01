using GymInns.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymInns.Controllers
{
    public class ProductController : Controller
    {
        private readonly MVCDemoDbContext mvcDemoDBcontext;

        public ProductController(MVCDemoDbContext mvcDemoDBcontext)
        {
            this.mvcDemoDBcontext = mvcDemoDBcontext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Detail(int Id)
        {
            var productDetail = await mvcDemoDBcontext.Products.FirstOrDefaultAsync(x=>x.ID==Id);
            return View(productDetail);
        }
    }
}
