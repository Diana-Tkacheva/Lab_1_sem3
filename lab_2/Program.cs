using System;

namespace Lab_2_sem3
{
    class Program
    {
        static void Main(string[] args)
        {
            var rectangle = new Rectangle(2, 3);
            var square = new Square(6);
            var circle = new Circle(4.2);

            rectangle.Print();
            square.Print();
            circle.Print();
            Console.ReadLine();
        }
    }
}
