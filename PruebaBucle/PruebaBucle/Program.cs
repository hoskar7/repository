using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaBucle
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxLoop = 10;
            int initialLoop = 0;

            //While
            while (initialLoop < maxLoop)
            {
                var result = Context.Session.Instance.TurnosDalc.EntregarInforme();
                Console.WriteLine(result);

                initialLoop++;
            }

            //foreach
            foreach (int value in new List<int>(new int[]{1,2,3,4,5,6,7,8,9}))
            {
                var result = Context.Session.Instance.TurnosDalc.EntregarInforme();
                Console.WriteLine(result);
            }

            //for
            for (int value = 0; value < maxLoop; value ++)
            {
                var result = Context.Session.Instance.TurnosDalc.EntregarInforme();
                Console.WriteLine(result);
            }

            Console.Read();
        }
    }
}

namespace Context
{


    public class Session
    {
        private static Session _instance;
        static readonly object syncLock = new object();

        public static Session Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Session();
                        }
                    }
                }

                return _instance;
            }
        }

        public TurnosDalc TurnosDalc { get { return new TurnosDalc(); } }
    }

    public class TurnosDalc
    {
        public string EntregarInforme()
        { 
            return System.Threading.Thread.CurrentThread.ManagedThreadId.ToString();
        }
    }
}
