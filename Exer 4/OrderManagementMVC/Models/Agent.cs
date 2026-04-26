using System.ComponentModel.DataAnnotations;

namespace OrderManagementMVC.Models
{
    public class Agent
    {
        public int AgentID { get; set; }

        [Required]
        [StringLength(100)]
        public string AgentName { get; set; } = string.Empty;

        [StringLength(200)]
        public string? Address { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}