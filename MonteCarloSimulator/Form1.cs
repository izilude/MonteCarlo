using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MonteCarloCore;
using MonteCarloCore.Jobs;
using MonteCarloCore.Simulation;
using MonteCarloCore.Simulation.Objects;

namespace MonteCarloSimulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void runSimulationButton_Click(object sender, EventArgs e)
        {
            var widthHeight = 100;

            var box = new SimulationBox(widthHeight, widthHeight, widthHeight);

            var radius = 10;
            int N = 10;

            double x = 0;
            double y = 0;

            for (int i = 0; i < N; i++)
            {
                box.MonteCarloObjects.Add(new CircleWithPotential(x,y, radius));
                x += 2*radius;
                if (x > widthHeight)
                {
                    x = 0;
                    y += 2*radius;
                }
            }

            radius = 4;
            for (int i = 0; i < 2*N; i++)
            {
                box.MonteCarloObjects.Add(new CircleWithPotential(x, y, radius));
                x += 2 * radius;
                if (x > widthHeight)
                {
                    x = 0;
                    y += 2 * radius;
                }
            }

            UpdateMonteCarloPlot(box);

            var newMonteCarloJob = new MonteCarloSimulationJobAnnealed(box);
            newMonteCarloJob.ProgressEvent += NewJob_ProgressEvent;
            newMonteCarloJob.StartEvent += NewJob_StartEvent;
            newMonteCarloJob.StopEvent += NewJob_StopEvent;
            newMonteCarloJob.SimulationBoxChangedEvent += NewMonteCarloJob_SimulationBoxChangedEvent;
            JobEngine.EnqueueNewJob(newMonteCarloJob);
        }

        private void NewMonteCarloJob_SimulationBoxChangedEvent(SimulationBox box)
        {
            var deleg = new SimulationBoxHandler(UpdateMonteCarloPlot);
            this.Invoke(deleg, box);
        }

        private void UpdateMonteCarloPlot(SimulationBox box)
        {
            mySimulationBoxControl1.DrawSimulationBox(box);
        }

        private void NewJob_ProgressEvent(Job reportingJob)
        {
            var jobDelegate = new JobHandler(OnProgressMethod);
            this.Invoke(jobDelegate, reportingJob);
        }

        private void NewJob_StopEvent(Job reportingJob)
        {
            var jobDelegate = new JobHandler(OnStopMethod);
            this.Invoke(jobDelegate, reportingJob);
        }

        private void NewJob_StartEvent(Job reportingJob)
        {
            var jobDelegate = new JobHandler(OnStartMethod);
            this.Invoke(jobDelegate, reportingJob);
        }

        private void OnProgressMethod(Job reportingJob)
        {
            var percentComplete = reportingJob.GetPercentComplete();
            progressBar1.Value = percentComplete;
        }

        private void OnStartMethod(Job reportingJob)
        {

        }

        private void OnStopMethod(Job reportingJob)
        {

        }
    }
}
