using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SubProcesosGUI
{
    class Corredor
    {
        private EasyCounter _status;
        /// <summary>
        /// Controla el avance del corredor
        /// </summary>
        public EasyCounter Avance
        {
            get { return _status; }
            set { _status = value; }
        }

        private bool _running;

        /// <summary>
        /// Indica si el corredor está corriendo o ya se detuvo
        /// </summary>
        public bool Running
        {
            get { return _running; }
            set { _running = value; }
        }
        
        //Declaración de los eventos que suceden cuando algo cambia en el objeto.
        public event EventHandler ValueChanged;
        public event EventHandler MaxReached;

        /// <summary>
        /// Constructor base de la clase
        /// </summary>
        public Corredor()
        {
            Avance = new EasyCounter();
            Running = true;
        }

        /// <summary>
        /// Simula la acción de correr de un objeto corredor
        /// </summary>
        /// <param name="ct">Token de cancelación para los subprocesos</param>
        public void Correr(CancellationToken ct)
        {
            while (Avance.Value < 100 && Running)
            {
                //Verifica si la tarea aún no ha sido cancelada
                if (!ct.IsCancellationRequested)
                {
                    //Aumenta el contador
                    Avance.Count();
                    ThreadSafeRandom rnd = new ThreadSafeRandom();
                    //Simula que los corredores no corran todos al mismo ritmo
                    //Se lanza el evento indicando que el valor de Estado.Value ha cambiado
                    ValueChanged(this, EventArgs.Empty);
                    Thread.Sleep(750 + rnd.Next(500));                    
                }
                else
                {
                    //Si la tarea ha sido cancelada, detener el ciclo
                    break;
                }
            }
            if (Avance.Value == 100)
            {
                //Se alcanzó el máximo, el corredor gana la carrera
                MaxReached(this, EventArgs.Empty);
            }            
        }

        public void Detenerse()
        {
            //Para detener el ciclo de correr
            Running = false;            
        }
    }
}
