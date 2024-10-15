using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using web1.Models;

namespace web1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TimNgay(int month, int year)
        {
            int daysInMonth;

            // Tìm số ngày dựa vào tháng và năm
            switch (month)
            {
                case 1: // Tháng 1
                case 3: // Tháng 3
                case 5: // Tháng 5
                case 7: // Tháng 7
                case 8: // Tháng 8
                case 10: // Tháng 10
                case 12: // Tháng 12
                    daysInMonth = 31;
                    break;
                case 4: // Tháng 4
                case 6: // Tháng 6
                case 9: // Tháng 9
                case 11: // Tháng 11
                    daysInMonth = 30;
                    break;
                case 2: // Tháng 2
                    if (DateTime.IsLeapYear(year))
                    {
                        daysInMonth = 29;
                    }
                    else
                    {
                        daysInMonth = 28;
                    }
                    break;
                default:
                    daysInMonth = 0; // Trường hợp tháng không hợp lệ
                    break;
            }

            // Sử dụng ViewBag để truyền dữ liệu sang View
            ViewBag.Month = month;
            ViewBag.Year = year;
            ViewBag.DaysInMonth = daysInMonth;

            // Trả về View
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
