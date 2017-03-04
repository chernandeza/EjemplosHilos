using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TasksExamples
{
    class Producer
    {
        private int _itemProd; //Number of produced items

        /// <summary>
        /// Indicates the total amount of produced items
        /// </summary>
        public int ProducedItems
        {
            get { return _itemProd; }
            set { _itemProd = value; }
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
        /// Indicates the ID of the producer
        /// </summary>
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }


        private int _maxItems;
        
        /// <summary>
        /// Maximum number of items to produce
        /// </summary>
        public int MAX
        {
            get { return _maxItems; }
            set { _maxItems = value; }
        }

        private int _waitingTime;

        /// <summary>
        /// Tiempo en milisegundos que tarda un item en producirse
        /// </summary>
        public int Speed
        {
            get { return _waitingTime; }
            set { _waitingTime = value; }
        }     

        /// <summary>
        /// Constructor of the class
        /// </summary>
        /// <param name="ident">Identification number of the producer</param>
        /// <param name="sem">Semaphore to use in the simulation</param>
        /// <param name="max">Maximum number of items to produce</param>
        /// <param name="timeToProduce">Tiempo de produccion de 1 item</param>    
        public Producer(int ident, SemaphoreSlim sem, int max, int timeToProduce)
        {
            ID = ident;
            ProducedItems = 0;
            S = sem;
            MAX = max;
            Speed = timeToProduce;
        }


        /// <summary>
        /// Produces an item. Equivalent to add 1 to the parameter.
        /// </summary>
        /// <param name="it">Variable to add to</param>
        public void Produce(ref int it)
        {
            while (ProducedItems < MAX)
            {
                //Bloqueo del objeto para aumentarlo.
                lock (this)
                {
                    it++; //Producción
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Cantidad de Items ====> " + it);
                    
                    ProducedItems++; //Aumenta cantidad de items producidos para controlar
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("------ Producer #" + ID + "------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Total items produced by me = " + ProducedItems);
                    Thread.Sleep(Speed); //El tiempo de producción de 1 item es de 500 milisegundos.
                    S.Release();                              
                }                
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Nothing more to produce. Producer process " + ID + " has finished.");
        }        
    }
}
