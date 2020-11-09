using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelDemo
{
    class Program
    {
        static void Main()
        {
            Thread t = new Thread(WriteY); // Kick off a new thread
            t.Start();                      // running WriteY()
                                            // Simultaneously, do something on the main thread.
            for (int i = 0; i < 200; i++) Console.Write("X");
            Console.ReadLine();
        }

        static void WriteY()
        {
            for (int i = 0; i < 200; i++) Console.Write("Y");
        }

    }
}
