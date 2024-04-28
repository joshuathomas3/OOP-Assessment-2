using System;
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
        public void SevensOutGame()
        {
            var die = new Die();

            bool totalSeven = false;
            int totalDiceSum = 0;

            while (totalSeven == false)
            {
                int die1 = die.Roll();
                System.Threading.Thread.Sleep(100);
                int die2 = die.Roll();

                int dieAddition = die1 + die2;
                bool dieSumCalculated = false;


                if (die1 == die2)
                {
                    Console.WriteLine("Rolled: " + die1 + " and " + die2);
                    totalDiceSum = totalDiceSum + (2 * dieAddition);
                    Console.WriteLine("Double rolled, Total: " + totalDiceSum);
                    dieSumCalculated = true;
                }
                if (dieAddition == 7 && dieSumCalculated == false)
                {
                    Console.WriteLine("Rolled: " + die1 + " and " + die2);
                    Console.WriteLine("Total of seven achieved. Game ending.");
                    totalDiceSum = totalDiceSum + dieAddition;
                    Console.WriteLine("Total points for the game: " + totalDiceSum);
                    totalSeven = true;
                    dieSumCalculated = true;
                }
                if (dieSumCalculated == false)
                {
                    Console.WriteLine("Rolled: " + die1 + " and " + die2);
                    totalDiceSum = totalDiceSum + dieAddition;
                    Console.WriteLine("Total: " + totalDiceSum);
                    dieSumCalculated = true;
                }


            }
        }
    }
}
