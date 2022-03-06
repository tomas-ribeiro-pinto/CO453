using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleAppProject.App02;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebAppsCO453.Views.Home
{
    public class CalculatorModel : PageModel
    {
        [BindProperty]
        public BMI App02 { get; set; }

        public void OnGet()
        {
            ViewData["Message"] = "";
        }

        /// <summary>
        /// When the form is submitted, the result is outputted
        /// </summary>
        public void OnPost()
        {
            App02.CalculateBMI();

            ViewData["Message"] = $"Your BMI is {App02.OutputValue.ToString("0.0")}";
        }
    }
}