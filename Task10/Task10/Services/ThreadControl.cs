using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task10.Services
{
    class ThreadControl
    {
        private static List<Thread> Threads { get; set; }

        public static void AddThread(Thread thread)
        {
            Threads.Add(thread);
        }

        public static void KillAllThreads()
        {
            foreach (Thread t in Threads)
            {
                t.Abort();
            }
        }
    }
}
