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
        //public IList<PhotoPost> PhotoPost { get; set; }
        //public IList<Post> Posts { get; set; }

        public async Task OnGetAsync(string userName)
        {

            MessagePost = await _context.Messages.OrderByDescending(a => a.Timestamp).ToListAsync();

            if (!String.IsNullOrEmpty(userName))
            {
                MessagePost = ((IList<MessagePost>)MessagePost.Where(u => u.Author == userName));
            }
            //PhotoPost = await _context.Photos.ToListAsync();

            //List<Post> Posts = new List<Post>();

            //Posts.AddRange(PhotoPost);
            //Posts.AddRange(MessagePost);


            //var Posts = await _context.Posts.OrderByDescending(a => a.Timestamp).ToArrayAsync();
        }


        public ActionResult OnGetLike(int id)
        {
            var messagePost = _context.Messages.Find(id);

            if (messagePost == null)
            {
                return NotFound();
            }
            else
            {
                messagePost.Like();
            }

            try
            {
                _context.Update(messagePost);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return Redirect(Url.Action("Index") + $"#{id}");
        }

        public ActionResult OnGetUnLike(int id)
        {
            var messagePost = _context.Messages.Find(id);

            if (messagePost == null)
            {
                return NotFound();
            }
            else
            {
                messagePost.Unlike();
            }

            try
            {
                _context.Update(messagePost);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return Redirect(Url.Action("Index") + $"#{id}");
        }
    }
}

