using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            MoveList.Add(new Translation {MaxDistance = 1});
            MoveList.Add(new Translation { MaxDistance = 0.1 });
        }

        public override double GetPotentialEnergy(double x, double y)
        {
            // Implement a hardwall boundary condition;
            double r = (x - X) * (x - X) + (y - Y) * (y - Y);
            if (r > Radius * Radius) return 0;
            else return 10000000.0;
        }

        public override double GetEnergy(SimulationBox box)
        {
            // Want to integrate the area of the object over the potential energy
            double energy = 0;

            

            return energy;
        }
    }
}
