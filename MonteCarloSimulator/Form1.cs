using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MonteCarloCore;
using MonteCarloCore.Jobs;
using MonteCarloCore.Simulation;

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
            var box = new SimulationBox();

            var newMonteCarloJob = new MonteCarloSimulationJob(box);
            JobEngine.EnqueueNewJob(newMonteCarloJob);
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
