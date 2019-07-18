using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloCore
{
    public class SumUpMonteCarloJob : MonteCarloJob
    {
        public SumUpMonteCarloJob(int maxNumber)
        {
            MaxNumber = maxNumber;
        }

        public int MaxNumber;
        private int _currentIteration = 0;
        private int _count = 0;
        public double Sum = 0;

        protected override void RunInternal()
        {
            for (int i = 0; i < MaxNumber; i++)
            {
                Sum += i;
                _currentIteration = i;
                _count++;
                if (_count > MaxNumber / 20)
                {
                    _count = 0;
                    OnProgress();
                }
            }

            Console.WriteLine(Sum);
        }

        public override int GetPercentComplete()
        {
            return (int)(100.0 * ((double)_currentIteration / MaxNumber));
        }
    }
}
