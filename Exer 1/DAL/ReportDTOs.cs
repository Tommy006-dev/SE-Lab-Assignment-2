using System;

namespace DAL
{
    public class BestSellingItemDTO
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public int TotalQty { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class AgentItemDTO
    {
        public int OrderID { get; set; }
        public DateTime? OrderDate { get; set; }
        public string ItemName { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public decimal UnitAmount { get; set; }
        public decimal Total { get; set; }
    }

    public class ItemAgentDTO
    {
        public int OrderID { get; set; }
        public DateTime? OrderDate { get; set; }
        public string AgentName { get; set; }
        public string Address { get; set; }
        public int Quantity { get; set; }
        public decimal UnitAmount { get; set; }
        public decimal Total { get; set; }
    }
}

