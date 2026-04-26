using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Models;

namespace OrderManagement.Pages.Agents
{
    public class DetailsModel : PageModel
    {
        private readonly OrderManagement.Models.SaleManagementDbContext _context;

        public DetailsModel(OrderManagement.Models.SaleManagementDbContext context)
        {
            _context = context;
        }

        public Agent Agent { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agent = await _context.Agents.FirstOrDefaultAsync(m => m.AgentId == id);

            if (agent is not null)
            {
                Agent = agent;

                return Page();
            }

            return NotFound();
        }
    }
}
