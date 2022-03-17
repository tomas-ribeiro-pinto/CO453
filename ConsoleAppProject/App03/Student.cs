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

        public Grades Grade { get; set; }

        /// Converts marks into grades, as stated in Grades.cs
        /// </summary>
        /// <param name="mark"></param>
        /// <returns>Grade descriptor</returns>
        public void ConvertToGrades()
        {
            if (Mark < 40)
            {
                Grade = Grades.F;
            }

            else if (Mark > 39 && Mark < 50)
            {
                Grade = Grades.D;
            }

            else if (Mark > 49 && Mark < 60)
            {
                Grade = Grades.C;
            }

            else if (Mark > 59 && Mark < 70)
            {
                Grade = Grades.B;
            }

            else if (Mark > 69)
            {
                Grade = Grades.A;
            }

            else
            {
                Grade = Grades.X;
            }
        }

    }
}
