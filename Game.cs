using System;
using System.Numerics;

namespace CMP1903_A1_2324
{
    internal class Game
    {
        public void GameMenu()
        {
            bool menuOptionValid = false;
            int menuOptionInt = 0;
            bool quitGame = false;
            Statistics statistics = new Statistics();
            SevensOut sevensOut = new SevensOut();
            ThreeOrMore threeOrMore = new ThreeOrMore();
            Testing testing = new Testing();

            while (quitGame == false)
            {
                Console.Clear();

                while (menuOptionValid == false)
                {
                    Console.WriteLine("\nGame Menu (Please input an option between 1 - 5) \n \n 1.) Play SevensOut" +
                                    "\n 2.) Play ThreeOrMore \n 3.) View Statistics Data \n 4.) Perform Tests \n 5.) Quit Program \n");

                    string menuOptionString = Console.ReadLine();

                    try
                    {
                        menuOptionInt = Convert.ToInt32(menuOptionString);

                        if (menuOptionInt < 1 || menuOptionInt > 5)
                        {
                            Console.WriteLine("Integer out of bounds. Please enter a number between 1 and 5. \n");
                        }
                        else
                        {
                            menuOptionValid = true;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid Input. Please enter an integer between 1 and 5. \n");
                    }
                }

                switch (menuOptionInt)
                {
                    case 1:
                        Console.WriteLine("\nPlay SevensOut:\n");
                        statistics = sevensOut.SevensOutGame(statistics, false);
                        menuOptionValid = false;
                        break;
                    case 2:
                        Console.WriteLine("Play ThreeOrMore");
                        statistics = threeOrMore.ThreeOrMoreGame(statistics, false);
                        menuOptionValid = false;
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("\nView Statistics data: \n");
                        Console.WriteLine("Total SevensOut Turns of last game: " + statistics.GetSevensOutTurnCount());
                        Console.WriteLine("Total SevensOut Games: " + statistics.GetSevensOutPlayCount());

                        Console.WriteLine("Total ThreeOrMore Games: " + statistics.GetThreeOrMorePlayCount());
                        Console.WriteLine("\nTo return to menu, press any key... ");

                        Console.ReadKey();
                        menuOptionValid = false;
                        break;
                    case 4:
                        Console.WriteLine("\nPerform Tests:\n");
                        int testingOption = testing.GetTestingOption();

                        if (testingOption == 1)
                        {
                            statistics = sevensOut.SevensOutGame(statistics, true);
                        }
                        else
                        {
                            statistics = threeOrMore.ThreeOrMoreGame(statistics, true);
                        }
                        menuOptionValid = false;
                        break;
                    case 5:
                        Console.WriteLine("Quitting program...");
                        quitGame = true;
                        break;
                }
            }

        }

    }
}
