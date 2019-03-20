using System;

namespace NumbersGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Try/Catch for Main sequence
            try
            {
                StartSequence();
            }
            // Catches generic errors that are not handled
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong :(");
                Console.WriteLine($"Error message: {e}");
            }
            // After app finishes inform the user and wait for a keystroke to close
            finally
            {
                Console.WriteLine("Program is complete.");
                Console.ReadKey();
            }

        }

        static void StartSequence()
        {
            // Ask user for starting input
            Console.WriteLine("Welcome to my Numbers Game!");
            Console.WriteLine("Please input a number greater than zero(0)");
            string arrayInput = Console.ReadLine();

            try
            {
                // Convert the input into a intiger and create an array of that length
                int arrayLength = Convert.ToInt32(arrayInput);
                int[] numbersArray = new int[arrayLength];

                // Run the Populate method to fill the array
                Populate(numbersArray);

                // Run the GetSum method to get the sum of the numbers in the array
                int sum = GetSum(numbersArray);
                // Run the GetProduct method to get the product of the sum and a random number in the array
                int product = GetProduct(numbersArray, sum);
                // Run the GetQuotient method to divide the product by a random number input by the user
                decimal quotient = GetQuotient(product);

                //Display results
                Console.WriteLine($"Your Array size is: {numbersArray.Length}");
                Console.Write("The numbers in your Array are: ");
                Console.WriteLine($"{string.Join(", ", numbersArray)}");
                Console.WriteLine($"The sum of your Array is {sum}");
                Console.WriteLine($"{sum} * {product / sum} = {product}");
                Console.WriteLine($"{product} / {product / quotient} = {quotient}");
            }
            // Catch any FormatException errors and throw them down the callstack
            catch (FormatException)
            {
                throw;
            }
            // Catch any OverlowException errors and throw them down the callstack
            catch (OverflowException)
            {
                throw;
            }

        }

        // Method for populating the user's array
        static int[] Populate(int[] numbersArray)
        {
            // Iterates accross the user's array
            for (int i = 0; i < numbersArray.Length; i++)
            {
                // Asks user for a number and inputs it into their array
                Console.WriteLine($"Please enter number: {i + 1} of {numbersArray.Length}");
                string numberInput = Console.ReadLine();

                numbersArray[i] = Convert.ToInt32(numberInput);
            }

            // Returns the populated array
            return numbersArray;
        }

        // Method for getting the sum of all numbers in the array
        static int GetSum(int[] numbersArray)
        {
            int sum = 0;

            // Iterates over the array and adds each number to the total
            foreach(int number in numbersArray)
            {
                sum += number;
            }

            if(sum < 20)
            {
                throw new System.ArgumentException($"Value of {sum} to low.");
            }

            // Returns the sum
            return sum;
        }

        // Method to get the product of a number out of the array * the sum of the numbers in the array 
        static int GetProduct(int[] numbersArray, int sum)
        {
            // Ask the user for a position in the array and get the array number at that position
            Console.WriteLine($"Please input a number between 1 and {numbersArray.Length}:");
            string randomNumberInput = Console.ReadLine();
            int randomNumber = Convert.ToInt32(randomNumberInput);
            int product;

            try
            {
                // Multiply the sum of the array and the number in the position the user chose
                product = sum * numbersArray[randomNumber - 1];

            }
            // Catch any IndexOutOfRange Exceptions, notify the user and throw the exception down the callstack
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
                throw;
            }

            // Return the product
            return product;
        }

        // Method for getting the quotient of the sum divided by a number of the user's choosing
        static decimal GetQuotient(int product)
        {
            // Convert the product being passed in to decimal for later use
            decimal decimalProduct = Convert.ToDecimal(product);
            // Get a number from the user and convert it to decimal
            Console.WriteLine($"Please input a number to divide {product} by:");
            string divisorInput = Console.ReadLine();
            decimal divisor = Convert.ToInt32(divisorInput);
            decimal quotient = 0;

            try
            {
                // Divide the product being passed in by the number the user chose
                quotient = Decimal.Divide(decimalProduct, divisor);
            }
            // Catch any DivideByZero Exceptions and display the error message, but do not throw the error down the stack
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e);
                Console.WriteLine($"Cannot divide by {divisor}");
            }

            // Return the quotient
            return quotient;
        }
    }
}
