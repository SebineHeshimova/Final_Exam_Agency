
using Microsoft.AspNetCore.Mvc;


namespace Agency.MVC.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

       
    }
}