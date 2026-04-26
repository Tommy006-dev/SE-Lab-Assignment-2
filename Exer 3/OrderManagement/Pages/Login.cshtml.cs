using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrderManagement.Models;

namespace OrderManagement.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SaleManagementDbContext _context;

        public LoginModel(SaleManagementDbContext context)
        {
            _context = context;
        }

        [BindProperty] public string UserName { get; set; }
        [BindProperty] public string Password { get; set; }
        public string ErrorMessage { get; set; }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            var user = _context.Users.FirstOrDefault(u =>
                u.Email == UserName &&
                u.Password == Password &&
                u.Lock == false);

            if (user != null)
            {
                HttpContext.Session.SetString("UserName", user.UserName);
                return RedirectToPage("/Index");
            }

            ErrorMessage = "Sai tài khoản hoặc mật khẩu!";
            return Page();
        }
    }
}