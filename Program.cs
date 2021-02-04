using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ContriesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Welcome to the Countries Maintenance Application!");

                // Menu to selection the next action
                Menu();
                Console.WriteLine();
                Console.Write("Enter menu number: ");
                string userInput = Console.ReadLine();

                // Decision making
                //  -- Create a method to handle the logic
                DecisionMaker(userInput);
                //Console.ReadKey();
            } while (true);

        }

        public static void Menu()
        {
            Console.WriteLine("1 - See the list of countries");
            Console.WriteLine("2 - Add a country");
            Console.WriteLine("3 - Exit");
        }

        public static void DecisionMaker(string userInput)
        {
            if(userInput == "1")
            {
                DisplayCountries();
            }

            if(userInput == "2")
            {
                AddCountry();
            }

            if(userInput == "3")
            {
                Console.WriteLine("Aidios amigo!");
                Environment.Exit(0);
            }
        }

        // Refactor into user a Country Model.
        private static void AddCountry()
        {
            Console.Write("Name of country: ");
            string countryName = Console.ReadLine();

            ContriesTextFile.WriteCountries(countryName);

            Console.WriteLine("This country has been saved!");
        }

        public static void DisplayCountries()
        {
            List<string> countries = ContriesTextFile.GetCountries();

            foreach(string country in countries)
            {
                Console.WriteLine(country);
            }
        }
    }

    // Add the country class with Properties for name, language, colors

    public class ContriesTextFile
    {
        private static readonly string filePath = @"C:\ContriesApp\contries.txt";


        // Work on converting a string back into an object.
        public static List<string> GetCountries()
        {
            
            List<string> countries = File.ReadAllLines(filePath).ToList();
            //countries.Add(Console.ReadLine);

            return countries;
        }

        // Work on coverting an object into a string to write to the file.
        public static void WriteCountries(string country)
        {            
                File.AppendAllText(filePath, Environment.NewLine + country);    
        }
    }
}
