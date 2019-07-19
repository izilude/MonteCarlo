using System;
using System.Collections.Generic;

namespace MonteCarloCore.Simulation
{
    public class SimulationBox
    {
        Random _rand = new Random();

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
            int index = _rand.Next(MonteCarloObjects.Count - 1);   
            return MonteCarloObjects[index];
        }

        public void CalculatePotentialEnergy()
        {
            for (int i = 0; i < Divisions; i++)
            {
                for (int j = 0; j < Divisions; j++)
                {
                    PotentialEnergy[i, j] = 0;

                    double x = i * XLength / Divisions;
                    double y = i * YLength / Divisions;

                    foreach (var mcObject in MonteCarloObjects)
                    {
                        PotentialEnergy[i, j] += mcObject.GetPotentialEnergy(x,y);
                    }
                }
            }
        }

        public double CalculateEnergy()
        {
            double energy = 0;

            CalculatePotentialEnergy();

            foreach (var mcObject in MonteCarloObjects)
            {
                energy += mcObject.GetEnergy(this);
            }

            return energy;
        }

        public void RejectAllMoves()
        {
            
        }
    }
}
