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
    public class IndexModel : PageModel
    {
        private readonly OrderManagement.Models.SaleManagementDbContext _context;

        public IndexModel(OrderManagement.Models.SaleManagementDbContext context)
        {
            _context = context;
        }

        public IList<OrderDetail> OrderDetail { get;set; } = default!;

        public async Task OnGetAsync()
        {
            OrderDetail = await _context.OrderDetails
                .Include(o => o.Item)
                .Include(o => o.Order).ToListAsync();
        }
    }
}
