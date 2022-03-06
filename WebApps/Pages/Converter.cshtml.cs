using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleAppProject.App01;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppsCO453.Views.Home
{

    public class DistanceConverterModel : PageModel
    {
        [BindProperty]
        public DistanceConverter App01 { get; set; }

        public void OnGet()
        {
            ViewData["Message"] = "";
        }

        /// <summary>
        /// When the form is submitted, the result is outputted
        /// </summary>
        public void OnPost()
        {
            App01.ConvertWebDistance();

            ViewData["Message"] = $"{App01.FromDistance} {App01.convertFrom} = " +
                $"{App01.ToDistance.ToString("0.00")} {App01.convertTo}";
        }
    }
}
