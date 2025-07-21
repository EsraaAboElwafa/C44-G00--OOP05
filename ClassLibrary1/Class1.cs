namespace ClassLibrary1
{
    public class Class1
    {
        static void Main()
        {
            //Maths m = new Maths();

            //Console.WriteLine("Add: " + m.Add(5, 3));
            //Console.WriteLine("Subtract: " + m.Subtract(5, 3));
            //Console.WriteLine("Multiply: " + m.Multiply(5, 3));
            //Console.WriteLine("Divide: " + m.Divide(5, 3));
            Console.WriteLine("Add: " + Maths.Add(5, 3));
            Console.WriteLine("Subtract: " + Maths.Subtract(5, 3));
            Console.WriteLine("Multiply: " + Maths.Multiply(5, 3));
            Console.WriteLine("Divide: " + Maths.Divide(5, 3));
        }
    }
}
