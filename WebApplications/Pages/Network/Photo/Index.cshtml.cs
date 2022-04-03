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
    public class IndexModel : PageModel
    {
        private readonly WebApplications.Data.ApplicationDbContext _context;

        public IndexModel(WebApplications.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<PhotoPost> PhotoPost { get;set; }

        public async Task OnGetAsync()
        {
            PhotoPost = await _context.Photos.ToListAsync();
        }

        public ActionResult OnGetLike(int id)
        {
            var photoPost = _context.Photos.Find(id);

            if (photoPost == null)
            {
                return NotFound();
            }
            else
            {
                photoPost.Like();
            }

            try
            {
                _context.Update(photoPost);
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
            var photoPost = _context.Photos.Find(id);

            if (photoPost == null)
            {
                return NotFound();
            }
            else
            {
                photoPost.Unlike();
            }

            try
            {
                _context.Update(photoPost);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return Redirect(Url.Action("Index") + $"#{id}");
        }

        [BindProperty]
        public Comment Comment { get; set; }

        public ActionResult OnPost(int id)
        {
            var photoPost = _context.Photos.Find(id);

            if (photoPost == null)
            {
                return NotFound();
            }
            else
            {
                Comment Comment = new Comment();
                Comment.PostId = id;
                photoPost.Comments.Add(Comment);
            }

            try
            {
                _context.Update(photoPost);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return Redirect(Url.Action("Index") + $"#{id}");
        }

        /**
        public async Task<IActionResult> OnPost(int id)
        {
            Comment comment = new Comment();
            comment.PostId = id;

            _context.Add(comment);
            await _context.SaveChangesAsync();

            return Redirect(Url.Action("Index") + $"#{id}");
        }
        */
    }
}
