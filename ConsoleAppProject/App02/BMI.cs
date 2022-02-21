using System;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App02
{
    /// <summary>
    /// This application allows a user to calculate their
    /// Body Mass Index using metric or imperial system.
    /// </summary>
    /// <author>
    /// Tomás Pinto version 1.0
    /// </author>
    public class BMI
    {
        private string[] choiceSystem = { "Metric System", "Imperial System" };

        private String unitSystem;
        private String choice = ConsoleHelper.choiceNo.ToString();

        private String unitWeight;
        private String unitHeight;

        private static double weight;
        private static double height;
        private double outputValue;
        
        public void Run()
        {
            OutputHeader();

            SelectSystem();
            InputValue();
            CalculateBMI();

            OutputResult();

        }

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

        private void SelectSystem()
        {
            Console.WriteLine();
            Console.WriteLine(" Select the Unit System you want to use to calculate BMI");
            choice = ConsoleHelper.SelectChoice(choiceSystem).ToString();

            if (choice == "1")
            {
                unitSystem = "Metric System";
                unitWeight = "Kilograms";
                unitHeight = "Metres";
            }

            else if (choice == "2")
            {
                unitSystem = "Imperial System";
                unitWeight = "Pounds";
                unitHeight = "Inches";
            }


            Console.WriteLine($" You have chosen to calculate BMI in the {unitSystem}");
        }

        private void InputValue()
        {
            String promptWeight = $" Please input the weight in {unitWeight} > ";
            weight = ConsoleHelper.InputNumber(promptWeight);

            String promptHeight = $" Please input the height in {unitHeight} > ";
            height = ConsoleHelper.InputNumber(promptHeight);
        }

        private double CalculateBMI()
        {
            // Check what Unit System the user selected
            // and then calculate BMI according to the System
            if(unitSystem == "Metric System")
            {
                // How to calculate BMI using Metric System:
                //    weight(Kg)/ [height(m)]^2
                outputValue = Math.Round(weight / (height * height), 1);
            }

            else
            {
                // How to calculate BMI using Imperial System:
                //    weight(lb) * 703 / [height(in)]^2 
                outputValue = Math.Round((weight * 703) / (height * height), 1);
            }

            return outputValue;
        }

        private void OutputResult()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine(" The Body Mass Index of a person with " + weight + $" {unitWeight} and " + height + $" {unitHeight} is:");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"                         {outputValue}");
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
