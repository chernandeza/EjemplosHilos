using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TasksExamples
{
    class Consumer
    {
        private int _itemCons; //Number of consumed items

        /// <summary>
        /// Indicates the total amount of consumed items
        /// </summary>
        public int ConsumedItems
        {
            get { return _itemCons; }
            set { _itemCons = value; }
        }

        private SemaphoreSlim _semaph;

        /// <summary>
        /// Semaphore to use in the simulations
        /// </summary>
	    public SemaphoreSlim S
	    {
    		get { return _semaph;}
		    set { _semaph = value;}
	    }

        private int _id;

        /// <summary>
        /// Indicates the ID of the consumer
        /// </summary>
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }


        private int _maxItems;
        
        /// <summary>
        /// Maximum number of items to consume
        /// </summary>
        public int MAX
        {
            get { return _maxItems; }
            set { _maxItems = value; }
        }

        private int _waitingTime;

        /// <summary>
        /// Tiempo en milisegundos que tarda un item en consumirse
        /// </summary>
        public int Speed
        {
            get { return _waitingTime; }
            set { _waitingTime = value; }
        }       
        
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="ident">Identificador del proceso</param>
        /// <param name="sem">Semaforo a utilizar para sincronizar procesos</param>
        /// <param name="max">Maximo de items a consumir</param>
        /// <param name="timeToConsume">Tiempo de consumo de 1 item</param>    
        public Consumer(int ident, SemaphoreSlim sem, int max, int timeToConsume)
        {
            ID = ident;
            ConsumedItems = 0;
            S = sem;
            MAX = max;
            Speed = timeToConsume;
        }

        /// <summary>
        /// Comsumes an item. Equivalent to substract 1 to the parameter.
        /// </summary>
        /// <param name="it">Variable to substract from</param>
        public void Consume(ref int it)
        {
            while (ConsumedItems < MAX) //Ejecutar este ciclo mientras no se haya alcanzado el máximo de items a consumir
            {
                while (it == 0) //Si no hay nada que consumir, esperar.
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Consumer process " + ID + " has nothing to consume. Waiting...");
                    S.Wait();
                }
                lock (this)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("------ Consumer #" + ID + "------");
                    it--; //Consumo
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Cantidad de Items ====> " + it);
                    Thread.Sleep(Speed);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Consumer process " + ID + " has consumed " + (ConsumedItems+1) + " items.");                                
                    ConsumedItems++; //Aumentar los items consumidos
                    S.Release(); 
                }                                                     
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Consumer process " + ID + " has finished.");
        }
    }
}
