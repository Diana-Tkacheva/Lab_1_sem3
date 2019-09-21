
using System;

namespace Lab_1_sem3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ткачева Диана, ИУ5-33Б\n");
            Console.WriteLine("Решим биквадратное уравнение:");
            double val_a = getDbl("Введите коэффициент А: ");
            double val_b = getDbl("Введите коэффициент B: ");
            double val_c = getDbl("Введите коэффициент C: ");
            Console.WriteLine($"{val_a}x^4 + {val_b}x^2 + {val_c}=0");
            Console.WriteLine("Cделаем замену x^2=t и решим квадратное уравнение:");
            Console.WriteLine($"{val_a}t^2 + {val_b}t + {val_c}=0");
            double descr = Math.Pow(val_b, 2) - 4 * val_a * val_c;
            Console.WriteLine($"Дискриминант: {descr}");
            double r1;
            double r2;
            if (descr > 0)
            {
                r1 = (-val_b + Math.Sqrt(descr)) / (2 * val_a);
                r2 = (-val_b - Math.Sqrt(descr)) / (2 * val_a);
                
            }
            else if (descr == 0)
            {
                r1 = r2 = (-val_b) / (2 * val_a);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Корней нет\n");
                Console.ResetColor();
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Корни квадратного уравнения:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"t1: {r1}; t2: {r2}");
            Console.ResetColor();
            Console.WriteLine("Корни биквадратного уравнения:");
            if (r1 < 0 || r2 < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Корней нет\n");
                Console.ResetColor();
                Console.ReadLine();
                return;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            if (r1 != r2)
            {
                bool a = false;
                if (r1 == 0)
                {
                    Console.WriteLine($"x1 = {Math.Sqrt(r1)}");
                    a = true;
                }
                else
                    Console.WriteLine($"x1 = {Math.Sqrt(r1)}; x2 = {-Math.Sqrt(r1)}");
                if (r2 == 0)
                {
                    if (a)
                        Console.WriteLine($"x2 = {Math.Sqrt(r1)}");
                    else
                        Console.WriteLine($"x3 = {Math.Sqrt(r1)}");
                }
                else
                {
                    if(a)
                        Console.WriteLine($"x2 = {Math.Sqrt(r2)}; x3 = {-Math.Sqrt(r2)}");
                    else
                        Console.WriteLine($"x3 = {Math.Sqrt(r2)}; x4 = {-Math.Sqrt(r2)}");
                }
            }
            else
            {
                if (r1 == 0)
                    Console.WriteLine("x1 = 0", ConsoleColor.Green);
                else
                    Console.WriteLine($"x1 = {Math.Sqrt(r1)}; x2 = {-Math.Sqrt(r1)}", ConsoleColor.Green);
            }
            Console.ResetColor();
            Console.ReadLine();
        }
        static double getDbl(string message)
        {
            string resStr;
            double resDbl;
            bool correct;
            do
            {
                Console.Write(message);
                resStr = Console.ReadLine();
                correct = double.TryParse(resStr, out resDbl);
                if (!correct)
                    Console.WriteLine("Введите вещественное число!");
            }
            while (!correct);
            return resDbl;
        }
    }
}
