using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplications.Data;
using WebApplications.Network;

namespace WebApplications.Pages.Network
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
        public MessagePost MessagePost { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Messages.Add(MessagePost);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
