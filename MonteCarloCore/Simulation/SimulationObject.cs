using System;
using System.Collections.Generic;

namespace MonteCarloCore.Simulation
{
    public abstract class SimulationObject
    {
        protected SimulationObject(double x, double y)
        {
            X = x;
            Y = y;
        }

        // Center of Object
        public double X;
        public double Y;

        public List<SimulationMove> MoveList = new List<SimulationMove>();

        public SimulationMove GetRandomMove()
        {
            int index = JobEngine.Rand.Next(MoveList.Count - 1);
            return MoveList[index];
        }

        public abstract double GetPotentialEnergy(double x, double y);

        public abstract double GetEnergy(SimulationBox box);
    }
}
