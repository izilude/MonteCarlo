using System.Collections.Generic;

namespace MonteCarloCore.Simulation
{
    public abstract class SimulationObject
    {
        // Center of Object
        public double X;
        public double Y;

        public List<SimulationMove> MoveList = new List<SimulationMove>();

        public SimulationMove GetRandomMove()
        {
            return null;
        }
    }
}
