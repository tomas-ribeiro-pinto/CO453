using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ConsoleAppProject.App03;
using WebApplications.Data;
using System.Collections;

namespace WebApplications.Pages.Marking
{
    public class IndexModel : PageModel
    {
        private readonly WebApplications.Data.ApplicationDbContext _context;

        public IndexModel(WebApplications.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; }
        public static int[] Marks { get; set; }
        public static Grades[] GradeProfile { get; set; }

        public async Task OnGetAsync()
        {
            Student = await _context.Students.ToListAsync();

            Marks = new int[Student.Count()];
            GradeProfile = new Grades[5];

            for (int i=0; i < Student.Count(); i++)
            {
                Grades grade = Student[i].Grade;
                Marks[i] = Student[i].Mark;
                GradeProfile[(int)grade - 1] = GradeProfile[(int)grade - 1] + 1;
            }
        }
    }
}
