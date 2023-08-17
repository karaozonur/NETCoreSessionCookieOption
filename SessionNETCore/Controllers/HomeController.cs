using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SessionNETCore.Models;
using System.Diagnostics;

namespace SessionNETCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private  IHttpContextAccessor _contextAccessor; 
        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _contextAccessor = contextAccessor;
        }

        public IActionResult Index()
        {
            App _app=new App() { Id=1, Name="veli"};

            HttpContext.Session.SetString("username", _app.Name); // Bilgi Eklemek için
           ; // Bilgilerimizi Getirmek için

            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddDays(1);
            _contextAccessor.HttpContext.Response.Cookies.Append("username", HttpContext.Session.GetString("username"), cookie);

            _contextAccessor.HttpContext.Response.Cookies.Delete("username");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}