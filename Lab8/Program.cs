using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] studentNames = {"Chuck Buckwheat", "Rip Steakflank", "Big McLargeHuge", "Dirk Hardpec", "Butch Deadlift", "Buff Drinklots",
                "Gristle McThornbody", "Flint Ironstag", "Buck Plankchest", "Slab Manmuscle"};

            string[] studentHometowns = { "Springfield, USA", "Beefdip City, Florida", "Whoville", "Bollywood, CA", "Biceps, NY", "Triceps, NY",
                "Sydney, Australia", "Mount Hyjal, Kalimdor", "Mount Olympus, Greece", "on the planet Mars"};

            string[] studentFavoriteFoods = { "Chicken Beaks", "Tuna Eyeballs", "Wasp Cookies", "Protein Cakes", "Horse Meat", "Fermented Cabbage",
                "Raw Eggs", "Mayonnaise Crackers", "Kangaroo Meat", "Alligator Meat"};

            int studentNumber = int.Parse(GetValidInput(@"^[1-9]$|^[1][0]$", "Welcome to the hardcore C# class. Which badass would you like to learn more about? (Enter a number 1-10): ",
                "Sorry, that badass does not exist. Please enter a valid number (1-10): ", "A null value is not allowed! Please enter a number between 1 and 10: "));

            string knowMore = "y";

            while (Regex.IsMatch(knowMore, @"^[yY]$|^[yY][eE][sS]$"))
            {
                #region userChoice
                string userChoice = GetValidInput(@"^[hH][oO][mM][eE][tT][oO][wW][nN]$|^[fF][aA][vV][oO][rR][iI][tT][eE] [fF][oO][oO][dD]$",
                $"#{studentNumber} is {studentNames[studentNumber - 1]}. What hardcore fact would you like to know about? (enter \"hometown\" or \"favorite food\"): ",
                "That choice is not an option. Please choose a valid data, either \"hometown\" or \"favorite food\".",
                "A null value huh? Nice try Drew. Enter \"hometown\" or \"favorite food\".");
                #endregion

                if (Regex.IsMatch(userChoice, @"^[hH][oO][mM][eE][tT][oO][wW][nN]$"))
                {
                    Console.WriteLine($"{studentNames[studentNumber - 1]}'s hometown is {studentHometowns[studentNumber - 1]}.");
                }
                else
                {
                    Console.WriteLine($"{studentNames[studentNumber - 1]}'s favorite food is {studentFavoriteFoods[studentNumber - 1]}.");
                }
                //Console.WriteLine("Would you like to know more? (enter yes or no): ");
                knowMore = GetValidInput(@"^[yY]$|^[yY][eE][sS]$|^[nN]$|^[nN][oO]$", "Would you like to know more? (enter yes or no): ",
                    "That wasn't a yes or no, so I'm unsure what you want. Please enter yes or no: ",
                    "That wasn't a yes or no, so I'm unsure what you want. Please enter yes or no: ");
            }
            Console.WriteLine("Thanks for your time, check back next lab for additional info.");
            Console.ReadKey();
        }

        public static string GetValidInput(string pattern, string userMessage, string errorMessage, string nullMessage)
        {
            Console.WriteLine(userMessage);
            while (true)
            {
                string userInput = Console.ReadLine();
                if (userInput == null)
                {
                    Console.WriteLine(nullMessage);
                }
                else if (!Regex.IsMatch(userInput, pattern))
                {
                    Console.WriteLine(errorMessage);
                }
                else
                {
                    return userInput;
                }
            }
        }
    }
}
