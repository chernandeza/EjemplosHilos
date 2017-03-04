using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubProcesosGUI
{
    /// <summary>
    /// Esta clase implementa uso seguro de números aleatorios en distintos hilos.
    /// Los generadores de números aleatorios presentan problemas cuando se utilizan un mismo
    /// generador de números en distintos hilos, causando que todos los hilos reciban el mismo número
    /// aelatorio. Con esta clase se evita el problema.
    /// </summary>
    public class ThreadSafeRandom
    {
        private static readonly Random _global = new Random();
        [ThreadStatic]
        private static Random _local;

        public ThreadSafeRandom()
        {
            if (_local == null)
            {
                int seed;
                lock (_global)
                {
                    seed = _global.Next();
                }
                _local = new Random(seed);
            }
        }
        public int Next()
        {
            return _local.Next();
        }
        public int Next(int min, int max)
        {
            return _local.Next(min, max);
        }
        public int Next(int max)
        {
            return _local.Next(max);
        }
    }
}
