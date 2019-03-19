using System;

namespace NumbersGame
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StartSequence();
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong :(");
                Console.WriteLine($"Error message: {e}");
            }

        }

        static void StartSequence()
        {
            Console.WriteLine("Please input a number greater than zero(0)");
            string arrayInput = Console.ReadLine();

            try
            {
                int arrayLength = Convert.ToInt32(arrayInput);
                int[] numbersArray = new int[arrayLength];

                Populate(numbersArray);

                int sum = GetSum(numbersArray);
                int product = GetProduct(numbersArray, sum);
                int quotient = GetQuotient(sum);
            }
            catch (FormatException)
            {

                throw;
            }
        }

        static void Populate()
        {

        }

        static void GetSum()
        {

        }

        static void GetProduct()
        {

        }

        static void GetQuotient()
        {

        }
    }
}
