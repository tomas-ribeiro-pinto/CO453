using System;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App01
{
    /// <summary>
    /// Please describe the main features of this App
    /// </summary>
    /// <author>
    /// Tomás Pinto Version 1.0
    /// </author>
    public class DistanceConverter
    {
        public const double FEET_IN_MILES = 5280;
        public const double FEET_IN_METRES = 3.28;
        public const double METRES_IN_MILES = 1609.34;
        string[] choices = { "Miles", "Feet", "Metres" };
        private String convertFrom;
        private String convertTo;
        private double fromUnit;
        private double toUnit;
        private double convertExpression;
        private String choice = ConsoleHelper.choiceNo.ToString();

        /// <summary>
        /// This method runs the converter app.
        /// It allows for converting miles, metres or feet.
        /// </summary>
        public void Run()
        {
            OutputHeader();

            SelectUnitFrom();
            SelectUnitTo();
            ConvertUnits();

        }

        private static void OutputHeader()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine(" ====================================================================");
            Console.WriteLine("                       App01 | Distance converter                    ");
            Console.WriteLine(" This application allows a user to convert from metres, miles or feet ");
            Console.WriteLine(" ====================================================================");
            Console.WriteLine();
        }

        private void SelectUnitFrom()
        {
            Console.WriteLine();
            Console.WriteLine(" Select the unit you want to convert from");
            choice = ConsoleHelper.SelectChoice(choices).ToString();

            if (choice == "1")
                convertFrom = "Miles";

            if (choice == "2")
                convertFrom = "Feet";

            if (choice == "3")
                convertFrom = "Metres";

            Console.WriteLine($" You have chosen to convert {convertFrom}");
        }

        private void SelectUnitTo()
        {
            Console.WriteLine(" Select the unit you want to convert to");
            choice = ConsoleHelper.SelectChoice(choices).ToString();

            if (choice == "1")
                convertTo = "Miles";

            if (choice == "2")
                convertTo = "Feet";

            if (choice == "3")
                convertTo = "Metres";

            if (convertFrom == convertTo)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine($" YOU CANNOT CONVERT {convertFrom} TO {convertFrom} !");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                SelectUnitTo();
            }
            else
            {
                Console.WriteLine($" You have chosen to convert {convertFrom} to {convertTo}");
            }
        }

        private void ConvertUnits()
        {
            if (convertFrom == "Miles" && convertTo == "Feet")
                convertExpression = FEET_IN_MILES;

            if (convertFrom == "Miles" && convertTo == "Metres")
                convertExpression = METRES_IN_MILES;

            if (convertFrom == "Metres" && convertTo == "Miles")
                convertExpression = 1 / METRES_IN_MILES;

            if (convertFrom == "Metres" && convertTo == "Feet")
                convertExpression = FEET_IN_METRES;

            if (convertFrom == "Feet" && convertTo == "Metres")
                convertExpression = 1 / FEET_IN_METRES;

            if (convertFrom == "Feet" && convertTo == "Miles")
                convertExpression = 1 / FEET_IN_MILES;

            InputDistance(convertFrom);
            Math.Round(toUnit = fromUnit * convertExpression, 1);
            OutputDistance();

        }

        private double InputDistance(String convertFrom)
        {
            Console.Write($" Please input the distance in {convertFrom} > ");
            return fromUnit = Convert.ToDouble(Console.ReadLine());
        }
        
        private void OutputDistance()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" " + fromUnit + $" {convertFrom} is " + toUnit + $" {convertTo}!");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" Do you want to convert any other numbers? yes/no");
            if (Console.ReadLine() == "yes")
                Console.WriteLine();
                Run();
        }
    }
}
