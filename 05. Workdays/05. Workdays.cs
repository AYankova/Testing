//Write a method that calculates the number of workdays between today and given date, passed as parameter.
//Consider that workdays are all days from Monday to Friday except a fixed list of public 
//holidays specified preliminary as array.

using System;
using System.Globalization;
using System.Linq;

class Workdays
{
    static DateTime startDate = DateTime.Now.Date;
    static readonly DateTime[] holidays =
    {
            new DateTime (2015,01,01), 
            new DateTime (2015,03,03), 
            new DateTime (2015,04,10), 
            new DateTime (2015,04,13), 
            new DateTime (2015,05,01), 
            new DateTime (2015,05,06), 
            new DateTime (2015,05,24), 
            new DateTime (2015,09,06), 
            new DateTime (2015,09,22), 
            new DateTime (2015,12,24), 
            new DateTime (2015,12,25), 
        };

    static int WorkDays(DateTime endDate)
    {
        DateTime dateNow = startDate;
        int numberOfWorkDays = 0;

        while (dateNow <= endDate)
        {
            if (!holidays.Contains(dateNow)&& dateNow.DayOfWeek != DayOfWeek.Saturday&& dateNow.DayOfWeek != DayOfWeek.Sunday)
            {
                ++numberOfWorkDays;
            }
            dateNow = dateNow.AddDays(1);
        }

        return numberOfWorkDays;
    }
    static void Main()
    {
        Console.WriteLine("Enter the future date starting with the day.Use dash(-),slash(/),backslash(\\),");
        Console.WriteLine("dot(.) or space for separator:");
        string input = Console.ReadLine();
        int[] splittedInput = input.Split(new char[]{'-','/','.',' ','\\'}).Select(int.Parse).ToArray();
        DateTime endDate = new DateTime(splittedInput[2], splittedInput[1], splittedInput[0]);
        CultureInfo culture = new CultureInfo("en-US");

        if (endDate<startDate)
        {
            Console.WriteLine("Invalid date.");
        }
        else
        {
            int work = WorkDays(endDate);
            Console.WriteLine("Working days between \n{0} and {1} are {2}",startDate.ToString("D", culture), 
                              endDate.ToString("D", culture), work.ToString("D", culture));
        }

    }
}

