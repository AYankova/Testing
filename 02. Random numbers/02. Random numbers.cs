 //•	Write a program that generates and prints to the console 10 random values in the range [100, 200].
using System;

class RandomNumbers
{
    const int count = 10;
    const int min = 100;
    const int max = 201;

    static void Main()
    {
        Random randNumber = new Random();

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(randNumber.Next(min, max));
        }
    }
}

