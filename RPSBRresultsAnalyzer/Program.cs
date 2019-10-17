using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;

namespace RPSBRresultsAnalyzer
{
    enum WhatArmy { Rock, Paper, Scissors, Lizard, Spock };
    class Program
    {
        private static StatsTracker rock = new StatsTracker();
        private static StatsTracker paper = new StatsTracker();
        private static StatsTracker scissors = new StatsTracker();
        private static StatsTracker lizard = new StatsTracker();
        private static StatsTracker spock = new StatsTracker();

        static void Main()
        {
            string[] unparsedResults = File.ReadAllLines(@"C:\Users\Admin1\Documents\CodeFiles\RPSBRresults.txt");

            List<string> parsedResults = TurnResultsToList(unparsedResults);

            RecordResults(parsedResults);

            Console.WriteLine("Total Wins:");
            Console.WriteLine("Rock: " + rock.GetNumberOfWins());
            Console.WriteLine("Paper: " + paper.GetNumberOfWins());
            Console.WriteLine("Scissors: " + scissors.GetNumberOfWins());
            Console.WriteLine("Lizard: " + lizard.GetNumberOfWins());
            Console.WriteLine("Spock: " + spock.GetNumberOfWins());
            Console.WriteLine();

            //Which army had the most wins?
            Console.WriteLine(MostWins() + " won the most times.");
            //Which army had the most losses?
            Console.WriteLine(MostLosses() + " lost the most times.");

            //Which army ended with the highest number of members left?
            int[] mostSoldiersLeft = MostSoldiersLeft();
            Console.WriteLine((WhatArmy)mostSoldiersLeft[1] + 
                               " had the most number of soldiers left at : " + 
                               mostSoldiersLeft[0]);

            //Which army ended with the lowest number of members left?
            int[] leastSoldiersLeft = LeastSoldiersLeft();
            if (leastSoldiersLeft.Length > 2)
            {

            }
            else
            {
                Console.WriteLine((WhatArmy)mostSoldiersLeft[1] +
                                   " had the smallest number of soldiers left at : " +
                                   leastSoldiersLeft[0]);
            }


        }
        private static List<string> TurnResultsToList(string[] unparsedResults)
        {
            List<string[]> separatedResults = new List<string[]>();
            for (int i = 1; i < unparsedResults.Length; i++)
            {
                Regex regex = new Regex(" ");
                string[] substrings = regex.Split(unparsedResults[i]);
                separatedResults.Add(substrings);
            }

            List<string> parsedResults = new List<string>();
            foreach (string[] array in separatedResults)
            {
                foreach (string item in array)
                {
                    parsedResults.Add(item);
                }
            }

            return parsedResults;
        }

        private static void RecordResults(List<string> parsedResults)
        {
            for (int i = 0; i < parsedResults.Count; i++)
            {
                if (i % 2 == 0)
                {
                    if (parsedResults[i] == "Rock")
                    {
                        Int32.TryParse(parsedResults[i + 1], out int soldiers);
                        rock.Record(soldiers);
                    }
                }
                if (i % 2 == 0)
                {
                    if (parsedResults[i] == "Paper")
                    {
                        Int32.TryParse(parsedResults[i + 1], out int soldiers);
                        paper.Record(soldiers);
                    }
                }
                if (i % 2 == 0)
                {
                    if (parsedResults[i] == "Scissors")
                    {
                        Int32.TryParse(parsedResults[i + 1], out int soldiers);
                        scissors.Record(soldiers);
                    }
                }
                if (i % 2 == 0)
                {
                    if (parsedResults[i] == "Lizard")
                    {
                        Int32.TryParse(parsedResults[i + 1], out int soldiers);
                        lizard.Record(soldiers);
                    }
                }
                if (i % 2 == 0)
                {
                    if (parsedResults[i] == "Spock")
                    {
                        Int32.TryParse(parsedResults[i + 1], out int soldiers);
                        spock.Record(soldiers);
                    }
                }
            }
        }

