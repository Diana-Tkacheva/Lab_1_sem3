using System;

namespace Lab_2_sem3
{
    public class Circle:GeometricShape, IPrint
    {
        public double Radius { get; set; }
        public Circle(double radius)
        {
            Radius = radius;
        }
        public override double CalculateShapeArea()
        {
            return 3.14 * Radius * Radius;
        }
        public override string ToString()
        {
            return $"Type: Circle\nRadius: {Radius}\nArea: {CalculateShapeArea()}";
        }
        public void Print()
        {
            Console.WriteLine(ToString());
        }
    }
}
