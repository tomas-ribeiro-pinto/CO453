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
    public class DetailsModel : PageModel
    {
        private readonly WebApplications.Data.ApplicationDbContext _context;

        public DetailsModel(WebApplications.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
