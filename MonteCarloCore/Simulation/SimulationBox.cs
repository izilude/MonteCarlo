using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MonteCarloCore.Simulation
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class SimulationBox
    {
        public SimulationBox()
        {

        }

        public SimulationBox(double xLength, double yLength)
        {
            XLength = xLength;
            YLength = yLength;
        }

        public double XLength { get; set; } = 100;
        public double YLength { get; set; } = 100;

        public List<SimulationObject> MonteCarloObjects = new List<SimulationObject>();
        public SimulationObject GetRandomObject()
        {
            int index = JobEngine.Rand.Next(MonteCarloObjects.Count);   
            return MonteCarloObjects[index];
        }

        public double CalculateEnergy()
        {
            double energy = 0;

            for (var i = 0; i < MonteCarloObjects.Count; i++)
            {
                var mcObject1 = MonteCarloObjects[i];
                for (var j = i+1; j < MonteCarloObjects.Count; j++)
                {
                    var mcObject2 = MonteCarloObjects[j];
                    energy += mcObject1.GetInteractionEnergy(this, mcObject2);
                }
            }

            return energy;
        }

        public void RejectAllMoves()
        {
            foreach (var mcObject in MonteCarloObjects)
            {
                mcObject.Reset();
            }
        }

        public void AcceptAllMoves()
        {
            foreach (var mcObject in MonteCarloObjects)
            {
                mcObject.AcceptMove();
            }
        }
    }
}
