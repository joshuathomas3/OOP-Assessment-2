using System;

namespace CMP1903_A1_2324
{
    internal class Game
    {
        public void MainGame()
        {
            bool menuOptionValid = false;
            int menuOptionInt = 0;

            while (menuOptionValid == false)
            {
                Console.WriteLine("Game Menu (Please input an option between 1 - 4) \n \n 1.) Play SevensOut" +
                                  "\n 2.) Play ThreeOrMore \n 3.) View Statistics Data \n 4.) Perform Tests \n");

                string menuOptionString = Console.ReadLine();

                try
                {
                    menuOptionInt = Convert.ToInt32(menuOptionString);

                    if (menuOptionInt < 1 || menuOptionInt > 4)
                    {
                        Console.WriteLine("Integer out of bounds. Please enter a number between 1 and 4. \n");
                    }
                    else
                    {
                        menuOptionValid = true;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Input. Please enter an integer between 1 and 4. \n");
                }
            }

            switch (menuOptionInt)
            {
                case 1:
                    Console.WriteLine("Play SevensOut");
                    break;
                case 2:
                    Console.WriteLine("Play ThreeOrMore");
                    break;
                case 3:
                    Console.WriteLine("View Statistics data");
                    break;
                case 4:
                    Console.WriteLine("Perform Tests");
                    break;
            }

        }

    }
}
