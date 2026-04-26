using System.ComponentModel.DataAnnotations;

namespace OrderManagementMVC.Models
{
    public class Order
    {
        public int OrderID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        public int AgentID { get; set; }
        public Agent? Agent { get; set; }

        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}