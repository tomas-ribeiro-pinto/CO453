using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace ConsoleAppProject.App03
{
    /// <summary>
    /// Grade A is First Class   : 70 - 100
    /// Grade B is Upper Second  : 60 - 69
    /// Grade C is Lower Second  : 50 - 59
    /// Grade D is Third Class   : 40 - 49
    /// Grade F is Fail          :  0 - 39
    /// </summary>
    public enum Grades
    {
        [Display(Name = "Invalid")]
        [Description("Invalid Grade")]
        X,
        [Display(Name = "A")]
        [Description("BSc(Hons) First Class")]
        A,
        [Display(Name = "B")]
        [Description("BSc(Hons) Upper Second")]
        B,
        [Display(Name = "C")]
        [Description("BSc(Hons) Lower Second")]
        C,
        [Display(Name = "D")]
        [Description("BSc(Hons) Third Class")]
        D,
        [Display(Name = "F")]
        [Description("Referred")]
        F
    }
}
