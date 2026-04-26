using OrderManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderManagement.Controllers
{
    // 1. TẠO 2 CLASS NÀY ĐỂ TRÁNH LỖI RUNTIME BINDER CỦA VIEWBAG
    public class ReportItemData
    {
        public Item Item { get; set; }
        public int? TotalQty { get; set; }
    }

    public class ReportAgentData
    {
        public Agent Agent { get; set; }
        public Order Order { get; set; }
        public int? Quantity { get; set; }
        public decimal? UnitAmount { get; set; }
    }

    public class ReportController : Controller
    {
        SaleManagementDBEntities db = new SaleManagementDBEntities();

        // GET: Report
        public ActionResult Index(string tab, int? agentID, int? itemID)
        {
            // Luôn load dropdown cho cả 2 tab
            ViewBag.Agents = new SelectList(db.Agents.ToList(), "AgentID", "AgentName");
            ViewBag.Items = new SelectList(db.Items.ToList(), "ItemID", "ItemName");

            // Xác định tab đang active để giữ đúng tab sau khi submit
            ViewBag.ActiveTab = tab ?? "best";

            // Tab 1: Hàng bán chạy – load luôn khi vào trang
            ViewBag.BestItems = db.OrderDetails
                .GroupBy(d => d.Item)
                .Select(g => new ReportItemData // Bỏ kiểu ẩn danh, dùng class cụ thể
                {
                    Item = g.Key,
                    TotalQty = g.Sum(x => x.Quantity)
                })
                .OrderByDescending(x => x.TotalQty)
                .ToList();

            // Tab 2: Đại lý → Hàng hóa
            if (tab == "agent" && agentID.HasValue)
            {
                ViewBag.AgentResult = db.OrderDetails
                    .Where(d => d.Order.AgentID == agentID)
                    .GroupBy(d => d.Item)
                    .Select(g => new ReportItemData // Bỏ kiểu ẩn danh, dùng class cụ thể
                    {
                        Item = g.Key,
                        TotalQty = g.Sum(x => x.Quantity)
                    }).ToList();

                ViewBag.AgentName = db.Agents.Find(agentID)?.AgentName;
            }

            // Tab 3: Hàng hóa → Đại lý
            if (tab == "item" && itemID.HasValue)
            {
                ViewBag.ItemResult = db.OrderDetails
                    .Include("Order")
                    .Include("Order.Agent")
                    .Where(d => d.ItemID == itemID)
                    .Select(d => new ReportAgentData // Bỏ kiểu ẩn danh, dùng class cụ thể
                    {
                        Agent = d.Order.Agent,
                        Order = d.Order,
                        Quantity = d.Quantity,
                        UnitAmount = d.UnitAmount
                    }).ToList();

                ViewBag.ItemName = db.Items.Find(itemID)?.ItemName;
            }

            return View();
        }
    }
}