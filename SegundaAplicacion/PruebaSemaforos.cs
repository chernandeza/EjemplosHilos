using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SegundaAplicacion
{
    class PruebaSemaforos
    {
        private int _miDato;

        public int MiDato
        {
            get { return _miDato; }
            set { _miDato = value; }
        }

        private SemaphoreSlim _semCont;

        public SemaphoreSlim SemafControl
        {
            get { return _semCont; }
            set { _semCont = value; }
        }

        public PruebaSemaforos()
        {
            this._semCont = new SemaphoreSlim(1);
            this._miDato = 1;
        }

        public void SumaDato()
        {
            while (true)
            {
                Console.WriteLine("Suma Esperando");
                SemafControl.Wait();
                this.MiDato++;
                Console.WriteLine("Mi dato en suma = " + this.MiDato);
                SemafControl.Release();
                Console.WriteLine("Suma Liberando");
                Thread.Sleep(1000);
            }
        }

        public void RestaDato()
        {
            while (true)
            {
                Console.WriteLine("Resta Esperando");
                SemafControl.Wait();
                this.MiDato--;
                Console.WriteLine("Mi dato en resta = " + this.MiDato);
                SemafControl.Release();
                Console.WriteLine("Resta Liberando");                
                Thread.Sleep(1000);
            }
        }

        static void Main(string[] args)
        {
            PruebaSemaforos miPrueba = new PruebaSemaforos();

            //Task ProductorRapido = new Task(() => p1.Produce(ref Items));
            Task tareaAumentar = new Task(() => miPrueba.SumaDato());
            Task tareaDisminuir = new Task(() => miPrueba.RestaDato());

            tareaAumentar.Start();
            tareaDisminuir.Start();

            tareaAumentar.Wait();
            tareaDisminuir.Wait();

            Console.ReadLine();
        }
    }
}
