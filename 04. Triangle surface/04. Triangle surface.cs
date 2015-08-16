/*•	Write methods that calculate the surface of a triangle by given:
    o	Side and an altitude to it;
    o	Three sides;
    o	Two sides and an angle between them;
  •	Use System.Math.*/

using System;

class TriangleSurface
{
    static decimal SideAltitudeSurface(decimal a,decimal h)
    {
        return (a * h) / 2;
    }
    static decimal ThreeSidesSurface(decimal a,decimal b,decimal c)
    {
        decimal perimeter = (a + b + c) / 2;
        decimal result =(decimal) Math.Sqrt((double)(perimeter * (perimeter - a) * (perimeter - b) * (perimeter - c)));
        return result;
    }
    static decimal SideAndAngleSurface(decimal a,decimal b,decimal angle)
    {
        decimal result=a * b * (decimal)Math.Sin((double)angle)/ 2;
        return result;
    }
    static void Main()
    {
        Console.WriteLine("Please choose how you want to calculate the triangle surface:");
        Console.WriteLine(new string('-',60));
        Console.WriteLine("Press 1 to calculate the surface by side and altitude to it");
        Console.WriteLine("Press 2 to calculate the surface by three sides");
        Console.WriteLine("Press 3 to calculate the surface by two sides and an angle");
        Console.WriteLine(new string('-', 60));
        var pressedButton = Console.ReadKey();
        Console.Clear();
        switch (pressedButton.KeyChar)
        {
            case'1':
                Console.Write("Enter side: ");
                decimal side = decimal.Parse(Console.ReadLine());
                Console.Write("Enter altitude: ");
                decimal altitude = decimal.Parse(Console.ReadLine());

                if (side<0||altitude<0)
                {
                throw new ArgumentOutOfRangeException("side,altitude","must be positive");
                }
                else
                {
                decimal resultA = SideAltitudeSurface(side, altitude);
                Console.WriteLine("The surface of triangle with side {0} and altitude {1} is {2:F2}",side,altitude,resultA);
                }
                break;
            case'2':
                Console.Write("Enter first side: ");
                decimal first = decimal.Parse(Console.ReadLine());
                Console.Write("Enter second side: ");
                decimal second = decimal.Parse(Console.ReadLine());
                Console.Write("Enter third side: ");
                decimal third = decimal.Parse(Console.ReadLine());

                if (first < 0 || second < 0 || third < 0)
                {
                throw new ArgumentOutOfRangeException("sides", "must be positive");
                }
                else
                {
                decimal resultB = ThreeSidesSurface(first, second, third);
                Console.WriteLine("The surface of triangle with sides {0}, {1} and {2} is {3:F2}", first, second, third, resultB);
                }
                break;
            case'3':
                Console.Write("Enter first side: ");
                decimal firstSideSize = decimal.Parse(Console.ReadLine());
                Console.Write("Enter second side: ");
                decimal secondSideSize = decimal.Parse(Console.ReadLine());
                Console.Write("Enter angle: ");
                decimal angle = decimal.Parse(Console.ReadLine());

                if (firstSideSize<0||secondSideSize<0||angle<0)
                {
                throw new ArgumentOutOfRangeException("side,angle", "must be positive");
                }
                else
                {
                decimal resultC = SideAndAngleSurface(firstSideSize,secondSideSize, angle);
                Console.WriteLine("The surface of triangle with sides {0} and {1} and angle {2} is {3:F2}", firstSideSize,secondSideSize,angle, resultC);
                }
                break;
            default:
                Console.WriteLine("Invalid input.Press 1, 2 or 3!");
                break;
        }
    }
}

