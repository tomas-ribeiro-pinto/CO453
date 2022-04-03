using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplications.Data;
using WebApplications.Network;

namespace WebApplications.Pages.Network.Photo
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplications.Data.ApplicationDbContext _context;

        public DeleteModel(WebApplications.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PhotoPost PhotoPost { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PhotoPost = await _context.Photos.FirstOrDefaultAsync(m => m.PostId == id);

            if (PhotoPost == null)
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

            PhotoPost = await _context.Photos.FindAsync(id);

            if (PhotoPost != null)
            {
                _context.Photos.Remove(PhotoPost);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
