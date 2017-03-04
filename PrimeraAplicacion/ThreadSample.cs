using System;
using System.Threading;

namespace PrimeraAplicacion
{
    class ThreadSample
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(TestMethod));
            t.Name = "Hilo T";
            t.Start();            
            Thread.CurrentThread.Name = "Hilo Main";
            TestMethod();
            Console.ReadLine();
        }

        public static void TestMethod()
        {
            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name + " Valor de i: " + i);
            }
        }
    }
}
