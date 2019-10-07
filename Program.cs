
using System;
using System.Text;

namespace Lab_1_sem3
{
    class Program
    {

        static void Main(string[] args)
        {
            Encoding src = Console.OutputEncoding;
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "Ткачева Диана, ИУ5-33Б\n";
            Console.WriteLine("Решим биквадратное уравнение:");
            double val_a = 0;
            bool a_cor = false;
            double val_b = 0;
            bool b_cor = false;
            double val_c = 0;
            bool c_cor = false;
            if (args != null && args.Length == 3)
            {
                a_cor = double.TryParse(args[0], out val_a);
                b_cor = double.TryParse(args[1], out val_b);
                c_cor = double.TryParse(args[2], out val_c);
            }
            if (!a_cor || !b_cor || !c_cor)
            {
                if (!a_cor)
                    val_a = getDbl("Введите коэффициент А: ");
                if (!b_cor)
                    val_b = getDbl("Введите коэффициент B: ");
                if (!c_cor)
                    val_c = getDbl("Введите коэффициент C: ");
            }


            if (val_a == 0)
            {
                Console.WriteLine($"{val_b}x^2 + {val_c}=0");
                if (-val_c / val_b < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Корней нет\n");
                    Console.ResetColor();
                    Console.ReadLine();
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"x1 = {Math.Sqrt(-val_c / val_b)}; x2 = {-Math.Sqrt(-val_c / val_b)}");
                    Console.ResetColor();
                    Console.ReadLine();
                    return;
                }
            }
            if (val_b == 0)
            {
                Console.WriteLine($"{val_a}x^4 + {val_c}=0");
                if (-val_c / val_a < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Корней нет\n");
                    Console.ResetColor();
                    Console.ReadLine();
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"x1 = {Math.Pow((-val_c / val_a), 1.0 / 4)}; x2 = {-Math.Pow((-val_c / val_a), 1.0 / 4)}");
                    Console.ResetColor();
                    Console.ReadLine();
                    return;
                }
            }
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
            if (r1 == r2)
                Console.WriteLine($"t: {r1}");
            else
                Console.WriteLine($"t1: {r1}; t2: {r2}");
            Console.ResetColor();
            Console.WriteLine("Корни биквадратного уравнения:");
            if (r1 < 0 && r2 < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Корней нет\n");
                Console.ResetColor();
                Console.ReadLine();
                return;
            }
            Console.ForegroundColor = ConsoleColor.Green;

            if (r1 == 0 && r2 == 0)
            {
                Console.WriteLine("x = 0\n");
                Console.ResetColor();
                Console.ReadLine();
                return;
            }

            if (r1 == r2)
            {
                Console.WriteLine($"x1 = {Math.Sqrt(r1)}; x2 = {-Math.Sqrt(r1)}");
                Console.ReadLine();
                return;
            }

            if (r1 == 0)
            {
                if (r2 < 0)
                    Console.WriteLine($"x = 0");
                else
                    Console.WriteLine($"x1 = 0; x2 = {Math.Sqrt(r2)}; x3 = {-Math.Sqrt(r2)}");
            }
            else if (r1 < 0)
            {
                if (r2 == 0)
                    Console.WriteLine($"x = 0");
                else
                    Console.WriteLine($"x1 = {Math.Sqrt(r2)}; x2 = {-Math.Sqrt(r2)}");
            }
            else
            {
                if (r2 < 0)
                    Console.WriteLine($"x1 = {Math.Sqrt(r1)}; x2 = {-Math.Sqrt(r1)}");
                else if (r2 == 0)
                    Console.WriteLine($"x1 = {Math.Sqrt(r1)}; x2 = {-Math.Sqrt(r1)}; x3 = 0");
                else
                    Console.WriteLine($"x1 = {Math.Sqrt(r1)}; x2 = {-Math.Sqrt(r1)}; x3 = {Math.Sqrt(r2)}; x4 = {-Math.Sqrt(r2)}");
            }
            Console.ResetColor();
            Console.ReadLine();
            Console.OutputEncoding = src;
            double getDbl(string message)
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
}