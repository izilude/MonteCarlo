using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace MonteCarloCore
{
    public static class MonteCarloEngine
    {
        private static Queue<MonteCarloJob> _jobs = new Queue<MonteCarloJob>();
        private static List<MonteCarloEngineThread> _threads = new List<MonteCarloEngineThread>();

        public static void Start()
        {
            _threads.Add(new MonteCarloEngineThread(_jobs, "Engine Thread 1"));
            //_threads.Add(new MonteCarloEngineThread(_jobs, "Engine Thread 2"));
            //_threads.Add(new MonteCarloEngineThread(_jobs, "Engine Thread 3"));
            //_threads.Add(new MonteCarloEngineThread(_jobs, "Engine Thread 4"));
            //_threads.Add(new MonteCarloEngineThread(_jobs, "Engine Thread 5"));
            //_threads.Add(new MonteCarloEngineThread(_jobs, "Engine Thread 6"));
        }

        public static void Stop()
        {
            foreach (var thread in _threads)
            {
                thread.Stop();
            }
        }

        public static void EnqueueNewJob(MonteCarloJob newJob)
        {
            lock (_jobs)
            {
                _jobs.Enqueue(newJob);
            }
        }
    }
}
