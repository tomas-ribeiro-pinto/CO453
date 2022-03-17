using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleAppProject.App03;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplications.Pages.Marking;

namespace WebApplications.Pages.Marking
{
    public class StatisticsModel : PageModel
    {
        [BindProperty]
        public int Sum { get; set; }
        public double Mean { get; set; }
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public int GradeA { get; set; }
        public int GradeB { get; set; }
        public int GradeC { get; set; }
        public int GradeD { get; set; }
        public int GradeF { get; set; }

        public void OnGet()
        {
            Sum = IndexModel.Marks.Length;
            Mean = (double)IndexModel.Marks.Sum() / (double)Sum;
            Minimum = IndexModel.Marks.Min();
            Maximum = IndexModel.Marks.Max();

            GradeA = (int)IndexModel.GradeProfile[0];
            GradeB = (int)IndexModel.GradeProfile[1];
            GradeC = (int)IndexModel.GradeProfile[2];
            GradeD = (int)IndexModel.GradeProfile[3];
            GradeF = (int)IndexModel.GradeProfile[4];
        }

    }
}
