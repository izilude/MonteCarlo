using System;
using MonteCarloCore.Simulation;

namespace MonteCarloCore.Jobs
{
    public class MonteCarloSimulationJobAnnealed : MonteCarloSimulationJob
    {
        public double Temperature = 0.5;

        public MonteCarloSimulationJobAnnealed(SimulationBox box) 
            : base(box)
        {
        }

        protected override bool IsMoveAcceptable(double previousEnergy, double currentEnergy)
        {
            if (currentEnergy < previousEnergy) return true;

            double prob = Math.Exp(-(currentEnergy - previousEnergy)* (currentEnergy - previousEnergy)/Temperature);

            double roll = JobEngine.Rand.NextDouble();

            return roll < prob;
        }
    }
}
