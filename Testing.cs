using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Testing
    {
        static void Main(string[] args)
        {
            // New Game object is instantiated and values and sum of die are returned to array
            Game game = new Game();
            game.GameMenu();
        }

        public int GetTestingOption()
        {
            bool menuOptionValid = false;
            int userTestOptionInt = 0;

            while (menuOptionValid == false)
            {
                Console.WriteLine("Which game would you like to test (1/2)");
                string userTestOption = Console.ReadLine();

                try
                {
                    userTestOptionInt = Convert.ToInt32(userTestOption);

                    if (userTestOptionInt > 2 || userTestOptionInt < 1)
                    {
                        Console.WriteLine("Input out of bound. Please enter an integer between 1 and 2.");
                    }
                    else
                    {
                        menuOptionValid = true;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please enter an integer between 1 and 2");
                }
            }

            return userTestOptionInt;

        }

        public static void SevensOutTotalTest(int dieAddition)
        {
            Debug.Assert(dieAddition != 7);
        }

        public static void ThreeOrMoreTotalTest(int player1Points, int player2Points)
        {
            Debug.Assert(player1Points < 19);
            Debug.Assert(player2Points < 19);
        }

    }
}
