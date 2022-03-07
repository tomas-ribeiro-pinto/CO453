using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App03
{
    /// <summary>
    /// At the moment this class just tests the
    /// Grades enumeration names and descriptions
    /// </summary>
    public class StudentGrades
    {
        public string[] Students { get; set; }
        public int[] Marks { get; set; }
        //public int[] GradeProfile { get; set; }
        //public double Mean { get; set; }
        public int MINIMUM { get; set; } = 0;
        public int MAXIMUM { get; set; } = 100;

        public void Run()
        {
            Students = new string [] { "John", "Ana", "Mary", "Peter", "Thomas", "Martin", "Derek", "Nicholas", "Justin", "Sandra"};
            Marks = new int[Students.Length];

            ConsoleHelper.OutputHeading("App03 Student Marks");
            InputMarks();
            //ConvertToGrades();
            OutputGrades();
        }

        private void InputMarks()
        {
            Console.WriteLine("Please enter a mark for each student\n");
            int index = 0;

            foreach(string name in Students)
            {
                int mark = (int)ConsoleHelper.InputNumber($"{name} Enter mark > ", MINIMUM, MAXIMUM);
                Marks[index] = mark;
                index = index + 1;
            }
        }

        private void OutputGrades()
        {
            for(int i = 0; i < Marks.Length; i++)
            {
                Grades grade = ConvertToGrades(Marks[i]);
                Console.WriteLine($"{Students[i]} Mark = {Marks[i]} Grade = {grade}");
            }
        }

        public Grades ConvertToGrades(int mark)
        {
            if (mark < 40)
                return Grades.F;

            else if (mark > 39 && mark < 50)
                return Grades.D;

            else if (mark > 49 && mark < 60)
                return Grades.C;

            else if (mark > 59 && mark < 70)
                return Grades.B;

            else if (mark > 69)
                return Grades.A;

            return Grades.X;
        }
    }
}
