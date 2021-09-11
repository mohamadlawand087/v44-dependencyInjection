using System;

namespace SampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var a = new A();
            a.GetInfo("Mohamad");
        }
    }

    public class A
    {
        public void GetInfo(string name)
        {
            var b = new B();
            b.PrintHello(name);
        }
    }

    public class B
    {
        public void PrintHello(string name)
        {
            Console.WriteLine($"Hello {name}");
        }
    }
}
