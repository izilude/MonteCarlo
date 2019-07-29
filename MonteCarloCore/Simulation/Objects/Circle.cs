using System;
using MonteCarloCore.Simulation.Moves;

namespace MonteCarloCore.Simulation.Objects
{
    public class Circle : SimulationObject
    {
        public double Radius;

        public Circle(double x, double y, double radius) 
            : base(x,y)
        {
            Radius = radius;
            MoveList.Add(new Translation {MaxDistance = 20});
        }

        public override double GetInteractionEnergy(SimulationBox box, SimulationObject interactingObject)
        {
            // Want to integrate the area of the object over the potential energy
            double energy = 0;

            if (interactingObject is Circle circle)
            {
                energy = CircleInteraction(box, circle);
            }
            else
            {
                throw new Exception("I don't know how to interact with this object!");
            }
            

            return energy;
        }

        private double CircleInteraction(SimulationBox box, Circle circle)
        {
            double dx = Math.Abs(circle.X - X);
            if (dx > box.XLength / 2) dx = box.XLength - dx;

            double dy = Math.Abs(circle.Y - Y);
            if (dy > box.YLength / 2) dy = box.YLength - dy;

            double r = Math.Sqrt(dx * dx + dy * dy);

            if (r > circle.Radius + Radius)
            {
                return 0;
            }

            double slope = (10 - 100)/(circle.Radius + Radius);
            double intercept = 100;

            return slope* r + intercept;
        }
    }
}
