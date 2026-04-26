using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementMVC.Models
{
    public class Item
    {
        public int ItemID { get; set; }

        [Required]
        [StringLength(100)]
        public string ItemName { get; set; } = string.Empty;

        [StringLength(20)]
        public string? Size { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; }

        [StringLength(200)]
        public string? Description { get; set; }

        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}