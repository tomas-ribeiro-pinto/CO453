using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ConsoleAppProject.Helpers;
using System.Linq;

namespace ConsoleAppProject.App03
{
    /// <summary>
    /// This application allows the user to award marks
    /// to students, see overall statistics like mean value
    /// and overall fail percentage of the student group.
    /// </summary>
    /// <author>
    /// Tomás Pinto Version 14th March 2022
    /// </author>
    public class StudentGrades
    {
        public string[] Students { get; set; }
        public int[] Marks { get; set; }
        public int[] GradeProfile { get; set; }
        public double Mean { get; set; }
        public int MinMark { get; set; }
        public int MaxMark { get; set; }

        public int MINIMUM { get; set; } = 0;
        public int MAXIMUM { get; set; } = 100;
        public int PERCENTAGE { get; set; } = 100;


        public void Run()
        {
            Students = new string [] { "John", "Ana", "Mary", "Peter", "Thomas", "Martin", "Derek", "Nicholas", "Justin", "Sandra"};
            Marks = new int[Students.Length];
            GradeProfile = new int[5];

            OutputHeader();
            InputMarks();
            OutputGrades();
            OutputStatistics();
            Program.Run();
        }

        /// <summary>
        /// Outputs the header at the top of the app with
        /// a brief summary of the application function.
        /// </summary>
        private static void OutputHeader()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine(" =================================================================");
            Console.WriteLine("                App03 by Tomás Pinto | Student Marks              ");
            Console.WriteLine("         This application allows tutors to enter student marks    ");
            Console.WriteLine("                     and convert them into grades.                ");
            Console.WriteLine(" =================================================================");
            Console.WriteLine();

        }

        private void InputMarks()
        {
            Console.WriteLine("Please enter a mark for each student\n");
            int index = 0;

            foreach(string name in Students)
            {
                int mark = (int)ConsoleHelper.InputNumber($"Enter mark for {name} > ", MINIMUM, MAXIMUM);
                Marks[index] = mark;
                index = index + 1;
            }
        }

        private void OutputGrades()
        {
            ConsoleHelper.OutputTitle("List of Student Marks and Grades:");
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            for (int i = 0; i < Marks.Length; i++)
            {
                Grades outputGrade = CalculateGradeProfile(Marks[i]);
                Console.WriteLine($"{Students[i]} ------- Mark = {Marks[i]} Grade = {outputGrade}");
            }
        }

        public Grades ConvertToGrades(int mark)
        {
            if (mark < 40)
            {
                return Grades.F;
            }

            else if (mark > 39 && mark < 50)
            {
                return Grades.D;
            }

            else if (mark > 49 && mark < 60)
            {
                return Grades.C;
            }

            else if (mark > 59 && mark < 70)
            {
                return Grades.B;
            }

            else if (mark > 69)
            {
                return Grades.A;
            }

            return Grades.X;
        }

        public Grades CalculateGradeProfile(int mark)
        {
            Grades grade = ConvertToGrades(mark);
            GradeProfile[(int)grade - 1] = GradeProfile[(int)grade - 1] + (PERCENTAGE / Marks.Length);
            return grade;
        }

        public void OutputStatistics()
        {
            Mean = Marks.Sum() / Marks.Length;
            MinMark = Marks.Min();
            MaxMark = Marks.Max();

            ConsoleHelper.OutputTitle("Statistics:");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Mean Mark: {Mean} \nMinimum Mark: {MinMark} \nMaximum Mark: {MaxMark}");
            ConsoleHelper.OutputTitle("Overall Grades:");
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            for (int i = 0; i < GradeProfile.Length; i++)
            {
                Console.WriteLine($"Grade {Enum.GetName(typeof(Grades), i+1)}-- {GradeProfile[i]}%");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPress enter to go back to the main menu...");
            Console.ReadLine();
        }
    }
}
