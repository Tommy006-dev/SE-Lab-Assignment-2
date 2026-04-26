using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class ReportRepository
    {
        private SaleManagementDBEntities _db = new SaleManagementDBEntities();

        // ── 1. Top item bán chạy ──────────────────────────────
        public List<BestSellingItemDTO> GetBestSellingItems()
        {
            return _db.OrderDetails
                .GroupBy(od => new { od.ItemID, od.Item.ItemName })
                .Select(g => new BestSellingItemDTO
                {
                    ItemID = g.Key.ItemID ?? 0, // Xử lý int? sang int
                    ItemName = g.Key.ItemName,
                    TotalQty = g.Sum(x => x.Quantity) ?? 0, // Xử lý kết quả Sum int? sang int
                    TotalAmount = g.Sum(x => x.Quantity * x.UnitAmount) ?? 0m // Xử lý decimal? sang decimal
                })
                .OrderByDescending(x => x.TotalQty)
                .ToList();
        }

        // ── 2. Đại lý đã mua những hàng gì ───────────────────
        public List<AgentItemDTO> GetItemsByAgent(int agentId)
        {
            return _db.OrderDetails
                .Where(od => od.Order.AgentID == agentId)
                .Select(od => new AgentItemDTO
                {
                    OrderID = od.OrderID ?? 0,
                    OrderDate = od.Order.OrderDate,
                    ItemName = od.Item.ItemName,
                    Size = od.Item.Size,
                    Quantity = od.Quantity ?? 0,
                    UnitAmount = od.UnitAmount ?? 0m,
                    Total = (od.Quantity ?? 0) * (od.UnitAmount ?? 0m)
                })
                .OrderByDescending(x => x.OrderDate)
                .ToList();
        }

        // ── 3. Hàng này được mua bởi những đại lý nào ────────
        public List<ItemAgentDTO> GetAgentsByItem(int itemId)
        {
            return _db.OrderDetails
                .Where(od => od.ItemID == itemId)
                .Select(od => new ItemAgentDTO
                {
                    OrderID = od.OrderID ?? 0,
                    OrderDate = od.Order.OrderDate,
                    AgentName = od.Order.Agent.AgentName,
                    Address = od.Order.Agent.Address,
                    Quantity = od.Quantity ?? 0,
                    UnitAmount = od.UnitAmount ?? 0m,
                    Total = (od.Quantity ?? 0) * (od.UnitAmount ?? 0m)
                })
                .OrderByDescending(x => x.OrderDate)
                .ToList();
        }
    }
}