//•	You are given a sequence of positive integer values written into a string, separated by spaces.
//•	Write a function that reads these values from given string and calculates their sum.
//"43 68 9 23 318"   result 461

using System;

class SumIntegers
{
    static void Main()
    {
        Console.WriteLine("Enter the sequence of positive numbers separated by space:");
        string input = Console.ReadLine();
        string[] inputNums = input.Split(new char[] { ' ', '"' }, StringSplitOptions.RemoveEmptyEntries);
        int[] numbers = new int[inputNums.Length];
        int sum = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(inputNums[i]);
            sum += numbers[i];
        }
        Console.WriteLine(sum);
    }
}

