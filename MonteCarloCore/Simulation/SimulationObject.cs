using System;
using System.Collections.Generic;

namespace MonteCarloCore.Simulation
{
    public abstract class SimulationObject
    {
        public double PreviousX;
        public double PreviousY;

        protected SimulationObject(double x, double y)
        {
            X = x;
            Y = y;

            PreviousX = x;
            PreviousY = y;
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

        public abstract double GetInteractionEnergy(SimulationBox box, SimulationObject iteractionObject);

        public virtual void Reset()
        {
            X = PreviousX;
            Y = PreviousY;
        }

        public virtual void AcceptMove()
        {
            PreviousY = Y;
            PreviousX = X;
        }
    }
}
