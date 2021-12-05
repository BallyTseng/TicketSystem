using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;
using TicketSystem.Models;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<ListController> _logger;

        public HomeController(ILogger<ListController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "List");
            }
            return View();
        }
        public async Task<IActionResult> Login(string Role)
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, Role));
            claims.Add(new Claim(ClaimTypes.Name, Role));
            claims.Add(new Claim(ClaimTypes.Role, Role));

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync(principal,
                new AuthenticationProperties()
                {
                    IsPersistent = false,  ExpiresUtc = DateTime.Now.AddMinutes(10)
                });

            return RedirectToAction("Index", "List");
        }

        public  IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
