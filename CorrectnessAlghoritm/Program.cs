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

            Random random = new Random();

            int tNumber = 1563;

            CheckCorrectness(gNumber, tNumber,random);
        }

        public static void CheckCorrectness(int gNumber, int tNumber,Random rnd)
        {

            //Variables
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            Dictionary<int, int> indexDict = new Dictionary<int, int>();

            
            int positivecounter = 0;
            int negativecounter = 0;


            //Converting True Number and Guessed Number to Arrays
            int[] tdigits = tNumber.ToString().Select(t => int.Parse(t.ToString())).ToArray();
            int[] gdigits = gNumber.ToString().Select(t => int.Parse(t.ToString())).ToArray();

            //Mapping True Number's digits with index number of Digit's index
            foreach (var tdigit in tdigits)
            {

                indexDict.Add(tdigit, Array.IndexOf(tdigits, tdigit));
                

            }

            //Comparing the Guessed Number's digits in True Number's digits
            foreach (int gdigit in gdigits)
            {
                foreach (var tdigit in tdigits)
                {

                    if (gdigit == tdigit)
                    {
                        numbers.Add(gdigit, Array.IndexOf(gdigits, gdigit));
                        
                    }

                }
            }


            foreach (var item in indexDict)
            {
                foreach (var number in numbers)
                {
                    if (number.Key == item.Key && number.Value ==item.Value)
                    {
                        positivecounter++;
                        

                    }
                    else if (number.Key == item.Key && number.Value !=item.Value)
                    {
                        negativecounter++;
                        
                    }
                }
            }
            



            
            Console.WriteLine("{0} | + {1} - {2} " , gNumber,positivecounter,negativecounter);

        }
    }


}
