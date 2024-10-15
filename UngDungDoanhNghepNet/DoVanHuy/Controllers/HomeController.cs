using DoVanHuy.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DoVanHuy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult vidu(int a, int b)
        {
            string msg = "";
            int x = a; int y = b;
            while (x != y)
            {
                if (x > y) { x = x - y; }
                else { y = y - x; }
            }
            msg = string.Format("UCLN cua {0} va{1} la {2}", a, b, x);
            Content(msg);
            return View();
           
        }
        public IActionResult lop()
        {
            return View();
            
        }
        public IActionResult Index1()
        {
            return View();
        }
        public IActionResult Index()
        {
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
