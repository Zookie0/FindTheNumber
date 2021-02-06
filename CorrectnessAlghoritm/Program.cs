using System;
using System.Collections.Generic;
using System.Linq;

namespace CorrectnessAlghoritm
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var gNumber = int.Parse(input);

            var lenght = gNumber.ToString().Length;



            CheckCorrectness(gNumber, GenerateNumber(lenght));

            
        }

        public static void CheckCorrectness(int gNumber, List<int> generatedNumber)
        {

            //Variables
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            Dictionary<int, int> indexDict = new Dictionary<int, int>();
            int positivecounter = 0;
            int negativecounter = 0;


            //Converting and Guessed Number to Arrays
            
            int[] gdigits = gNumber.ToString().Select(t => int.Parse(t.ToString())).ToArray();

            //Mapping Generated Number's digits with index number of Digit's index
            foreach (var digit in generatedNumber)
            {

                indexDict.Add(digit,generatedNumber.IndexOf(digit));


            }

            //Comparing the Guessed Number's digits in True Number's digits
            foreach (int gdigit in gdigits)
            {
                foreach (var digit in generatedNumber)
                {

                    if (gdigit == digit)
                    {
                        numbers.Add(gdigit, Array.IndexOf(gdigits, gdigit));

                    }

                }
            }

            //Checking the correctness of Guessed Number
            foreach (var item in indexDict)
            {
                foreach (var number in numbers)
                {
                    if (number.Key == item.Key && number.Value == item.Value)
                    {
                        positivecounter++;


                    }
                    else if (number.Key == item.Key && number.Value != item.Value)
                    {
                        negativecounter++;

                    }
                }
            }

            //Printing Guessed Number with Correcntess
            Console.WriteLine("{0} | + {1} - {2} ", gNumber, positivecounter, negativecounter);
        }
        public static List<int> GenerateNumber(int lenght)
        {
            Random random = new Random();
            List<int> numerals = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<int> generatedNumber = new List<int>();

            for (int i = 0; i < lenght; i++)
            {
                int rand = random.Next(0, numerals.Count);
                generatedNumber.Add(numerals[rand]);
                numerals.Remove(numerals[rand]);
            }
            
            return generatedNumber;
            
        }
    }


}
