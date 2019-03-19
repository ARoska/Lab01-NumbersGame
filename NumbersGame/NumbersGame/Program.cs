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
            finally
            {
                Console.WriteLine("Program is complete.");
                Console.ReadKey();
            }

        }

        static void StartSequence()
        {
            Console.WriteLine("Welcome to my Numbers Game!");
            Console.WriteLine("Please input a number greater than zero(0)");
            string arrayInput = Console.ReadLine();

            try
            {
                int arrayLength = Convert.ToInt32(arrayInput);
                int[] numbersArray = new int[arrayLength];

                Populate(numbersArray);

                int sum = GetSum(numbersArray);
                int product = GetProduct(numbersArray, sum);
                decimal quotient = GetQuotient(product);

                Console.WriteLine($"Your Array size is: {numbersArray.Length}");
                Console.Write("The numbers in your Array are: ");
                Console.WriteLine($"{string.Join(", ", numbersArray)}");
                Console.WriteLine($"The sum of your Array is {sum}");
                Console.WriteLine($"{sum} * {product / sum} = {product}");
                Console.WriteLine($"{product} / {product / quotient} = {quotient}");
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
                Console.WriteLine($"Please enter number: {i + 1} of {numbersArray.Length}");
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
                product = sum * numbersArray[randomNumber - 1];

            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
                throw;
            }

            return product;
        }

        static decimal GetQuotient(int product)
        {
            decimal decimalProduct = Convert.ToDecimal(product);
            Console.WriteLine($"Please input a number to divide {product} by:");
            string divisorInput = Console.ReadLine();
            decimal divisor = Convert.ToInt32(divisorInput);
            decimal quotient = 0;

            try
            {
                quotient = Decimal.Divide(decimalProduct, divisor);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e);
                Console.WriteLine($"Cannot divide by {divisor}");
            }

            return quotient;
        }
    }
}
