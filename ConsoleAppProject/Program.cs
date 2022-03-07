using ConsoleAppProject.App01;
using ConsoleAppProject.App02;
using ConsoleAppProject.App03;
using ConsoleAppProject.Helpers;
using System;

namespace ConsoleAppProject
{
    /// <summary>
    /// The main method in this class is called first
    /// when the application is started.  It will be used
    /// to start App01 to App05 for CO453 CW1
    /// 
    /// This Project has been modified by:
    /// Tomás Pinto 07/02/2022
    /// </summary>
    public static class Program
    {

        private static string[] choices = { "Distance Converter", "BMI Calculator", "Student Marking System" };
        private static String choice = ConsoleHelper.choiceNo.ToString();

        private static DistanceConverter Convert = new DistanceConverter();
        private static BMI Calculator = new BMI();
        private static StudentGrades Marks = new StudentGrades();

        public static void Main(string[] args)
        {
            Run();

        }

        public static void Run()
        {
            OutputHeader();
            SelectChoice();
        }

        private static void SelectChoice()
        {

            Console.WriteLine();
            Console.WriteLine(" Select the app you want to launch");
            choice = ConsoleHelper.SelectChoice(choices).ToString();

            if (choice == "1")
                Convert.Run();

            else if (choice == "2")
                Calculator.Run();

            else if (choice == "3")
                Marks.Run();
        }

        private static void OutputHeader()
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine();
            Console.WriteLine(" =================================================");
            Console.WriteLine("    BNU CO453 Applications Programming 2021-2022! ");
            Console.WriteLine("                    by Tomás Pinto                ");
            Console.WriteLine(" =================================================");
            Console.WriteLine();
        }
    }
}
