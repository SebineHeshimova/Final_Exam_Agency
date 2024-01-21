using Agency.Business.CustomExceptions.AgencyExceptions;
using Agency.Business.Services.Interfaces;
using Agency.Core.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Agency.MVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "SuperAdmin")]
    public class SettingController : Controller
    {
        private readonly ISettingService _service;

        public SettingController(ISettingService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var setting=await _service.GetAllAsync();
            return View(setting);
        }
        public async Task<IActionResult> Update(int id)
        {
            var setting = await _service.GetByIdAsync(s => s.Id == id);
            if (setting == null) return View("Error");
            return View(setting);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Setting setting)
        {
            try
            {
                await _service.UpdateAsync(setting);
            }
            catch(EntityNullException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
            catch(Exception ex) { }
            return RedirectToAction("Index");
        }
    }
}
