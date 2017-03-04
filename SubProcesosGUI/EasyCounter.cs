using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubProcesosGUI
{
    class EasyCounter
    {
        private int _value;

        /// <summary>
        /// Indica el valor actual del contador
        /// </summary>
        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }               

        /// <summary>
        /// Constructor base de la clase
        /// </summary>
        public EasyCounter()
        {
            Value = 0;
        }

        /// <summary>
        /// Cuenta de 0 a 100 en números aleatorios cuyos saltos van de 0 a 10.
        /// </summary>
        public void Count()
        {
            int count = 0;
            int suma = 0;
            ThreadSafeRandom rnd = new ThreadSafeRandom();
            count = rnd.Next(1, 10); 
            suma = Value + count;

            lock (this)
            {
                if (suma >= 100)
                {
                    Value = 100;
                }
                else
                {
                    if (suma < 0)
                    {
                        Value = 0;
                    }
                    else
                    {
                        Value += count;
                    }
                } 
            }            
        }
    }
}
