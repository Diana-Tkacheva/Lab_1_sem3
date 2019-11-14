using Lab_2_sem3;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab_3_sem3
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arr = new ArrayList();
            Rectangle rct = new Rectangle(20, 3);
            Square sq = new Square(2);
            Circle cr = new Circle(5);
            arr.Add(rct);
            arr.Add(sq);
            arr.Add(cr);
            foreach(var item in arr)
            {
                Console.WriteLine(((GeometricShape)item).CalculateShapeArea());
            }
            List<GeometricShape> sorted = new List<GeometricShape>();
            sorted.Add(rct);
            sorted.Add(sq);
            sorted.Add(cr);
            sorted.Sort();
            foreach(var item in sorted)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\nМатрица");
            Matrix<GeometricShape> cube = new Matrix<GeometricShape>(3, 3, 3, null);
            cube[0, 0, 0] = rct;
            cube[1, 1, 1] = sq;
            cube[2, 2, 2] = cr;
            Console.WriteLine(cube.ToString());
            Console.ReadLine();
        }
    }
}
