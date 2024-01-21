using Agency.Core.Entity;
using Agency.MVC.Areas.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Agency.MVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AdminLoginViewModel viewModel)
        {
            AppUser user = null;
            user = await _userManager.FindByNameAsync(viewModel.UserName);
            if(user == null)
            {
                ModelState.AddModelError("", "Invalid Username or Password!");
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(user, viewModel.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Invalid Username or Password!");
                return View();
            }
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
