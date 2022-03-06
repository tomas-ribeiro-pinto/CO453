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
        public DistanceConverter App01;

        [BindProperty]
        public String Distance { get; set; }

        public void OnGet()
        {
            App01 = new DistanceConverter();
        }

        public void OnPost()
        {
            App01.fromDistance = Convert.ToDouble(Distance);
            App01.ConvertUnit();
        }
    }
}
