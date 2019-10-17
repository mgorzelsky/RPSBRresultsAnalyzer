using System;
using System.Collections.Generic;
using System.Text;

namespace RPSBRresultsAnalyzer
{
    class StatsTracker
    {
        private int numberOfWins = 0;
        private List<int> soldiersLeft = new List<int>();

        public void Record(int armySize)
        {
            numberOfWins++;
            soldiersLeft.Add(armySize);
        }

        public int GetNumberOfWins()
        {
            return numberOfWins;
        }

        public int[] GetSoldiersLeft()
        {
            int[] soldiersLeftAsArray = new int[soldiersLeft.Count];
            soldiersLeft.CopyTo(soldiersLeftAsArray);
            return soldiersLeftAsArray;
        }

        public int GetSmallestArmy(int[] soldiersLeftAsArray)
        {
            int smallestArmy = 2_000_000_000;
            for (int i = 0; i < soldiersLeftAsArray.Length; i++)
            {
                if (smallestArmy > soldiersLeftAsArray[i])
                    smallestArmy = soldiersLeftAsArray[i];
            }
            return smallestArmy;
        }

        public int GetLargestArmy(int[] soldiersLeftAsArray)
        {
            int largestArmy = 0;
            for (int i = 0; i < soldiersLeftAsArray.Length; i++)
            {
                if (largestArmy < soldiersLeftAsArray[i])
                    largestArmy = soldiersLeftAsArray[i];
            }
            return largestArmy;
        }


    }
}
