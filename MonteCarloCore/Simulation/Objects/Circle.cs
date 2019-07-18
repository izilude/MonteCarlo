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
        public Circle()
        {
            MoveList.Add(new Translation {MaxDistance = 1});
            MoveList.Add(new Translation { MaxDistance = 0.1 });
        }
    }
}
