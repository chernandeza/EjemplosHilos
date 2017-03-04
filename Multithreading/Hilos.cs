using System;
using System.Threading;

namespace Multithreading
{
    class Hilos
    {
        int miDatoCritico = 4;

        static void Main(string[] args)
        {
            Hilos h1 = new Hilos();
            Thread hilo1 = new Thread(new ParameterizedThreadStart(h1.Trabajar));
            Thread hilo2 = new Thread(new ThreadStart(h1.Descansar));
            hilo2.Priority = ThreadPriority.Highest;
            hilo1.Priority = ThreadPriority.Lowest;
            hilo1.Start(0);
            hilo2.Start();
            Console.ReadLine();            
        }

        public void Trabajar(object p)
        {
            int t = (int)p;
            while (miDatoCritico <= 20 && t < 10)
            {
                Console.WriteLine("Trabajando... ");
                Thread.Sleep(2000);
                lock (this)
                {
                    miDatoCritico++;
                    Console.WriteLine("MiDatoCritico = " + miDatoCritico);
                }                
                t++;                
            }
        }

        public void Descansar()
        {
            while (miDatoCritico >= 1)
            {
                Console.WriteLine("Descansando... ");
                Thread.Sleep(2000);
                lock (this)
                {
                    miDatoCritico--;
                    Console.WriteLine("MiDatoCritico = " + miDatoCritico);
                } 
            }
        }
    }
}
