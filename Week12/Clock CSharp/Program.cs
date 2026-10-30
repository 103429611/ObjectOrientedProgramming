using System;
using System.Diagnostics;

namespace ClockApp
{
    public class Program
    {
        private static void Main(string[] args)
        {
            //Stopwatch stopwatch = Stopwatch.StartNew();
            Clock MyClock = new Clock();
            for (int i = 0; i < 10000; i++)
            {
                MyClock.Tick();
            }
            //stopwatch.Stop();
            //extract the timelapse

            Console.WriteLine(MyClock.GetTime());
            MyClock.Restart();
            Console.WriteLine(MyClock.GetTime());

            //Process process = Process.GetCurrentProcess();
            //Get the current process
            System.Diagnostics.Process proc = Process.GetCurrentProcess();
            Console.WriteLine("Current process: {0}", proc.ToString());
            //Display the total physical memory size allocated for the current
            Console.WriteLine("Physical memory usage: {0} bytes",proc.WorkingSet64);
            // Display peak memory statistics for the process.
            Console.WriteLine("Peak physical memory usage {0} bytes",proc.PeakWorkingSet64);
            //extract memory

        }
    }
}
