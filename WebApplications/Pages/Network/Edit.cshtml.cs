using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplications.Data;
using WebApplications.Network;

namespace WebApplications.Pages.Network
{
    public class EditModel : PageModel
    {
        private readonly WebApplications.Data.ApplicationDbContext _context;

        public EditModel(WebApplications.Data.ApplicationDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MessagePost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessagePostExists(MessagePost.PostId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MessagePostExists(int id)
        {
            return _context.Messages.Any(e => e.PostId == id);
        }
    }
}
