using Agency.Business.CustomExceptions.AgencyExceptions;
using Agency.Business.Services.Interfaces;
using Agency.Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Agency.MVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService _service;

        public PortfolioController(IPortfolioService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var portfolio = await _service.GetAllAsync();
            return View(portfolio);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Portfolio portfolio)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                await _service.CreateAsync(portfolio);
            }
            catch(EntityNullException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
            catch(PortfolioImageFileContentTypeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch(PortfolioImageFileLengthException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch(Exception ex) { }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            var portfolio = await _service.GetByIdAsync(p => p.Id == id);
            if (portfolio == null) return View("Error");
            return View(portfolio);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Portfolio portfolio)
        {
            try
            {
                await _service.UpdateAsync(portfolio);
            }
            catch (EntityNullException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
            catch (PortfolioImageFileContentTypeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (PortfolioImageFileLengthException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (Exception ex) { }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var portfolio = await _service.GetByIdAsync(p => p.Id == id);
            if (portfolio == null) return View("Error");
            return View(portfolio);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Portfolio portfolio)
        {
            try
            {
                await _service.DeleteAsync(portfolio.Id);
            }
            catch (EntityNullException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
            catch(Exception ex) { }
            return RedirectToAction("Index");
        }
    }
}
