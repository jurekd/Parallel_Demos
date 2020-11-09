using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsPrimes
{
    class Program
    {
        private static ConcurrentQueue<int> primes = new ConcurrentQueue<int>();

        static void Main(string[] args)
        {
            int max = 100_000;
            Thread[] threads = new Thread[max-3];
            for (int i = 0; i < max-3; i++)
            {
                int x = i + 3;
                threads[i] = new Thread(CheckPrime);
                threads[i].Start(i+3);
            }
            for (int i = 0; i < max-3; i++)
               threads[i].Join();
            foreach (int i in primes)
                Console.Write(i+" ");
            Console.ReadLine();
        }

        private static void CheckPrime(object o)
        {
            int number = (int)o;
            for (int x = 2; x <= Math.Sqrt(number); x++)
                {
                    if (number % x == 0)
                    {
                        return;
                    }
                }
             primes.Enqueue(number);
        }
    }
}
