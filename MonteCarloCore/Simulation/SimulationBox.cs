using System;
using System.Collections.Generic;

namespace MonteCarloCore.Simulation
{
    public class SimulationBox
    {
        public SimulationBox(double xLength, double yLength, int divisions)
        {
            PotentialEnergy = new double[divisions,divisions];
            XLength = xLength;
            YLength = yLength;
            Divisions = divisions;
        }

        public int Divisions { get; private set; }
        public double XLength { get; private set; }
        public double YLength { get; private set; }

        protected double[,] PotentialEnergy;

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
