using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
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

            for (int i = 0; i < die.Length; i++)
            {
                die[i] = Die.Roll();
            }

            Console.WriteLine("Array: " + die[0] + die[1] + die[2] + die[3] + die[4]);

            GetDieCount(die, dieCount);
            highestCount = GetHighestCount(dieCount);

            while (highestCount == 2)
            {
                switch (highestCount)
                {
                    case 1:
                        Console.WriteLine("One of a kind rolled. Zero Points given. ");
                        break;

                    case 2:

                        Console.WriteLine("Two of a kind rolled. Would you like to rethrow all or remaining die? (all/remaining)");
                        string userRethrowOption = Console.ReadLine();

                        List<int> arrayFlags = new List<int>();

                        if (userRethrowOption == "all")
                        {
                            for (int i = 0; i < die.Length; i++)
                            {
                                die[i] = Die.Roll();
                            }
                        }

                        if (userRethrowOption == "remaining")
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

                        Console.WriteLine("Array: " + die[0] + die[1] + die[2] + die[3] + die[4]);

                        dieCount = new int[6];
                        GetDieCount(die, dieCount);
                        highestCount = GetHighestCount(dieCount);

                        break;

                    case 3:
                        Console.WriteLine("Three of a kind rolled.");
                        break;
                    case 4:
                        Console.WriteLine("Four of a kinf rolled");
                        break;
                    case 5:
                        Console.WriteLine("Five of a kind rolled");
                        break;
                }
            }

            static void GetDieCount(int[] die, int[] dieCount)
            {
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

                Console.WriteLine("Array Count: " + dieCount[0] + dieCount[1] + dieCount[2] + dieCount[3] + dieCount[4] + dieCount[5]);
            }

            static int GetHighestCount(int[] dieCount)
            {
                int highestCount = 0;

                for (int i = 0; i < dieCount.Length; i++)
                {
                    if (dieCount[i] > highestCount)
                    {
                        highestCount = dieCount[i];
                    }
                }

                Console.WriteLine("Highest Count: " + highestCount);
                return highestCount;
            }
        }
    }
}
