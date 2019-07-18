using System;

namespace MonteCarloCore.Simulation.Moves
{
    public class Translation : SimulationMove
    {
        private Random _rand = new Random();

        public double MaxDistance = 1;

        public override void ApplyMove(SimulationBox box, SimulationObject mcObject)
        {
            var deltaX = _rand.NextDouble() * 2 * MaxDistance - MaxDistance;
            var deltaY = _rand.NextDouble() * 2 * MaxDistance - MaxDistance;

            mcObject.X += deltaX;
            mcObject.Y += deltaY;
        }
    }
}
