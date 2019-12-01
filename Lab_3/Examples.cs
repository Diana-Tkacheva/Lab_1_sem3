using Lab_2_sem3;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab_3_sem3
{
    public class Examples
    {

        public void ArrayListArea()
        {
            Console.WriteLine("Площадь геометрических фигур");
            ArrayList arr = new ArrayList();
            Rectangle rct = new Rectangle(20, 3);
            Square sq = new Square(2);
            Circle cr = new Circle(5);
            arr.Add(rct);
            arr.Add(sq);
            arr.Add(cr);
            foreach (var item in arr)
            {
                Console.WriteLine(((GeometricShape)item).CalculateShapeArea());
            }
        }

        public void GeometricShapeSorted()
        {
            Console.WriteLine("\nСортировка геометрических фигур");
            List<GeometricShape> sorted = new List<GeometricShape>();
            Rectangle rct = new Rectangle(20, 3);
            Square sq = new Square(2);
            Circle cr = new Circle(5);
            sorted.Add(rct);
            sorted.Add(sq);
            sorted.Add(cr);
            sorted.Sort();
            foreach (var item in sorted)
            {
                Console.WriteLine(item);
            }
        }

        public void Matrix()
        {
            Console.WriteLine("\nМатрица");
            Matrix<GeometricShape> cube = new Matrix<GeometricShape>(3, 3, 3, null);
            Rectangle rct = new Rectangle(20, 3);
            Square sq = new Square(2);
            Circle cr = new Circle(5);
            cube[0, 0, 0] = rct;
            cube[1, 1, 1] = sq;
            cube[2, 2, 2] = cr;
            Console.WriteLine(cube.ToString());
        }

        public void SimpleStack()
        {
            Console.WriteLine("\nСтек");
            var stack = new SimpleStack<GeometricShape>();
            stack.Push(new Rectangle(20, 3));
            stack.Push(new Square(2));
            stack.Push(new Circle(5));
            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop().ToString());
            }
        }
    }
}
