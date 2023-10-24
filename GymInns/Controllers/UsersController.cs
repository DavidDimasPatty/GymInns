using Microsoft.AspNetCore.Mvc;

namespace GymInns.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


    }
}
