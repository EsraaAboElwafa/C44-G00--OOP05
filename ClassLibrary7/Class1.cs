namespace ClassLibrary7
{
    public class Class1
    {
        static void Main()
        {
            Point3D P = new Point3D(10, 10, 10);
            Console.WriteLine(P.ToString());

            Point3D P1 = ReadPointFromUser("P1");
            Point3D P2 = ReadPointFromUser("P2");

            if (P1 == P2)
                Console.WriteLine("P1 and P2 are equal (by reference).");
            else
                Console.WriteLine("P1 and P2 are NOT equal (by reference).");

            Point3D[] points = new Point3D[]
            {
                new Point3D(5,2,1),
                new Point3D(3,4,0),
                new Point3D(5,1,2),
                new Point3D(1,7,3)
            };

            Array.Sort(points);

            Console.WriteLine("Sorted points:");
            foreach (var pt in points)
            {
                Console.WriteLine(pt);
            }

            Point3D cloned = (Point3D)P1.Clone();
            Console.WriteLine("Cloned point: " + cloned);
        }

        static Point3D ReadPointFromUser(string pointName)
        {
            int x = ReadIntFromUser($"{pointName}.X");
            int y = ReadIntFromUser($"{pointName}.Y");
            int z = ReadIntFromUser($"{pointName}.Z");

            return new Point3D(x, y, z);
        }

        static int ReadIntFromUser(string fieldName)
        {
            int value;
            Console.Write($"Enter {fieldName}: ");

            string input = Console.ReadLine();

            // استخدام TryParse
            if (int.TryParse(input, out value))
                return value;

            // استخدام Parse (مع Exception)
            try
            {
                return int.Parse(input);
            }
            catch
            {
                Console.WriteLine("Invalid input, using Convert.ToInt32 instead.");
                return Convert.ToInt32(input);
            }
        }
    }
}
