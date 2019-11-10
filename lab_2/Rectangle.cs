using System;

namespace Lab_2_sem3
{
    public class Rectangle:GeometricShape, IPrint
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }
        public override double CalculateShapeArea()
        {
            return Height * Width;
        }
        public override string ToString()
        {
            return $"Type: Rectangle\nHeight: {Height}\nWidth: {Width}\nArea: {CalculateShapeArea()}";
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }
    }
}
