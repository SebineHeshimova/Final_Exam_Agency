
using Agency.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Agency.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPortfolioService _portfolioService;

        public HomeController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public async Task<IActionResult> Index()
        {
            var portfolio = await _portfolioService.GetAllAsync();
            return View(portfolio);
        }

       
    }
}