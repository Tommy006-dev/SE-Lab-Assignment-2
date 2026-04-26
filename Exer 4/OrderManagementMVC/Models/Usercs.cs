using System.ComponentModel.DataAnnotations;

namespace OrderManagementMVC.Models
{
    public class User
    {
        public int UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; } = string.Empty;

        public bool Lock { get; set; } = false;
    }
}