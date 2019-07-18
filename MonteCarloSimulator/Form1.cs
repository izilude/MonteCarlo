using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MonteCarloCore;

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
            CreateTestJob(100000000);
            CreateTestJob(100000000);
            CreateTestJob(100000000);
            CreateTestJob(100000000);
            CreateTestJob(100000000);
            CreateTestJob(100000000);
        }

        private void CreateTestJob(int maxNumber)
        {
            var newJob = new SumUpMonteCarloJob(maxNumber);

            newJob.StartEvent += NewJob_StartEvent;
            newJob.StopEvent += NewJob_StopEvent;
            newJob.ProgressEvent += NewJob_ProgressEvent;

            MonteCarloEngine.EnqueueNewJob(newJob);
        }

        private void NewJob_ProgressEvent(MonteCarloJob reportingJob)
        {
            var jobDeloegate = new JobHandler(OnProgressMethod);
            this.Invoke(jobDeloegate, reportingJob);
        }

        private void NewJob_StopEvent(MonteCarloJob reportingJob)
        {
            var jobDeloegate = new JobHandler(OnStopMethod);
            this.Invoke(jobDeloegate, reportingJob);
        }

        private void NewJob_StartEvent(MonteCarloJob reportingJob)
        {
            var jobDeloegate = new JobHandler(OnStartMethod);
            this.Invoke(jobDeloegate, reportingJob);
        }

        private void OnProgressMethod(MonteCarloJob reportingJob)
        {
            var percentComplete = reportingJob.GetPercentComplete();
            _labels[reportingJob.UniqueId % 6].Text = percentComplete.ToString();
        }

        private void OnStartMethod(MonteCarloJob reportingJob)
        {
            _labels[reportingJob.UniqueId % 6].Text = "0";
        }

        private void OnStopMethod(MonteCarloJob reportingJob)
        {
            _labels[reportingJob.UniqueId % 6].Text = "100";
        }
    }
}
