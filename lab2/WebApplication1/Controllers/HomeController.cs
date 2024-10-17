using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DangNhap(DangNhap model)
        {
            if (model.TaiKhoan == "huy" && model.MatKhau == "123")
            {
                ViewBag.Message = $"Xin chào, {model.TaiKhoan}";
                return View("Index");
            }
            else
            {
                ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không chính xác.");
                return View();
            }
        }
        public IActionResult DanhSach()
        {
            var sinhVienList = new List<SinhVien>
    {
        new SinhVien { MaSV = "SV001", TenSV = "Do Van Huy 1", NgaySinh = new DateTime(2003, 2, 28), GioiTinh = "Nam", DiaChi = "Ha Noi", DienThoai = "0123456789", HomThu = "dovanhuy2003za@gmail.com" },
        new SinhVien { MaSV = "SV002", TenSV = "Do Van Huy 2", NgaySinh = new DateTime(2001, 6, 15), GioiTinh = "Nam", DiaChi = "HCM", DienThoai = "0987654321", HomThu = "dovanhuy2003za@gmail.com" },
        new SinhVien { MaSV = "SV003", TenSV = "Do Van Huy 3", NgaySinh = new DateTime(1999, 12, 22), GioiTinh = "Nam", DiaChi = "Da Nang", DienThoai = "0932456789", HomThu = "dovanhuy2003za@gmail.com" },
        new SinhVien { MaSV = "SV004", TenSV = "Do Van Huy 4", NgaySinh = new DateTime(2002, 8, 3), GioiTinh = "Nam", DiaChi = "Can Tho", DienThoai = "0901234567", HomThu = "dovanhuy2003za@gmail.com" },
        new SinhVien { MaSV = "SV005", TenSV = "Do Van Huy 5", NgaySinh = new DateTime(2003, 3, 30), GioiTinh = "Nam", DiaChi = "Hai Phong", DienThoai = "0923456789", HomThu = "dovanhuy2003za@gmail.com" }
            };
            return View(sinhVienList);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index1()
        {
            var sinhVienList = new List<SinhVien>
    {
        new SinhVien { MaSV = "SV001", TenSV = "Do Van Huy 1", NgaySinh = new DateTime(2003, 2, 28), GioiTinh = "Nam", DiaChi = "Ha Noi", DienThoai = "0123456789", HomThu = "dovanhuy2003za@gmail.com" },
        new SinhVien { MaSV = "SV002", TenSV = "Do Van Huy 2", NgaySinh = new DateTime(2001, 6, 15), GioiTinh = "Nam", DiaChi = "HCM", DienThoai = "0987654321", HomThu = "dovanhuy2003za@gmail.com" },
        new SinhVien { MaSV = "SV003", TenSV = "Do Van Huy 3", NgaySinh = new DateTime(1999, 12, 22), GioiTinh = "Nam", DiaChi = "Da Nang", DienThoai = "0932456789", HomThu = "dovanhuy2003za@gmail.com" },
        new SinhVien { MaSV = "SV004", TenSV = "Do Van Huy 4", NgaySinh = new DateTime(2002, 8, 3), GioiTinh = "Nam", DiaChi = "Can Tho", DienThoai = "0901234567", HomThu = "dovanhuy2003za@gmail.com" },
        new SinhVien { MaSV = "SV005", TenSV = "Do Van Huy 5", NgaySinh = new DateTime(2003, 3, 30), GioiTinh = "Nam", DiaChi = "Hai Phong", DienThoai = "0923456789", HomThu = "dovanhuy2003za@gmail.com" }
    };

            return View(sinhVienList);
           
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
