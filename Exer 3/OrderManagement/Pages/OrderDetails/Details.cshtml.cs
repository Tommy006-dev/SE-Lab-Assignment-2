using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Models;

namespace OrderManagement.Pages.OrderDetails
{
    public class DetailsModel : PageModel
    {
        private readonly OrderManagement.Models.SaleManagementDbContext _context;

        public DetailsModel(OrderManagement.Models.SaleManagementDbContext context)
        {
            _context = context;
        }

        public OrderDetail OrderDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderdetail = await _context.OrderDetails.FirstOrDefaultAsync(m => m.Id == id);

            if (orderdetail is not null)
            {
                OrderDetail = orderdetail;

                return Page();
            }

            return NotFound();
        }
    }
}
