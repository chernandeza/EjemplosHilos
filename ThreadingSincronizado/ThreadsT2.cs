using System;
using System.Threading;

namespace Threading
{
    #region Esta es la clase Threads de la tutoria #2
    class HilosT2
    {
        #region Primer ejemplo
        public static void Main()
        {
            HilosT2 t2 = new HilosT2();
            
            Thread.CurrentThread.Name = "Main"; // Ponerle nombre al hilo principal.

            Thread A = new Thread(new ThreadStart(t2.printNumbers));
            Thread B = new Thread(new ThreadStart(t2.printNumbers));

            Thread D = new Thread(new ParameterizedThreadStart(t2.printNumbers));
            Thread E = new Thread(new ParameterizedThreadStart(t2.printNumbers));


            A.Name = "A";
            A.Start();
            B.Name = "B";
            B.Start();
            D.Name = "D";
            D.Start(10);
            E.Name = "E";
            E.Start(10);

            //t2.printNumbers();
            Console.ReadLine();
        }

        
        //Imprime 12345678910 12345678910
        public void printNumbers(object m)
        {
            int q = (int)m;
            lock (this)
            {
                for (int x = 1; x <= q; x++)
                {
                    //Monitor.Pulse(this);
                    Console.Write("Hilo " + Thread.CurrentThread.Name + " -> ");
                    Console.WriteLine(x);
                    //Monitor.Wait(this);
                }
            }
        }

        //Imprime 1122334455667788991010
        public void printNumbers()
        {
            for (int x = 1; x <= 10; x++)
            {
                lock (this)
                {
                    Console.Write("Hilo " + Thread.CurrentThread.Name + " -> ");
                    Console.WriteLine(x);
                    Monitor.Pulse(this);
                    Monitor.Wait(this);
                }
            }
        }
        #endregion

        #region Segundo Ejemplo
        //------------- Segundo ejemplo -----------------

        /*static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(TestMethod));
            Thread s = new Thread(new ThreadStart(TestMethod2));
            t.Name = "Hilo T";
            s.Name = "Hilo S";
            Thread.CurrentThread.Name = "Hilo Main";
            t.Start();
            s.Start();
            TestMethod();
            Console.ReadLine();
        }

        public static void TestMethod()
        {
            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name + " -> Valor de i: " + i);
            }
        }

        public static void TestMethod2()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name + " Va a dormir 5 segundos...");
                Thread.Sleep(5000);
                Console.WriteLine(Thread.CurrentThread.Name + " Ya se desperto..."); 
            }
        }*/
        #endregion Fin de segundo ejemplo
    }
    #endregion
}

