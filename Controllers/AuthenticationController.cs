using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webdersi.Models.Data;
using webdersi.Models.Entities;
using webdersi.Models.ViewModels;

namespace webdersi.Controllers
{
    [Route("[controller]/[action]")]
    public class AuthenticationController(AppDbContext _context) : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login( LoginViewModel loginViewModel)
        {
            var user = await _context.Set<User>().FirstOrDefaultAsync(u => u.Email == loginViewModel.Email && u.Password == loginViewModel.Password);

            if (user is null)
                return View();

            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register( RegisterViewModel registerViewModel)
        {
            var user = await _context.Set<User>().FirstOrDefaultAsync(u => u.Email == registerViewModel.Email);

            if (user is not null)
                return View();

            await _context.Set<User>().AddAsync(new Models.Entities.User() { Email = registerViewModel.Email, Password = registerViewModel.Password });

            bool response = await _context.SaveChangesAsync() > 0;

            if (response is true)
                return RedirectToAction("Login", "Authentication"); // gideceği sayfan
            return View();
        }
    }
}