        private static string MostWins()
        {
            int rockWins = rock.GetNumberOfWins();
            int paperWins = paper.GetNumberOfWins();
            int scissorsWins = scissors.GetNumberOfWins();
            int lizardWins = lizard.GetNumberOfWins();
            int spockWins = spock.GetNumberOfWins();

            if (rockWins > paperWins &&
                rockWins > scissorsWins &&
                rockWins > lizardWins &&
                rockWins > spockWins)
                return "Rock";
            if (paperWins > rockWins &&
                paperWins > scissorsWins &&
                paperWins > lizardWins &&
                paperWins > spockWins)
                return "Paper";
            if (scissorsWins > rockWins &&
                scissorsWins > paperWins &&
                scissorsWins > lizardWins &&
                scissorsWins > spockWins)
                return "scissors";
            if (lizardWins > rockWins &&
                lizardWins > paperWins &&
                lizardWins > scissorsWins &&
                lizardWins > spockWins)
                return "Lizard";
            if (spockWins > rockWins &&
                spockWins > paperWins &&
                spockWins > scissorsWins &&
                spockWins > lizardWins)
                return "Spock";

            return "Failure";
        }
        private static string MostLosses()
        {
            int rockWins = rock.GetNumberOfWins();
            int paperWins = paper.GetNumberOfWins();
            int scissorsWins = scissors.GetNumberOfWins();
            int lizardWins = lizard.GetNumberOfWins();
            int spockWins = spock.GetNumberOfWins();

            if (rockWins < paperWins &&
                rockWins < scissorsWins &&
                rockWins < lizardWins &&
                rockWins < spockWins)
                return "Rock";
            if (paperWins < rockWins &&
                paperWins < scissorsWins &&
                paperWins < lizardWins &&
                paperWins < spockWins)
                return "Paper";
            if (scissorsWins < rockWins &&
                scissorsWins < paperWins &&
                scissorsWins < lizardWins &&
                scissorsWins < spockWins)
                return "scissors";
            if (lizardWins < rockWins &&
                lizardWins < paperWins &&
                lizardWins < scissorsWins &&
                lizardWins < spockWins)
                return "Lizard";
            if (spockWins < rockWins &&
                spockWins < paperWins &&
                spockWins < scissorsWins &&
                spockWins < lizardWins)
                return "Spock";

            return "Failure";
        }

        private static int[] MostSoldiersLeft()
        {
            int rockLargestArmy = rock.GetLargestArmy(rock.GetSoldiersLeft());
            int paperLargestArmy = paper.GetLargestArmy(paper.GetSoldiersLeft());
            int scissorsLargestArmy = scissors.GetLargestArmy(scissors.GetSoldiersLeft());
            int lizardLargestArmy = lizard.GetLargestArmy(lizard.GetSoldiersLeft());
            int spockLargestArmy = spock.GetLargestArmy(spock.GetSoldiersLeft());

            int[] largestArmyArray = new int[] { rockLargestArmy, paperLargestArmy, scissorsLargestArmy, lizardLargestArmy, spockLargestArmy };
            int largestArmy = 0;
            int index = 0;
            for (int i = 0; i < largestArmyArray.Length; i++)
            {
                if (largestArmy < largestArmyArray[i])
                {
                    largestArmy = largestArmyArray[i];
                    index = i;
                }
            }

            int[] theWinner = new int[] { largestArmy, index };
            return theWinner;
        }

        private static int[] LeastSoldiersLeft()
        {
            int rockSmallestArmy = rock.GetSmallestArmy(rock.GetSoldiersLeft());
            int paperSmallestArmy = paper.GetSmallestArmy(paper.GetSoldiersLeft());
            int scissorsSmallestArmy = scissors.GetSmallestArmy(scissors.GetSoldiersLeft());
            int lizardSmallestArmy = lizard.GetSmallestArmy(lizard.GetSoldiersLeft());
            int spockSmallestArmy = spock.GetSmallestArmy(spock.GetSoldiersLeft());

            int[] smallestArmyArray = new int[] { rockSmallestArmy, paperSmallestArmy, scissorsSmallestArmy, lizardSmallestArmy, spockSmallestArmy };
            int smallestArmy = 2_000_000_000;
            int index = 0;
            for (int i = 0; i < smallestArmyArray.Length; i++)
            {
                if (smallestArmy > smallestArmyArray[i])
                {
                    smallestArmy = smallestArmyArray[i];
                    index = i;
                }
            }

            int[] theLoser = new int[] { smallestArmy, index };
            return theLoser;
        }
    }
}
