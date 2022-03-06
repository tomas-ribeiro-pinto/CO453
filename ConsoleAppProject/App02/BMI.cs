using System;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App02
{
    /// <summary>
    /// This application allows a user to calculate their
    /// Body Mass Index using metric or imperial system.
    /// There is also a available Web Application Version of this app.
    /// </summary>
    /// <author>
    /// Tomás Pinto Version 6th March 2022
    /// </author>
    public class BMI
    {
        public string[] choiceSystem = { "Metric System", "Imperial System" };

        public string UnitSystem { get; set; }
        private string choice = ConsoleHelper.choiceNo.ToString();

        public string UnitWeight { get; set; }
        public string UnitHeight { get; set; }

        public double Weight { get; set; }
        public double Height { get; set; }
        public double OutputValue { get; set; }

        /// <summary>
        /// This method runs the BMI calculator console app.
        /// It allows to calculate a person's Body Mass Index
        /// using their height and weight.
        /// </summary>
        public void Run()
        {
            OutputHeader();

            SelectSystem();
            InputValue();
            CalculateBMI();

            OutputResult();

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
            Console.WriteLine("                         App02 | BMI Calculator                      ");
            Console.WriteLine("         This application allows a user to calculate their           ");
            Console.WriteLine("           Body Mass Index using metric or imperial system           ");
            Console.WriteLine(" ====================================================================");
            Console.WriteLine();
        }

        /// <summary>
        /// Select in what unit system is the calculation going to be done
        /// </summary>
        private void SelectSystem()
        {
            Console.WriteLine();
            Console.WriteLine(" Select the Unit System you want to use to calculate BMI");
            // Uses prompt method from ConsoleHelper
            // to ask the user for a choice 
            choice = ConsoleHelper.SelectChoice(choiceSystem).ToString();

            if (choice == "1")
            {
                UnitSystem = "Metric System";
                UnitWeight = "Kilograms";
                UnitHeight = "Metres";
            }

            else if (choice == "2")
            {
                UnitSystem = "Imperial System";
                UnitWeight = "Pounds";
                UnitHeight = "Inches";
            }


            Console.WriteLine($" You have chosen to calculate BMI in the {UnitSystem}");
        }

        /// <summary>
        /// This method asks the user for their weight and height
        /// </summary>
        private void InputValue()
        {
            String promptWeight = $" Please input the weight in {UnitWeight} > ";
            Weight = ConsoleHelper.InputNumber(promptWeight);

            String promptHeight = $" Please input the height in {UnitHeight} > ";
            Height = ConsoleHelper.InputNumber(promptHeight);
        }

        /// <summary>
        /// Calculates the BMI using the defined mathematical formulas
        /// </summary>
        /// <returns>The calculation value</returns>
        public double CalculateBMI()
        {
            // Check what Unit System the user selected
            // and then calculate BMI according to the System
            if(UnitSystem == "Metric System")
            {
                // How to calculate BMI using Metric System:
                //    weight(Kg)/ [height(m)]^2
                OutputValue = Math.Round(Weight / (Height * Height), 1);
            }

            else
            {
                // How to calculate BMI using Imperial System:
                //    weight(lb) * 703 / [height(in)]^2 
                OutputValue = Math.Round((Weight * 703) / (Height * Height), 1);
            }

            return OutputValue;
        }

        /// <summary>
        /// Outputs the conversion and asks for further calculations
        /// </summary>
        private void OutputResult()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine(" The Body Mass Index of a person with " + Weight + $" {UnitWeight} and " + Height + $" {UnitHeight} is:");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"                         {OutputValue}");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" Do you want to calculate another BMI? yes/no");
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
    }
}
