using System;

namespace Lab_2_sem3
{
    public class Square:Rectangle, IPrint
    {
        public Square(double sideLength):base(sideLength, sideLength) { }
        public override string ToString()
        {
            return $"Type: Square\nSide length: {Height}\nArea: {CalculateShapeArea()}";
        }
        new public void Print()
        {
            Console.WriteLine(ToString());
        }
    }

}
