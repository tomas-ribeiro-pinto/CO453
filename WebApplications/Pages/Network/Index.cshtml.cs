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
    public class IndexModel : PageModel
    {

        private readonly WebApplications.Data.ApplicationDbContext _context;

        public IndexModel(WebApplications.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<MessagePost> MessagePost { get;set; }

        public async Task OnGetAsync()
        {
            MessagePost = await _context.Messages.ToListAsync();
        }
    }
}
