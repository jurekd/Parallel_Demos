using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelTest
{
    class Program
    {
        private static void Main(string[] args)
        {
            int sum = 0;
            for (int i = 0; i < 100000; i++)
            {
                sum += i;
            }
            Console.WriteLine(sum);

            sum = 0;
            object synlock = new object();
            Parallel.For(0, 100000, i =>
            {
                lock (synlock)
                    sum += i;
            });
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
