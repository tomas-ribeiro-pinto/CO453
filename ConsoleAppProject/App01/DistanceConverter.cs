using System;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App01
{
    /// <summary>
    /// This application allows a user to convert from metres, miles or feet.
    /// There is also a available Web Application Version of this app.
    /// </summary>
    /// <author>
    /// Tomás Pinto Version 6th March 2022
    /// </author>
    public class DistanceConverter
    {
        public const double FEET_IN_MILES = 5280;
        public const double FEET_IN_METRES = 3.28;
        public const double METRES_IN_MILES = 1609.34;

        public const string MILES = "Miles";
        public const string FEET = "Feet";
        public const string METRES = "Metres";

        private string[] choices = { "Miles", "Feet", "Metres" };

        public string convertFrom { get; set; }
        public string convertTo { get; set; }

        public double FromDistance { get; set; }
        public double ToDistance { get; set; }
        public double convertExpression { get; set; }
        private String choice = ConsoleHelper.choiceNo.ToString();

        /// <summary>
        /// This method runs the converter console app.
        /// It allows to convert miles, metres or feet.
        /// </summary>
        public void Run()
        {
            OutputHeader();

            SelectUnitFrom();
            SelectUnitTo();
            ConvertUnit();

            CalculateDistance();
        }

        /// <summary>
        /// Outputs the header at the top of the app with
        /// a brief summary of the application function.
        /// </summary>
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

        /// <summary>
        /// Select a unit (Miles, Feet or Metres) to convert from
        /// </summary>
        private void SelectUnitFrom()
        {
            Console.WriteLine();
            Console.WriteLine(" Select the unit you want to convert from");
            // Uses prompt method from ConsoleHelper
            // to ask the user for a choice 
            choice = ConsoleHelper.SelectChoice(choices).ToString();

            if (choice == "1")
                convertFrom = "Miles";

            else if (choice == "2")
                convertFrom = "Feet";

            else if (choice == "3")
                convertFrom = "Metres";

            Console.WriteLine($" You have chosen to convert {convertFrom}");
        }

        /// <summary>
        /// Select a unit (Miles, Feet or Metres) to convert to
        /// </summary>
        private void SelectUnitTo()
        {
            Console.WriteLine(" Select the unit you want to convert to");
            choice = ConsoleHelper.SelectChoice(choices).ToString();

            if (choice == "1")
                convertTo = "Miles";

            else if (choice == "2")
                convertTo = "Feet";

            else if (choice == "3")
                convertTo = "Metres";

            // If the user tries to convert from to the same unit
            // Display this error:
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

        /// <summary>
        /// This method associates the Convert Expression
        /// for the specific case of the user's choices
        /// </summary>
        public void ConvertUnit()
        {
            if (convertFrom == "Miles" && convertTo == "Feet")
                convertExpression = FEET_IN_MILES;

            else if (convertFrom == "Miles" && convertTo == "Metres")
                convertExpression = METRES_IN_MILES;

            else if (convertFrom == "Metres" && convertTo == "Miles")
                convertExpression = 1 / METRES_IN_MILES;

            else if (convertFrom == "Metres" && convertTo == "Feet")
                convertExpression = FEET_IN_METRES;

            else if (convertFrom == "Feet" && convertTo == "Metres")
                convertExpression = 1 / FEET_IN_METRES;

            else if (convertFrom == "Feet" && convertTo == "Miles")
                convertExpression = 1 / FEET_IN_MILES;

        }

        /// <summary>
        /// Convert distance inputted by the user using
        /// the above Convert Expression.
        /// </summary>
        private void CalculateDistance()
        {
            InputDistance(convertFrom);
            Math.Round(ToDistance = FromDistance * convertExpression, 1);
            OutputDistance();
        }

        /// <summary>
        /// Input Distance method using Console Helper Validation Methods
        /// </summary>
        /// <param name="convertFrom">What unit is being converted</param>
        /// <returns>Distance to be converted</returns>
        private double InputDistance(String convertFrom)
        {
            String prompt = $" Please input the distance in {convertFrom} > ";
            return FromDistance = ConsoleHelper.InputNumber(prompt);
        }

        /// <summary>
        /// Outputs the convertion and asks for further convertions
        /// </summary>
        private void OutputDistance()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" " + FromDistance + $" {convertFrom} is " + ToDistance + $" {convertTo}!");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" Do you want to convert any other numbers? yes/no");
            if (Console.ReadLine() == "yes")
            {
                Console.WriteLine();
                Run();
            }
            else
            {
                Console.WriteLine();
                Program.Run();
            }
        }

        /// <summary>
        /// This method is used by the web version of this application
        /// to convert the distance inputted by the user on the web app
        /// </summary>
        public void ConvertWebDistance()
        {
            ConvertUnit();
            ToDistance = FromDistance * convertExpression;
        }
    }
}
