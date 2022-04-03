using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplications.Data;
using WebApplications.Pages.Network;

namespace WebApplications.Pages.Network.Comments
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplications.Data.ApplicationDbContext _context;

        public DetailsModel(WebApplications.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Comment Comment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Comment = await _context.Comment
                .Include(c => c.Post).FirstOrDefaultAsync(m => m.CommentId == id);

            if (Comment == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
