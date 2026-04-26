using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderManagement.Models;

namespace OrderManagement.Controllers
{
    public class AccountController : Controller
    {
        SaleManagementDBEntities db = new SaleManagementDBEntities();

        // GET: Hiển thị trang đăng nhập
        public ActionResult Login()
        {
            return View();
        }

        // POST: Xử lý dữ liệu khi bấm nút Đăng nhập
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "Vui lòng nhập đầy đủ email và mật khẩu";
                return View();
            }
            var user = db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                if (user.Lock == true)
                {
                    ViewBag.Error = "Tài khoản của bạn đã bị khóa!";
                    return View();
                }
                Session["UserID"] = user.UserID;
                Session["UserName"] = user.UserName;

                return RedirectToAction("Index","Main");
            }
            else
            {
                ViewBag.Error = "Email hoặc mật khẩu không đúng!";
                return View();
            }
        }

        // Đăng xuất
        public ActionResult Logout()
        {
            Session.Clear(); // Xóa toàn bộ Session
            return RedirectToAction("Login");
        }
    }
}