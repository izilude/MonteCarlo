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
        private List<Label> _labels = new List<Label>();

        public Form1()
        {
            InitializeComponent();

            _labels.Add(resultLabel);
            _labels.Add(label1);
            _labels.Add(label2);
            _labels.Add(label3);
            _labels.Add(label4);
            _labels.Add(label5);
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
                box.MonteCarloObjects.Add(new Circle(x,y, radius));
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

            var newMonteCarloJob = new MonteCarloSimulationJob(box);
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
            var jobDeloegate = new JobHandler(OnProgressMethod);
            this.Invoke(jobDeloegate, reportingJob);
        }

        private void NewJob_StopEvent(Job reportingJob)
        {
            var jobDeloegate = new JobHandler(OnStopMethod);
            this.Invoke(jobDeloegate, reportingJob);
        }

        private void NewJob_StartEvent(Job reportingJob)
        {
            var jobDeloegate = new JobHandler(OnStartMethod);
            this.Invoke(jobDeloegate, reportingJob);
        }

        private void OnProgressMethod(Job reportingJob)
        {
            var percentComplete = reportingJob.GetPercentComplete();
            _labels[reportingJob.UniqueId % 6].Text = percentComplete.ToString();
        }

        private void OnStartMethod(Job reportingJob)
        {
            _labels[reportingJob.UniqueId % 6].Text = "0";
        }

        private void OnStopMethod(Job reportingJob)
        {
            _labels[reportingJob.UniqueId % 6].Text = "100";
        }
    }
}
