using System;

namespace MonteCarloCore.Simulation.Objects
{
    public class CircleWithPotential : Circle
    {
        public double MinimumPotentialDistance = 0;
        public double PotentialStrength = 1;

        public CircleWithPotential(double x, double y, double radius) 
            : base(x, y, radius)
        {
        }

        public override double GetInteractionEnergy(SimulationBox box, SimulationObject interactingObject)
        {
            double energy = 0;

            if (interactingObject is CircleWithPotential circleWithPotential)
            {
                energy = CirclePotentialInteraction(box, circleWithPotential);
            }
            else
            {
                energy = base.GetInteractionEnergy(box, interactingObject);
            }

            return energy;
        }

        private double CirclePotentialInteraction(SimulationBox box, CircleWithPotential circle)
        {
            double dx = Math.Abs(circle.X - X);
            if (dx > box.XLength / 2) dx = box.XLength - dx;

            double dy = Math.Abs(circle.Y - Y);
            if (dy > box.YLength / 2) dy = box.YLength - dy;

            double r = Math.Sqrt(dx * dx + dy * dy);

            if (!(r > circle.Radius + Radius))
            {
                double slope = (10 - 100) / (circle.Radius + Radius);
                double intercept = 100;

                return slope * r + intercept;
            }

            double ratio = (circle.Radius + Radius + MinimumPotentialDistance)/r;
            var energy = PotentialStrength * (Math.Pow(ratio, 12) - 2 * Math.Pow(ratio, 6));

            return energy;
        }
    }
}
