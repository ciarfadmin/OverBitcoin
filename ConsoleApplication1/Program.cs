using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpNeat.Utility;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            double funds;
            double nextAmmount;
            double currentBet;
            double houseGain = 0;
            double houseMin = 0;
            double houseMax = 0;
            int hands = 0;
            int totalHands = 0;
            int total = 0;

            int totalWins = 0;

            FastRandom rand = new FastRandom();
            double var = 0;
            for (int j = 0; j < 50000; j++)
            {
                funds = 2;
                currentBet = 0;
                nextAmmount = 0.01;
                hands = 0;

                while (true)
                {
                    currentBet = nextAmmount;
                    funds -= currentBet;
                    houseGain += currentBet;
                    //Console.Write("Bet " + i + ": " + currentBet);
                    //var = houseGain > 0 ? 0 : 0.1;
                    if (rand.NextDouble() < 0.5 - var)
                    { //Win
                        nextAmmount = 0.01;
                        double g = currentBet * 2 * 0.981;
                        funds += g;
                        houseGain -= g;
                    }
                    else
                    {
                        nextAmmount *= 2;
                        houseGain -= 0.00000001;
                    }
                    //Console.WriteLine("\t balance:" + funds + "\t balance:" + funds);
                    houseMin = houseMin < houseGain ? houseMin : houseGain;
                    houseMax = houseMax > houseGain ? houseMax : houseGain;
                    if (funds < nextAmmount || nextAmmount > 500 );// nextAmmount > 1.28)
                        nextAmmount = 0.01;

                    hands++;
                    if (funds - nextAmmount < 0)
                        break;
                }

                Console.WriteLine("Partida:" + j + "\t\tPlayer balance:" + funds + "\t\tHouse balance:" + houseGain + "\t\tHands:" + hands);
                totalHands += hands;
                total++;
            }
            double avg = totalHands / total;
            Console.WriteLine("House balance:" + houseGain);
            Console.WriteLine("houseMax:" + houseMax + "\t\thouseMin:" + houseMin);
            Console.WriteLine("totalWins:" + totalWins + "\t\thands average:" + avg);
            Console.ReadKey();
        }

    }
}
