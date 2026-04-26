using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace OrderManagementMVC.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                context.Result = RedirectToAction("Login", "Account");
                return;
            }
            // Truyền username ra Layout
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            base.OnActionExecuting(context);
        }
    }
}