using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MonteCarloCore
{
    public class MonteCarloEngineThread
    {
        public MonteCarloEngineThread(Queue<MonteCarloJob> jobQueue, string threadNickName)
        {
            _jobs = jobQueue;
            var thread = new Thread(RunMethod);
            thread.Name = threadNickName;
            thread.Start();
        }

        public void Stop()
        {
            _running = false;
        }

        private bool _running = true;
        private Queue<MonteCarloJob> _jobs;

        public void RunMethod()
        {
            while (_running)
            {
                Thread.Sleep(50);

                MonteCarloJob currentJob = null;
                lock (_jobs)
                {
                    if (_jobs.Count > 0)
                    {
                        currentJob = _jobs.Dequeue();
                    }
                }
                if (currentJob != null) currentJob.Run();
            }
        }
    }
}
