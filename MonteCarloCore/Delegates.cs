using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonteCarloCore.Jobs;
using MonteCarloCore.Simulation;

namespace MonteCarloCore
{
    public delegate void JobHandler(Job reportingJob);
    public delegate void SimulationBoxHandler(SimulationBox box);
}
