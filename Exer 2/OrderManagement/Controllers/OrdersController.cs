using OrderManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderManagement.Controllers
{
    public class OrdersController : Controller
    {
        private SaleManagementDBEntities db = new SaleManagementDBEntities();

        // GET: Hiển thị form lập đơn hàng
        public ActionResult Index()
        {
            var orders = db.Orders
                .Include("Agent")
                .ToList();
            return View(orders);
        }

        public ActionResult Print(int id)
        {
            var order = db.Orders
                .Include("Agent")
                .Include("OrderDetails.Item")
                .FirstOrDefault(o => o.OrderID == id);
            if (order == null) return HttpNotFound();
            return View(order);
        }

        public ActionResult Create()
        {
            ViewBag.Agents = new SelectList(db.Agents.ToList(), "AgentID", "AgentName");
            ViewBag.Items = db.Items.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Order order, int[] itemIDs, int[] quantities, decimal[] unitAmounts)
        {
            if (itemIDs == null || itemIDs.Length == 0)
            {
                ViewBag.Error = "Vui lòng thêm ít nhất 1 sản phẩm!";
                ViewBag.Agents = new SelectList(db.Agents.ToList(), "AgentID", "AgentName");
                ViewBag.Items = db.Items.ToList();
                return View(order);
            }

            db.Orders.Add(order);
            db.SaveChanges();

            for (int i = 0; i < itemIDs.Length; i++)
            {
                var detail = new OrderDetail
                {
                    OrderID = order.OrderID,
                    ItemID = itemIDs[i],
                    Quantity = quantities[i],
                    UnitAmount = unitAmounts[i]
                };
                db.OrderDetails.Add(detail);
            }
            db.SaveChanges();
            return RedirectToAction("Print", new { id = order.OrderID });
        }

    }
}