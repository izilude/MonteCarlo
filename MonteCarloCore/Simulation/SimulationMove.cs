namespace MonteCarloCore.Simulation
{
    public abstract class SimulationMove
    {
        public abstract void ApplyMove(SimulationBox box, SimulationObject mcObject);
    }
}
