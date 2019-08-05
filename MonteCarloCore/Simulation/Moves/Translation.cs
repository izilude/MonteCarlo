using System;

namespace MonteCarloCore.Simulation.Moves
{
    public class Translation : SimulationMove
    {
        public double MaxDistance { get; set; } = 10;

        public override void ApplyMove(SimulationBox box, SimulationObject mcObject)
        {
            var deltaX = JobEngine.Rand.NextDouble() * 2 * MaxDistance - MaxDistance;
            var deltaY = JobEngine.Rand.NextDouble() * 2 * MaxDistance - MaxDistance;

            mcObject.X += deltaX;
            mcObject.Y += deltaY;

            if (mcObject.X > box.XLength) mcObject.X -= box.XLength;
            if (mcObject.Y > box.YLength) mcObject.Y -= box.YLength;

            if (mcObject.X < 0) mcObject.X += box.XLength;
            if (mcObject.Y < 0) mcObject.Y += box.YLength;
        }
    }
}
