using System;
using System.Diagnostics;
using System.Threading;

namespace CPU
{
    class Program
    {
        private static string appName;

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a Application to monitor");
            appName = Console.ReadLine();

            PerformanceCounter myAppCPU =
             new PerformanceCounter("Process", "% Processor Time", appName, true);

            Console.WriteLine("Press the any key to stop ... \n");

            if (myAppCPU != null)
            {
                while (!Console.KeyAvailable)
                {
                    double pct = myAppCPU.NextValue();
                    Console.WriteLine("CPU % = " + pct);
                    Thread.Sleep(2500);
                }
            }
            else
                Console.WriteLine("No Process found");
        }
    }
}
