using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Models;

namespace OrderManagement.Pages.Reports
{
    public class FilterModel : PageModel
    {
        private readonly SaleManagementDbContext _context;
        public FilterModel(SaleManagementDbContext context)
            => _context = context;

        // Top items
        public List<BestItemDto> BestItems { get; set; } = new();

        // Danh sách agent cho dropdown
        public List<Agent> AgentList { get; set; } = new();

        // Kết quả lọc theo agent
        public List<ItemByAgentDto> ItemsByAgent { get; set; } = new();

        public int? SelectedAgentId { get; set; }

        public void OnGet(int? agentId)
        {
            SelectedAgentId = agentId;

            // Top 5 mặt hàng bán chạy
            BestItems = _context.OrderDetails
                .GroupBy(od => od.Item.ItemName)
                .Select(g => new BestItemDto
                {
                    ItemName = g.Key,
                    TotalQty = g.Sum(x => x.Quantity ?? 0)
                })
                .OrderByDescending(x => x.TotalQty)
                .Take(5)
                .ToList();

            // Danh sách agent
            AgentList = _context.Agents.ToList();

            // Lọc theo agent
            if (agentId.HasValue)
            {
                ItemsByAgent = _context.OrderDetails
                    .Where(od => od.Order.AgentId == agentId)
                    .Select(od => new ItemByAgentDto
                    {
                        ItemName = od.Item.ItemName,
                        Quantity = od.Quantity ?? 0,
                        UnitAmount = od.UnitAmount ?? 0
                    })
                    .ToList();
            }
        }
    }

    // DTO classes
    public class BestItemDto
    {
        public string ItemName { get; set; }
        public int TotalQty { get; set; }
    }

    public class ItemByAgentDto
    {
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitAmount { get; set; }
    }
}