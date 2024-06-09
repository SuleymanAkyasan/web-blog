using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using webdersi.Models;

namespace webdersi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
