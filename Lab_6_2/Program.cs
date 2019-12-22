using System;


namespace Lab_6_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Type st = typeof(ReflectionSample);
            Console.WriteLine("Constructors of type ReflectionSample");
            foreach(var c in st.GetConstructors())
            {
                Console.WriteLine(c);
            }
            Console.WriteLine("Properties of type ReflectionSample");
            foreach (var p in st.GetProperties())
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("Methods of type ReflectionSample");
            foreach (var m in st.GetMethods())
            {
                Console.WriteLine(m);
            }
            Console.WriteLine("Properties with CustomAttribute");
            foreach (var p in st.GetProperties())
            {
                var attr = p.GetCustomAttributes(typeof(CustomAttribute), false);
                if (attr != null && attr.Length > 0)
                {
                    Console.WriteLine(attr[0]);
                    Console.WriteLine("CustomAttribute description: " + ((CustomAttribute)attr[0]).Description);
                }
            }
            Console.WriteLine("Create instance of type ReflectionSample by Reflection.InvokeMember");
            ReflectionSample rs = (ReflectionSample)st.InvokeMember(null, System.Reflection.BindingFlags.CreateInstance, null, null, new object[] { "Simple round", 100 });
            Console.WriteLine(rs.ToString());

            Console.ReadLine();
        }
    }
}
