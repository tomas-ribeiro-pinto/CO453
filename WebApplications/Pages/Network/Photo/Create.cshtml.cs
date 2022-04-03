using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplications.Data;
using WebApplications.Network;

namespace WebApplications.Pages.Network.Photo
{
    public class CreateModel : PageModel
    {
        private readonly WebApplications.Data.ApplicationDbContext _context;

        public CreateModel(WebApplications.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PhotoPost PhotoPost { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Photos.Add(PhotoPost);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
