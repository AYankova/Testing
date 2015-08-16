//•	Write a program that reads a year from the console and checks whether it is a leap one.
//•	Use System.DateTime.

using System;

class LeapYear
{
    static void Main()
    {
        Console.Write("Enter a year: ");
        int year = int.Parse(Console.ReadLine());
        bool isLeapYear = DateTime.IsLeapYear(year);

        Console.WriteLine("{0} {1} a leap year.",year,isLeapYear?"is":"is not");
    }
}

