using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        private static List<User> _users = new List<User>(); // Danh sách người dùng tạm thời
        private static int _nextId = 1; // Đếm ID người dùng mới

        // Đăng ký
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Id = _nextId++,
                    Username = model.Username,
                    Password = model.Password, // Lưu mật khẩu cần mã hóa
                    Fullname = model.Fullname,
                    Gender = model.Gender,
                    Birthday = model.Birthday,
                    Address = model.Address,
                    Phone = model.Phone,
                    Email = model.Email,
                    Status = true
                };
                _users.Add(user);
                return RedirectToAction("Login");
            }
            return View(model);
        }

        // Đăng nhập
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _users.SingleOrDefault(u => u.Username == model.Username && u.Password == model.Password);
                if (user != null)
                {
                    // Thực hiện đăng nhập
                    return RedirectToAction("UserList");
                }
                ModelState.AddModelError("", "Invalid username or password");
            }
            return View(model);
        }

        // Quên mật khẩu
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _users.SingleOrDefault(u => u.Email == model.Email);
                if (user != null)
                {
                    // Gửi liên kết đặt lại mật khẩu qua email
                    // (Giả định gửi thành công)
                    return RedirectToAction("ForgotPasswordConfirmation");
                }
                ModelState.AddModelError("", "Email not found");
            }
            return View(model);
        }

        // Đặt mật khẩu mới
        [HttpGet]
        public IActionResult ResetPassword(string token)
        {
            return View(new ResetPasswordViewModel { Token = token });
        }

        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _users.SingleOrDefault(u => u.Id.ToString() == model.Token);
                if (user != null)
                {
                    user.Password = model.NewPassword; // Lưu mật khẩu mới cần mã hóa
                    return RedirectToAction("Login");
                }
                ModelState.AddModelError("", "Invalid token");
            }
            return View(model);
        }

        // Danh sách người dùng
        public IActionResult UserList()
        {
            return View(_users);
        }

        // Chi tiết người dùng
        public IActionResult Details(int id)
        {
            var user = _users.Find(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
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
