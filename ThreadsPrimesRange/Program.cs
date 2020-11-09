using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsPrimesRange
{
    class Program
    {
        private static ConcurrentQueue<int> primes = new ConcurrentQueue<int>();
        private const int min = 3;
        private const int max = 10_000_000;

        static void Main(string[] args)
        {
            int threadCount = Environment.ProcessorCount;
            Thread[] threads = new Thread[threadCount];
            int range = (max - min) / threadCount;
            int start = min;

            for (int i = 0; i < threadCount; i++)
            {
                int startl = start;
                threads[i] = new Thread(new ThreadStart(() => GeneratePrimes(startl, range)));
                threads[i].Start();
                start += range;
            }
            for (int i = 0; i < threadCount; i++)
                threads[i].Join();
            foreach (int i in primes)
                Console.Write(i + " ");
            Console.ReadLine();
        }

        private static void GeneratePrimes(int start, int range)
        {
            var isPrime = true;
            var end = start + range;
            for (var i = start; i < end; i++)
            {
                for (var j = 2; j <= Math.Sqrt(end); j++)
                {
                    if (i != j && i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primes.Enqueue(i);
                }
                isPrime = true;
            }
        }
    }
}
