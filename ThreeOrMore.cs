using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class ThreeOrMore
    {
        public void ThreeOrMoreGame()
        {
            int[] die = new int[5];
            int[] dieCount = new int[6];
            var Die = new Die();
            int highestCount = 0;

            int player1Points = 0;
            int player2Points = 0;
            int whosTurn = 0;
            bool pointsOver21 = false;

            ClearConsole();
            OutputWhosTurn(whosTurn);
            RollAllDie(die, Die);
            Console.WriteLine("Array: " + die[0] + die[1] + die[2] + die[3] + die[4]);
            GetDieCount(die, dieCount);
            highestCount = GetHighestCount(dieCount);

            while (pointsOver21 == false)
            {
                CalculatePoints(die, ref dieCount, Die, ref highestCount, ref player1Points, ref player2Points, ref whosTurn, ref pointsOver21);
            }

            GameOverOutput(player1Points, player2Points);
        }

        private static void CalculatePoints(int[] die, ref int[] dieCount, Die Die, ref int highestCount, ref int player1Points, ref int player2Points, ref int whosTurn, ref bool pointsOver21)
        {
            switch (highestCount)
            {
                case 1:

                    if (whosTurn % 2 == 0)
                    {
                        Console.WriteLine("One of a kind rolled, zero points. Total points for P1: " + player1Points);
                    }
                    else
                    {
                        Console.WriteLine("One of a kind rolled, zero points. Total points for P2: " + player2Points);
                    }

                    ClearConsole();

                    if (player1Points > 19 || player2Points > 19)
                    {
                        pointsOver21 = true;
                    }
                    else
                    {
                        whosTurn += 1;
                        OutputWhosTurn(whosTurn);
                        RollAllDie(die, Die);
                        Console.WriteLine("Array: " + die[0] + die[1] + die[2] + die[3] + die[4]);
                        dieCount = new int[6];
                        GetDieCount(die, dieCount);
                        highestCount = GetHighestCount(dieCount);
                    }

                    break;

                case 2:

                    int userRethrowOptionInt = 0;
                    List<int> arrayFlags = new List<int>();
                    bool menuOptionValid = false;


                    while (menuOptionValid == false)
                    {
                        try
                        {
                            Console.WriteLine("Two of a kind rolled. Would you like to rethrow all or remaining die? (1/2)");
                            string userRethrowOption = Console.ReadLine();

                            userRethrowOptionInt = Convert.ToInt32(userRethrowOption);

                            if (userRethrowOptionInt < 1 || userRethrowOptionInt > 2)
                            {
                                Console.WriteLine("Input not in range. Please enter a number between 1 and 2");
                            }
                            else
                            {
                                menuOptionValid = true;
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid input, please enter a number between 1 and 2");
                        }
                    }


                    if (userRethrowOptionInt == 1)
                    {
                        RollAllDie(die, Die);
                    }

                    if (userRethrowOptionInt == 2)
                    {
                        for (int i = 0; i < dieCount.Length; i++)
                        {
                            if (dieCount[i] == 2)
                            {
                                arrayFlags.Add(i + 1);
                            }
                        }

                        foreach (var item in arrayFlags)
                        {
                            Console.WriteLine("Item: " + item);
                        }

                        bool overwritePosition = true;

                        for (int i = 0; i < die.Length; i++)
                        {
                            overwritePosition = true;

                            foreach (var item in arrayFlags)
                            {
                                if (die[i] == item)
                                {
                                    overwritePosition = false;
                                }
                            }

                            if (overwritePosition == true)
                            {
                                die[i] = Die.Roll();
                            }
                        }
                    }

                    Console.Clear();

                    if (player1Points > 19 || player2Points > 19)
                    {
                        pointsOver21 = true;
                    }
                    else
                    {
                        whosTurn += 2;
                        OutputWhosTurn(whosTurn);
                        Console.WriteLine("Array: " + die[0] + die[1] + die[2] + die[3] + die[4]);
                        dieCount = new int[6];
                        GetDieCount(die, dieCount);
                        highestCount = GetHighestCount(dieCount);
                    }

                    break;

                case 3:

                    if (whosTurn % 2 == 0)
                    {
                        player1Points += 3;
                        Console.WriteLine("Three of a kind rolled. Total Points for P1: " + player1Points);
                    }
                    else
                    {
                        player2Points += 3;
                        Console.WriteLine("Three of a kind rolled. Total Points for P2: " + player2Points);
                    }

                    ClearConsole();

                    if (player1Points > 19 || player2Points > 19)
                    {
                        pointsOver21 = true;
                    }
                    else
                    {
                        whosTurn += 1;
                        OutputWhosTurn(whosTurn);
                        RollAllDie(die, Die);
                        Console.WriteLine("Array: " + die[0] + die[1] + die[2] + die[3] + die[4]);
                        dieCount = new int[6];
                        GetDieCount(die, dieCount);
                        highestCount = GetHighestCount(dieCount);
                    }

                    break;
                case 4:

                    if (whosTurn % 2 == 0)
                    {
                        player1Points += 6;
                        Console.WriteLine("Four of a kind rolled. Total Points for P1: " + player1Points);
                    }
                    else
                    {
                        player2Points += 6;
                        Console.WriteLine("Four of a kind rolled. Total Points for P2: " + player2Points);
                    }

                    ClearConsole();

                    if (player1Points > 19 || player2Points > 19)
                    {
                        pointsOver21 = true;
                    }
                    else
                    {
                        whosTurn += 1;
                        OutputWhosTurn(whosTurn);
                        RollAllDie(die, Die);
                        Console.WriteLine("Array: " + die[0] + die[1] + die[2] + die[3] + die[4]);
                        dieCount = new int[6];
                        GetDieCount(die, dieCount);
                        highestCount = GetHighestCount(dieCount);
                    }

                    break;
                case 5:

                    if (whosTurn % 2 == 0)
                    {
                        player1Points += 12;
                        Console.WriteLine("Five of a kind rolled. Total Points for P1: " + player1Points);
                    }
                    else
                    {
                        player2Points += 12;
                        Console.WriteLine("Five of a kind rolled. Total Points for P2: " + player2Points);
                    }

                    ClearConsole();

                    if (player1Points > 19 || player2Points > 19)
                    {
                        pointsOver21 = true;
                    }
                    else
                    {
                        whosTurn += 1;
                        OutputWhosTurn(whosTurn);
                        RollAllDie(die, Die);
                        Console.WriteLine("Array: " + die[0] + die[1] + die[2] + die[3] + die[4]);
                        dieCount = new int[6];
                        GetDieCount(die, dieCount);
                        highestCount = GetHighestCount(dieCount);
                    }

                    break;
            }
        }

        static void GetDieCount(int[] die, int[] dieCount)
        {
            // Procedure to get the number of instances of each value rolled.
            // Iterates across the rolled die array, adding 1 whenever the particular instance occurs.
            // The index position refers to the value that is being (counted + 1)
            // I.e. The value in index position 2 refers to the number of occurences that the value 3 has been rolled.

            for (int i = 0; i < die.Length; i++)
            {
                switch (die[i])
                {
                    case 1:
                        dieCount[0] += 1;
                        break;
                    case 2:
                        dieCount[1] += 1;
                        break;
                    case 3:
                        dieCount[2] += 1;
                        break;
                    case 4:
                        dieCount[3] += 1;
                        break;
                    case 5:
                        dieCount[4] += 1;
                        break;
                    case 6:
                        dieCount[5] += 1;
                        break;
                }
            }
        }

        private static int GetHighestCount(int[] dieCount)
        {
            // The highest count is the number of times the value with the most occurences has appeared in the array.
            // Function is used to calculate if the array is "n of a kind". 
            // Outputs highest couunt and returns it to the user.

            int highestCount = 0;

            for (int i = 0; i < dieCount.Length; i++)
            {
                if (dieCount[i] > highestCount)
                {
                    highestCount = dieCount[i];
                    System.Threading.Thread.Sleep(100);
                }
            }

            Console.WriteLine("Highest Count: " + highestCount);
            return highestCount;
        }

        private static void OutputWhosTurn(int whosTurn)
        {
            // The turn is calculated by doing Mod 2 on the whosTurn variable, if it is 0 it is player 1's go. 
            // If the value is odd, it is player 2's turn. The whosTurn variable is incremented to reflect the 
            // next player's turn. 

            if (whosTurn % 2 == 0)
            {
                Console.WriteLine("Player 1's turn");
            }
            else
            {
                Console.WriteLine("Player 2's turn");
            }
        }

        private static void RollAllDie(int[] die, Die Die)
        {
            // Iterates through Die array and rolls new values.
            // Sleep method to ensure the Random() seed is unique for each role.

            for (int i = 0; i < die.Length; i++)
            {
                die[i] = Die.Roll();
                System.Threading.Thread.Sleep(10);
            }
        }

        private static void ClearConsole()
        {
            // Clears the console buffer after each player's turn after key press. Ensures the info on screen is for the specfic player's turn.
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        private static void GameOverOutput(int player1Points, int player2Points)
        {
            // Method executes after either player reaches 20 points or higher.

            if (player1Points > player2Points)
            {
                Console.WriteLine("\nPlayer 1 wins! Press any key to go back to menu. ");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\nPlayer 2 wins! Press any key to go back to menu. ");
                Console.ReadKey();
            }
        }
    }
}
