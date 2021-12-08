using System;
using System.Collections.Generic;
using System.Linq;

namespace Mastermind
{
    static class Program
    {
        static void Main(string[] args)
        {
            GuessResult guessResult;
            bool isRunning = true;

            var guessedNumber = GetGuessInput();
            int generatedNumber = GenerateRandomDifferentDigitNumber(guessedNumber.ToString().Length);


            while (isRunning)
            {
                guessResult = GuessNumber(guessedNumber, generatedNumber);
                if (guessResult.GuessedNumber != generatedNumber)
                {
                    Console.WriteLine(
                        $"{guessResult.GuessedNumber}| {guessResult.PositiveCount}~{guessResult.NegativeCount}");
                    guessedNumber = GetGuessInput();
                }
                else
                {
                    isRunning = false;
                    Console.WriteLine(
                        $"{guessResult.GuessedNumber}| {guessResult.PositiveCount} ~ {guessResult.NegativeCount}");
                    Console.Write("Well Done!");
                }
            }
        }

        private static int GetGuessInput()
        {
            Console.Write("Make a Guess: ");
            var guessedNumber = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            return guessedNumber;
        }

        private static GuessResult GuessNumber(int guessedNumber, int generatedNumber)
        {
            //Variables
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            int positiveCounter = 0;
            int negativeCounter = 0;


            //Converting and Guessed Number to Arrays

            List<int> guessedNumberDigits = guessedNumber.ToString().Select(t => int.Parse(t.ToString())).ToList();
            List<int> generatedNumberDigits = generatedNumber.ToString().Select(t => int.Parse(t.ToString())).ToList();

            //Mapping Generated Number's digits with index number of Digit's index
            Dictionary<int, int> indexDict =
                generatedNumberDigits.ToDictionary(digit => digit, digit => generatedNumberDigits.IndexOf(digit));

            //Comparing the Guessed Number's digits in True Number's digits
            foreach (int guessedNumberDigit in guessedNumberDigits)
            {
                foreach (var generatedNumberDigit in generatedNumberDigits)
                {
                    if (guessedNumberDigit == generatedNumberDigit)
                    {
                        numbers.Add(guessedNumberDigit, guessedNumberDigits.IndexOf(guessedNumberDigit));
                    }
                }
            }

            //Checking the correctness of Guessed Number
            foreach (var index in indexDict)
            {
                foreach (var number in numbers)
                {
                    if (number.Key == index.Key && number.Value == index.Value)
                    {
                        positiveCounter++;
                    }
                    else if (number.Key == index.Key && number.Value != index.Value)
                    {
                        negativeCounter++;
                    }
                }
            }

            //Printing Guessed Number with Correctness
            return new GuessResult()
            {
                GuessedNumber = guessedNumber,
                NegativeCount = negativeCounter * -1,
                PositiveCount = positiveCounter
            };
        }

        private static int GenerateRandomDifferentDigitNumber(int digitLength)
        {
            Random random = new Random();
            List<int> numerals = new List<int> {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            string generatedNumber = "";

            for (int i = 0; i < digitLength; i++)
            {
                int rand = random.Next(0, numerals.Count);
                generatedNumber += numerals[rand];
                numerals.Remove(numerals[rand]);
            }

            return int.Parse(generatedNumber);
        }

        class GuessResult
        {
            public int GuessedNumber { get; set; }
            public int PositiveCount { get; set; }
            public int NegativeCount { get; set; }
        }
    }
}