using Scheduler.Core;
using System;
using System.Threading;

namespace Scheduler.Debug
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting");
            var schedulerModule = new SchedulerModule();
            schedulerModule.Run();
            Console.WriteLine("Start");

            while (Console.ReadKey().Key != ConsoleKey.Escape) ;

            Console.WriteLine("\nEnding");
            schedulerModule.Stop();
            Console.WriteLine("\nEnd");
            Thread.Sleep(1000);
        }
    }
}
