using System;
using System.Collections.Generic;

namespace MonteCarloCore.Simulation
{
    public abstract class SimulationObject
    {
        public double PreviousX;
        public double PreviousY;

        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }

        protected SimulationObject(double x, double y)
        {
            X = x;
            Y = y;

            PreviousX = x;
            PreviousY = y;

            MoveList = new List<SimulationMove>();
        }

        // Center of Object
        public double X { get; set; }
        public double Y { get; set; }

        public List<SimulationMove> MoveList { get; set; }

        public SimulationMove GetRandomMove()
        {
            int index = JobEngine.Rand.Next(MoveList.Count - 1);
            return MoveList[index];
        }

        public abstract double GetInteractionEnergy(SimulationBox box, SimulationObject iteractionObject);

        public abstract SimulationObject Duplicate();

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
