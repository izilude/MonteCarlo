using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace MonteCarloCore
{
    public static class JobEngine
    {
        private static Queue<Job> _jobs = new Queue<Job>();
        private static List<JobEngineThread> _threads = new List<JobEngineThread>();

        public static void Start()
        {
            _threads.Add(new JobEngineThread(_jobs, "Engine Thread 1"));
            //_threads.Add(new JobEngineThread(_jobs, "Engine Thread 2"));
        }

        public static void Stop()
        {
            foreach (var thread in _threads)
            {
                thread.Stop();
            }
        }

        public static void EnqueueNewJob(Job newJob)
        {
            lock (_jobs)
            {
                _jobs.Enqueue(newJob);
            }
        }
    }
}
