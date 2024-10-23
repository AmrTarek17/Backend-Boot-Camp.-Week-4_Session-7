using System;
using System.IO;

public class Point3D
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }

    // Constructor chaining
    public Point3D() : this(0, 0, 0) { }

    public Point3D(int x, int y) : this(x, y, 0) { }

    public Point3D(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public override string ToString()
    {
        return $"Point3D [X={X}, Y={Y}, Z={Z}]";
    }

    // Overriding Equals method
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        Point3D p = (Point3D)obj;
        return (X == p.X && Y == p.Y && Z == p.Z);
    }

    public override int GetHashCode()
    {
        return Tuple.Create(X, Y, Z).GetHashCode();
    }

    // Overloading the == operator
    public static bool operator ==(Point3D p1, Point3D p2)
    {
        if (ReferenceEquals(p1, p2))
            return true;
        if (p1 is null || p2 is null)
            return false;
        return p1.Equals(p2);
    }

    public static bool operator !=(Point3D p1, Point3D p2)
    {
        return !(p1 == p2);
    }

    public static Point3D ReadPoint(string pointName)
    {
        int x, y, z;
        while (true)
        {
            try
            {
                Console.WriteLine($"Enter coordinates for {pointName} (x y z):");
                string[] input = Console.ReadLine().Split();

                if (input.Length == 3 && int.TryParse(input[0], out x) && int.TryParse(input[1], out y) && int.TryParse(input[2], out z))
                    break;
                else
                    throw new FormatException("Invalid input format. Please enter three integers.");
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
            }
        }
        return new Point3D(x, y, z);
    }

    private static void LogError(string errorMessage)
    {
        File.AppendAllText("error_log.txt", $"{DateTime.Now}: {errorMessage}\n");
    }
}

class Program
{
    static void Main()
    {
        Point3D P1 = Point3D.ReadPoint("P1");
        Point3D P2 = Point3D.ReadPoint("P2");

        Console.WriteLine(P1);
        Console.WriteLine(P2);

        // Checking equality
        if (P1 == P2)
        {
            Console.WriteLine("The points are equal.");
        }
        else
        {
            Console.WriteLine("The points are not equal.");
        }
    }
}
