using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagementMVC.Models;

namespace OrderManagementMVC.Controllers
{
    public class StatisticsController : BaseController
    {
        private readonly AppDbContext _context;

        public StatisticsController(AppDbContext context)
        {
            _context = context;
        }

        // Sản phẩm bán chạy nhất
        public async Task<IActionResult> BestItems()
        {
            var result = await _context.OrderDetails
                .Include(od => od.Item)
                .GroupBy(od => new { od.ItemID, od.Item!.ItemName })
                .Select(g => new
                {
                    ItemID = g.Key.ItemID,
                    ItemName = g.Key.ItemName,
                    TotalQty = g.Sum(x => x.Quantity),
                    TotalAmt = g.Sum(x => x.Quantity * x.UnitAmount)
                })
                .OrderByDescending(x => x.TotalQty)
                .ToListAsync();

            ViewBag.Title = "Sản phẩm bán chạy nhất";
            return View("BestItems", result);
        }

        // Sản phẩm được đặt bởi từng đại lý
        public async Task<IActionResult> ItemsByAgent(int? agentId)
        {
            ViewBag.Agents = await _context.Agents.ToListAsync();
            ViewBag.SelectedAgent = agentId;

            if (agentId == null) return View("ItemsByAgent", null);

            var result = await _context.OrderDetails
                .Include(od => od.Order).ThenInclude(o => o!.Agent)
                .Include(od => od.Item)
                .Where(od => od.Order!.AgentID == agentId)
                .Select(od => new
                {
                    AgentName = od.Order!.Agent!.AgentName,
                    ItemName = od.Item!.ItemName,
                    od.Quantity,
                    od.UnitAmount,
                    OrderDate = od.Order.OrderDate
                })
                .ToListAsync();

            return View("ItemsByAgent", result);
        }

        // Đại lý đã mua những sản phẩm nào
        public async Task<IActionResult> AgentsByItem(int? itemId)
        {
            ViewBag.Items = await _context.Items.ToListAsync();
            ViewBag.SelectedItem = itemId;

            if (itemId == null) return View("AgentsByItem", null);

            var result = await _context.OrderDetails
                .Include(od => od.Order).ThenInclude(o => o!.Agent)
                .Include(od => od.Item)
                .Where(od => od.ItemID == itemId)
                .Select(od => new
                {
                    AgentName = od.Order!.Agent!.AgentName,
                    Address = od.Order.Agent!.Address,
                    ItemName = od.Item!.ItemName,
                    od.Quantity,
                    od.UnitAmount,
                    OrderDate = od.Order.OrderDate
                })
                .ToListAsync();

            return View("AgentsByItem", result);
        }
    }
}