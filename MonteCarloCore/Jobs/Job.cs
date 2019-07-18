
namespace MonteCarloCore.Jobs
{
    public abstract class Job
    {
        public static int CurrentId = 0;

        protected abstract void RunInternal();

        public void Run()
        {
            OnStart();
            RunInternal();
            OnStop();
        }

        public abstract int GetPercentComplete();

        public int UniqueId
        {
            get
            {
                if (_id == -1)
                {
                    _id = CurrentId;
                    CurrentId++;
                }
                return _id;
            }
        }

        private int _id = -1;

        public event JobHandler ProgressEvent;
        protected void OnProgress()
        {
            ProgressEvent?.Invoke(this);
        }

        public event JobHandler StartEvent;
        protected void OnStart()
        {
            StartEvent?.Invoke(this);
        }

        public event JobHandler StopEvent;
        protected void OnStop()
        {
            StopEvent?.Invoke(this);
        }
    }
}
