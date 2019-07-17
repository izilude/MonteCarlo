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
        public double Sum = 0;

        public override void Run()
        {
            base.Run();

            for (int i = 0; i < MaxNumber; i++)
            {
                Sum += i;
            }

            Console.WriteLine(Sum);
        }
    }
}
