using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TasksExamples
{
    class Program
    {
        private static int Items = 0;
        private static SemaphoreSlim semSim = new SemaphoreSlim(0);

        #region Multiples Consumidores y Productores
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando tareas...\n");

            Producer p1 = new Producer(1, semSim, 10, 1000);
            Producer p2 = new Producer(2, semSim, 10, 2000);
            Producer p3 = new Producer(3, semSim, 10, 100);

            Consumer c1 = new Consumer(1, semSim, 10, 3000);
            Consumer c2 = new Consumer(2, semSim, 10, 2000);
            Consumer c3 = new Consumer(3, semSim, 10, 1000);

            Task ProductorRapido = new Task(() => p1.Produce(ref Items));
            Task ProductorLento = new Task(() => p2.Produce(ref Items));
            Task ProductorEstrella = new Task(() => p3.Produce(ref Items));
            Task Consumidor1 = new Task(() => c1.Consume(ref Items));
            Task Consumidor2 = new Task(() => c2.Consume(ref Items));
            Task Consumidor3 = new Task(() => c3.Consume(ref Items));

            ProductorRapido.Start();
            ProductorLento.Start();
            ProductorEstrella.Start();
            Consumidor1.Start();
            Consumidor2.Start();
            Consumidor3.Start();

            ProductorEstrella.Wait();
            ProductorRapido.Wait();
            ProductorLento.Wait();
            Consumidor1.Wait();
            Consumidor2.Wait();
            Consumidor3.Wait();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nSimulation Finished...");
            Console.ReadLine();
        } 
        #endregion
    }
}
