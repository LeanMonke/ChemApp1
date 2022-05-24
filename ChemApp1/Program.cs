using System;
using System.Collections.Generic;

namespace ChemApp1
{
    class Program
    {
        //Global variables

        static double mostEfficient = -1;
        static double leastEfficient = 99999999;
        static List<string> chemApp1 = new List<string>() { "Propane","Chlorine Dioxide","HypoChlorite", "Quaternary Ammonium Compounds", "Hydrogen Peroxide"};
        static List<int> chosenChemIndex = new List<int>();
        static List<float> chemListRating = new List<float>();
        static void Main(string[] args)
        {

            //Start of component1

            //Welcome message And Discription
            Console.WriteLine("Menu\n" +
                "this is an cleaning product efficiency app\n" +
                "this app will ask you which chemical you would like to test\n" +
                "then the Computer will generate a random number of germ colonies\n" +
                "then it will generate a random amount of time between 1 and 399 minutes\n" +
                "after this it will then see how many colonies are remaining ");




            //Ask user to continue or quit
            //Check the users response
            bool flag1 = true;
            while (flag1)
            {
                Console.WriteLine("Press <Enter> to carry on with the program or type 'quit' to end the program");
                string checkChoice = Console.ReadLine();

                if (checkChoice.Equals(""))
                {
                    Console.WriteLine("Running Test");
                    ChemApp();
                }
                else if (checkChoice.Equals("quit"))
                {
                    flag1 = false;
                    Console.WriteLine("Than you for using Chemical App");
                }
                else 
                {
                    Console.WriteLine("error you entered an invalid value");
                }
            }
        }


        static int nameOne(string question, int min, int max) 
        {
            string ErrorMSG = $"Error:Enter a number between {min} and {max}\n" +
                $"=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n" +
                $"-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n" +
                $"|I|I|I|I|I|I|I|I|I|I|I|I|I|I|I|I|I|I|I|I|I|I|I|I|I|I|I|I|I|I|I|I|I|I|I|I|I|I|I|\n";
            while (true) 
            {
                try
                {
                    Console.WriteLine(question);

                    int chemIndex = Convert.ToInt32(Console.ReadLine());

                    if (chosenChemIndex.Contains(chemIndex - 1))
                    {
                        Console.WriteLine("ERROR: you can't enter the same value more than once\n");
                    }
                    else
                    {
                        if (chemIndex >= min && chemIndex <= max)
                        {
                            return chemIndex - 1;
                        }
                        else
                        {
                            Console.WriteLine(ErrorMSG);

                        }
                    }


                }
                catch
                {
                    Console.WriteLine(ErrorMSG);
                }
            
            }
        }
        static void ChemApp()
        {
            //Entering the chemical name
            Console.WriteLine("Choose the chemical you will be usingfrom this list:\n" );
            string menu = "Type number of the chemical that you will be using from this list\n" +
                "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n";

            for (int chemNum = 0; chemNum < chemApp1.Count; chemNum++)
            {
                menu += $"{chemNum + 1}. {chemApp1[chemNum]}\n";





            }

            //Chemical name 
            chosenChemIndex.Add(nameOne(menu, 1, 5));


            int chemName = 0;

            double germAverage;
            int randGerms;
            int randTime;
            int secondRandGerm;
            double sumEfficiencies = 0;

            for (int numTest = 1; numTest < 6; numTest++)
            {
                Console.WriteLine($"Test {numTest}");

                //A Random Number Will Now Be Generated
                Console.WriteLine("\nThank you for entering a chemical name.\n" +
                "the Computer will now generate random number\n");
                //Random will be introduced
                Random rand = new Random();
                //random germs 1
                randGerms = rand.Next(500, 1000);


                // generating a random time 
                Random rand2 = new Random();
                randTime = rand.Next(1, 81);

                //random germs 2
                Random rand3 = new Random();
                secondRandGerm = rand.Next(1, 499);
                //finding the average between the two germ numbers

                double efficiency = randGerms - secondRandGerm / randTime;

                efficiency = Math.Round(efficiency, 1);

                Console.WriteLine($"the efficiency rating of {chemApp1[chosenChemIndex[chosenChemIndex.Count-1]]} is {efficiency}");

                sumEfficiencies += efficiency;

           

                double efficiencyRating = sumEfficiencies / 5;
                Console.WriteLine($"{chemApp1[chemName]} has a final efficiency rating of {efficiencyRating}");

                if (efficiencyRating > mostEfficient)
                {
                    mostEfficient = efficiencyRating;

                }

                if (efficiencyRating < leastEfficient)
                {
                    leastEfficient = efficiencyRating;
                }
            }
        }










    }




}

