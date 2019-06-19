
using Microsoft.AspNetCore.Mvc;

namespace DilekSaylan.Assessment.Controllers
{
    public class WebPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}