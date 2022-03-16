using System;
using System.ComponentModel.DataAnnotations;

namespace ConsoleAppProject.App03
{
    public class Student
    {
        public int StudentId { get; set; }

        [StringLength(20), Required]
        public string Name { get; set; }

        [Range(0, 100)]
        public int Mark { get; set; }


    }
}
