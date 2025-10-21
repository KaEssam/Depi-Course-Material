using Day1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Day1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signManager;

        public AccountController(SignInManager<AppUser> signManager, UserManager<AppUser> userManager)
        {
            _signManager = signManager;
            _userManager = userManager;
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.Email
                };

               var res = await _userManager.CreateAsync(user, model.Password);

                if (res.Succeeded)
                {
                    await _signManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                
            }

            return View(model);
            
        }



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {
                var res = await _signManager.PasswordSignInAsync(model.Email, model.Password,isPersistent:false, false);

                if (res.Succeeded)
                    return RedirectToAction("Index", "Home");


            }

            return View(model);

        }


        [HttpPost]

        public async Task<IActionResult> Logout()
        {
            await _signManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
