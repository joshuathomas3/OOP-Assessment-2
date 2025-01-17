﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class SevensOut
    {
        public Statistics SevensOutGame(Statistics statistics, bool testingEnabled)
        {
            // Initialise New Die Object
            var die = new Die();

            // Initialise die sum counter and while loop condition
            bool totalSeven = false;
            int totalDiceSum = 0;

            if (testingEnabled == false)
            {
                statistics.ResetSevensOutTurns();
                statistics.SevensOutPlayCountIncrement();
            }

            while (totalSeven == false)
            {
                // Rolls the two die, 10ms sleep is added to ensure that the Random() method's seed value is different.
                int die1 = die.Roll();
                System.Threading.Thread.Sleep(10);
                int die2 = die.Roll();

                // Adds the sum of the two die
                int dieAddition = die1 + die2;
                bool dieSumCalculated = false;


                if (die1 == die2)
                {
                    // If the same number is rolled on both die, the addition should be doubled and added to the total count.

                    Console.WriteLine("Rolled: " + die1 + " and " + die2);
                    totalDiceSum = totalDiceSum + (2 * dieAddition);
                    Console.WriteLine("Double rolled, Total: " + totalDiceSum);
                    dieSumCalculated = true;
                    statistics.SevensOutTurnCountIncrement();
                }
                if (dieAddition == 7 && dieSumCalculated == false)
                {
                    // If the sum of die is equal to seven, the game should conclude and output the total points the player has.

                    Console.WriteLine("Rolled: " + die1 + " and " + die2);
                    Console.WriteLine("Total of seven achieved. Game ending.");
                    totalDiceSum = totalDiceSum + dieAddition;
                    Console.WriteLine("Total points for the game: " + totalDiceSum);
                    totalSeven = true;
                    dieSumCalculated = true;
                    statistics.SevensOutTurnCountIncrement();
                }
                if (dieSumCalculated == false)
                {
                    // If two different values are rolled and do not equal seven, the sum should be added to the total.

                    Console.WriteLine("Rolled: " + die1 + " and " + die2);
                    totalDiceSum = totalDiceSum + dieAddition;
                    Console.WriteLine("Total: " + totalDiceSum);
                    dieSumCalculated = true;
                    statistics.SevensOutTurnCountIncrement();
                }

                if (testingEnabled == true)
                {
                    Testing.SevensOutTotalTest(dieAddition);
                }

            }

            Console.WriteLine("\nGame has ended. Please enter any key to return to menu...");
            Console.ReadKey();

            return statistics;

        }
    }
}
