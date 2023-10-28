using GymInns.Data;
using GymInns.Models;
using GymInns.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

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

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
           var user = await mvcdemoDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user != null)
            {
                var editModel = new UpdateUserViewModel()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Password = user.Password,
                    Plan = user.Plan,
                    DateJoin = user.DateJoin,
                    DateExpired = user.DateExpired,
                };
                return View(editModel);
            }

            return RedirectToAction("Index");
         }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateUserViewModel model)
        {
            var user = await mvcdemoDbContext.Users.FindAsync(model.Id);
            
            if (user != null)
            {
                user.Name = model.Name;
                user.Email = model.Email;
                user.Plan = model.Plan;
                user.DateJoin = model.DateJoin;
                user.DateExpired = model.DateExpired;

               await mvcdemoDbContext.SaveChangesAsync();
               return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]

        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await mvcdemoDbContext.Users.FindAsync(id);
            if(user != null) 
            {
                mvcdemoDbContext.Users.Remove(user);
                await mvcdemoDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        }
}
