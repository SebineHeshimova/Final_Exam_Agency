using Agency.Core.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Agency.MVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles ="SuperAdmin")]
    public class DashboardController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> CreateAdmin()
        {
            AppUser appUser = new AppUser()
            {
                FullName = "Hashimova Sabina",
                UserName = "SabinaHS"
            };
            await _userManager.CreateAsync(appUser,"Sabina123@");
            await _userManager.AddToRoleAsync(appUser, "SuperAdmin");
            return Ok();
        }
        public async Task<IActionResult> CreateRole()
        {
            IdentityRole role1=new IdentityRole("SuperAdmin");
            IdentityRole role2 = new IdentityRole("Admin");
            IdentityRole role3 = new IdentityRole("User");

            await _roleManager.CreateAsync(role1);
            await _roleManager.CreateAsync(role2);
            await _roleManager.CreateAsync(role3);
            return Ok("Role yarandi!");
        }

    }
}
