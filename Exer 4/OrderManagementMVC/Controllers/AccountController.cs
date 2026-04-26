using Microsoft.AspNetCore.Mvc;
using OrderManagementMVC.Models;

namespace OrderManagementMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Account/Login
        public IActionResult Login()
        {
            // Nếu đã login rồi thì redirect về Home
            if (HttpContext.Session.GetString("UserName") != null)
                return RedirectToAction("Index", "Home");

            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = _context.Users.FirstOrDefault(u =>
                u.UserName == model.UserName &&
                u.Password == model.Password &&
                u.Lock == false);

            if (user == null)
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng, hoặc tài khoản đã bị khóa.");
                return View(model);
            }

            // Lưu session
            HttpContext.Session.SetString("UserName", user.UserName);
            HttpContext.Session.SetInt32("UserID", user.UserID);

            return RedirectToAction("Index", "Home");
        }

        // GET: /Account/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}