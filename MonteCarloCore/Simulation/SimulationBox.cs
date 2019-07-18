using System.Collections.Generic;

namespace MonteCarloCore.Simulation
{
    public class SimulationBox
    {
        public List<SimulationObject> MonteCarloObjects = new List<SimulationObject>();

        public SimulationObject GetRandomObject()
        {
            return null;
        }

        public double CalculateEnergy()
        {
            return 0;
        }

        public void RejectAllMoves()
        {
            
        }
    }
}
