using GymInns.Data;
using GymInns.Models;
using GymInns.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymInns.Controllers
{
    public class UsersController : Controller
    {
        private readonly MVCDemoDbContext mvcdemoDbContext;
        public UsersController(MVCDemoDbContext mvcdemoDbContext)
        {
            this.mvcdemoDbContext = mvcdemoDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
          var users = await  mvcdemoDbContext.Users.ToListAsync();
            return View(users);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddVUserViewModel addVUserViewModel)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                Name = addVUserViewModel.Name,
                Email = addVUserViewModel.Email,
                Password = addVUserViewModel.Password,
                Plan = addVUserViewModel.Plan,
                DateJoin = addVUserViewModel.DateJoin,
                DateExpired = addVUserViewModel.DateExpired,
            };
            await mvcdemoDbContext.Users.AddAsync(user);
            await mvcdemoDbContext.SaveChangesAsync();
            return RedirectToAction("Add");
        }


    }
}
