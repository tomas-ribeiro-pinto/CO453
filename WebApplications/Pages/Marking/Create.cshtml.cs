using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ConsoleAppProject.App03;
using WebApplications.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApplications.Pages.Marking
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
        public Student Student { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Student.ConvertToGrades();
            _context.Students.Add(Student);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        /**
        public async Task<IActionResult> Analyse()
        {
            var students = await _context.Students.ToListAsync();
            StudentGrades grades = new StudentGrades();
        }
        */
    }
}
