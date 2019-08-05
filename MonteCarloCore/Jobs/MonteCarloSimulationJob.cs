using System;
using System.Collections.Generic;
using MonteCarloCore.Simulation;

namespace MonteCarloCore.Jobs
{
    public class MonteCarloSimulationJob : Job
    {
        public MonteCarloSimulationJob(SimulationBox box)
        {
            Box = box;
        }


        public int Cycles { get; set; } = 100000;
        public int MovesPerCycle { get; set; } = 1;
        private int _currentCycle = 0;

        public SimulationBox Box { get; set; }

        protected override void RunInternal()
        {
            double previousEnergy = Box.CalculateEnergy();

            for (int i = 0; i < Cycles; i++)
            {
                _currentCycle = i;

                for (int j = 0; j < MovesPerCycle; j++)
                {
                    SimulationObject mcObject = Box.GetRandomObject();
                    SimulationMove moveType = mcObject.GetRandomMove();
                    moveType.ApplyMove(Box, mcObject);
                }

                var energy = Box.CalculateEnergy();
                if (IsMoveAcceptable(previousEnergy, energy))
                {
                    previousEnergy = energy;
                    Box.AcceptAllMoves();
                    OnChanged();
                }
                else
                {
                    Box.RejectAllMoves();
                }

                OnProgress();
            }
        }

        public event SimulationBoxHandler SimulationBoxChangedEvent;
        private void OnChanged()
        {
            SimulationBoxChangedEvent?.Invoke(Box);
        }

        protected virtual bool IsMoveAcceptable(double previousEnergy, double currentEnergy)
        {
            return currentEnergy <= previousEnergy;
        }

        public override int GetPercentComplete()
        {
            return (int)(100.0*_currentCycle / Cycles);
        }
    }
}
