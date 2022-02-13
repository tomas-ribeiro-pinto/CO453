using System;

namespace ConsoleAppProject.App01
{
    /// <summary>
    /// Please describe the main features of this App
    /// </summary>
    /// <author>
    /// Student Name version 0.1
    /// </author>
    public class DistanceConverter
    {
        public const double FEET_IN_MILES = 5280;
        public const double FEET_IN_METRES = 0.30;
        public const double MILES_IN_METRES = 1609.34;
        public const double MILES_IN_FEET = 1 / FEET_IN_MILES;
        public const double METRES_IN_FEET = 1 / FEET_IN_METRES;
        public const double METRES_IN_MILES = 1 / MILES_IN_METRES;
        private double miles;
        private double feet;
        private double metres;
        private String number;
        private String convertFrom;
        private String convertTo;

        /// <summary>
        /// This method runs the converter app.
        /// It allows 
        /// </summary>
        public void Run()
        {
            OutputHeader();

            SelectUnitFrom();
            SelectUnitTo();
            ConvertUnits();

            OutputFooter();
        }

        private static void OutputHeader()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine(" ====================================================================");
            Console.WriteLine("                       App01 | Distance converter                    ");
            Console.WriteLine(" This application alows a user to convert from metres, miles or feet ");
            Console.WriteLine(" ====================================================================");
            Console.WriteLine();
        }

        private void SelectUnitFrom()
        {
            Console.WriteLine(" Select the unit you want to convert from, by inputting the selection number");
            Console.WriteLine();
            Console.WriteLine(" 1 - Miles");
            Console.WriteLine(" 2 - Feet");
            Console.WriteLine(" 3 - Metres");
            Console.WriteLine();

            convertFrom = Console.ReadLine();
        }

        private void SelectUnitTo()
        {
            Console.WriteLine();
            Console.WriteLine(" Select the unit you want to convert to, by inputting the selection number");
            Console.WriteLine();

            if(convertFrom == "2" || convertFrom == "3")
                Console.WriteLine(" 1 - Miles");
            if (convertFrom == "1" || convertFrom == "3")
                Console.WriteLine(" 2 - Feet");
            if (convertFrom == "1" || convertFrom == "2")
                Console.WriteLine(" 3 - Metres");

            Console.WriteLine();

            convertTo = Console.ReadLine();
            Console.WriteLine();
        }

        private void ConvertUnits()
        {
            if (convertFrom == "1" && convertTo == "2")
                CalculateMilesToFeet();

            if (convertFrom == "1" && convertTo == "3")
                CalculateMilesToMetres();

            if (convertFrom == "2" && convertTo == "1")
                CalculateFeetToMiles();

            if (convertFrom == "2" && convertTo == "3")
                CalculateFeetToMetres();

            if (convertFrom == "3" && convertTo == "1")
                CalculateMetresToMiles();

            if (convertFrom == "3" && convertTo == "2")
                CalculateMetresToFeet();
        }

        private void CalculateMilesToFeet()
        {
            InputMiles();
            feet = miles * FEET_IN_MILES;
            Math.Round(feet, 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" " + miles + " miles is " + feet + " feet.");
        }

        private void CalculateMilesToMetres()
        {
            InputMiles();
            metres = miles * METRES_IN_MILES;
            Math.Round(metres, 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" " + miles + " miles is " + metres + " metres.");
        }

        private void CalculateFeetToMiles()
        {
            InputFeet();
            miles = feet * MILES_IN_FEET;
            Math.Round(miles, 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" " + feet + " feet is " + miles + " miles.");
        }

        private void CalculateFeetToMetres()
        {
            InputFeet();
            metres = feet * METRES_IN_FEET;
            Math.Round(metres, 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" " + feet + " feet is " + metres + " metres.");
        }

        private void CalculateMetresToMiles()
        {
            InputMetres();
            miles = metres * MILES_IN_METRES;
            Math.Round(miles, 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" " + metres + " metres is " + miles + " miles.");
        }

        private void CalculateMetresToFeet()
        {
            InputMetres();
            feet = metres * FEET_IN_METRES;
            Math.Round(feet, 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" " + metres + " metres is " + feet + " feet.");
        }

        private void InputMiles()
        {
            Console.Write(" Please input the distance in miles > ");
            number = Console.ReadLine();
            miles = Convert.ToDouble(number);
        }

        private void InputFeet()
        {
            Console.Write(" Please input the distance in feet > ");
            number = Console.ReadLine();
            feet = Convert.ToDouble(number);
        }

        private void InputMetres()
        {
            Console.Write(" Please input the distance in metres > ");
            number = Console.ReadLine();
            metres = Convert.ToDouble(number);
        }

        private void OutputFooter()
        {
            Console.WriteLine(" Do you want to convert any other numbers?");
            if(Console.ReadLine() == "yes")
                Run();
        }
    }
}
