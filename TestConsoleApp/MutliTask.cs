using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    public static class MutliTask
    {
        public static string UseThreads(int count, DTO dto)
        {
            var threads = new List<Thread>();

            for (int i = 0; i < 10; i++)
            {
                var thread = new Thread(() =>
                {
                    AnyMethodLogic(MethodBase.GetCurrentMethod().Name);
                    lock (dto) count++;
                });

                thread.Start();
                threads.Add(thread);
            }

            threads.ForEach(t => t.Join());

            return "Finish Thread";
        }

        public static string UseTasks(int count, DTO dto)
        {
            var tasks = new List<Task>();

            for (int i = 0; i < 10; i++)
            {
                var task = new Task(() =>
                {
                    AnyMethodLogic(MethodBase.GetCurrentMethod().Name);
                    lock (dto) count++;
                });

                task.Start();
                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());
            return "Finish Tasks";

        }

        public static string UseParallelFor(int count, DTO dto)
        {
            Parallel.For(count, 10, (i) =>
            {
                AnyMethodLogic(MethodBase.GetCurrentMethod().Name);
                lock (dto) count++;
            });
            return "Finish Parallel";
        }

        private static void AnyMethodLogic(string job)
        {
            Thread.Sleep(1000);
            Console.WriteLine($"after sleeep {job}");
        }
    }
}
