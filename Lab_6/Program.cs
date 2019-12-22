using System;

namespace Lab_6
{
    delegate string DelegateSample(int p1, int p2, bool pBool);

    class Program
    {
        static string PlusOrMinus(int p1, int p2, bool pBool)
        {
            if (pBool)
            {
                return (p1 + p2).ToString();
            }
            else
            {
                return (p1 - p2).ToString();
            }
        }

        static void PlusAndMinusMethod(bool opType, int p1, int p2, DelegateSample sample)
        {
            string res1 = sample(p1, p2, opType);
            string res2 = sample(p1, p2, !opType);
            string opName = opType ? "+" : "-";
            Console.WriteLine($"{p1} {opName} {p2} = {res1}");
            opName = !opType ? "+" : "-";
            Console.WriteLine($"{p1} {opName} {p2} = {res2}");
        }

        static void PlusAndMinusMethodFunc(bool opType, int p1, int p2, Func<int, int, bool, string> sample)
        {
            string res1 = sample(p1, p2, opType);
            string res2 = sample(p1, p2, !opType);
            string opName = opType ? "+" : "-";
            Console.WriteLine($"{p1} {opName} {p2} = {res1}");
            opName = !opType ? "+" : "-";
            Console.WriteLine($"{p1} {opName} {p2} = {res2}");
        }

        static void Main(string[] args)
        {
            int p1 = 66;
            int p2 = 99;
            Console.WriteLine("Delegate call");
            PlusAndMinusMethod(true, p1, p2, PlusOrMinus);
            Console.WriteLine("Create delegate instance by method");
            DelegateSample sample = new DelegateSample(PlusOrMinus);
            PlusAndMinusMethod(true, p1, p2, sample);
            Console.WriteLine("Create delegate instance by lambda-method");
            PlusAndMinusMethod(true, p1, p2, 
                (x, y, op) =>
                {
                    if (op)
                    {
                        return (x + y).ToString();
                    }
                    else
                    {
                        return (x - y).ToString();
                    }
                });
            Console.WriteLine("Create delegate instance by Func<>");
            PlusAndMinusMethodFunc(true, p1, p2, PlusOrMinus);

            Console.ReadLine();
        }
    }
}
