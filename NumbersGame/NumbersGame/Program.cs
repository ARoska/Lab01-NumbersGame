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
            catch (OverflowException)
            {

                throw;
            }
        }

        static int[] Populate(int[] numbersArray)
        {
            for (int i = 0; i < numbersArray.Length; i++)
            {
                Console.WriteLine($"Please enter number: {i} of {numbersArray.Length}");
                string numberInput = Console.ReadLine();

                numbersArray[i] = Convert.ToInt32(numberInput);
            }

            return numbersArray;
        }

        static int GetSum(int[] numbersArray)
        {
            int sum = 0;

            foreach(int number in numbersArray)
            {
                sum += number;
            }

            if(sum < 20)
            {
                throw new System.ArgumentException($"Value of {sum} to low.");
            }

            return sum;
        }

        static int GetProduct(int[] numbersArray, int sum)
        {
            Console.WriteLine($"Please input a number between 1 and {numbersArray.Length}:");
            string randomNumberInput = Console.ReadLine();
            int randomNumber = Convert.ToInt32(randomNumberInput);
            int product;

            try
            {
                product = sum * numbersArray[randomNumber];

            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
                throw;
            }

            return product;
        }

        static void GetQuotient()
        {

        }
    }
}
