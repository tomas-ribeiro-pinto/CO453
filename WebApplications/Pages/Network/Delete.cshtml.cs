using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplications.Data;
using WebApplications.Network;

namespace WebApplications.Pages.Network
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplications.Data.ApplicationDbContext _context;

        public DeleteModel(WebApplications.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MessagePost MessagePost { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MessagePost = await _context.Messages.FirstOrDefaultAsync(m => m.PostId == id);

            if (MessagePost == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MessagePost = await _context.Messages.FindAsync(id);

            if (MessagePost != null)
            {
                _context.Messages.Remove(MessagePost);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
