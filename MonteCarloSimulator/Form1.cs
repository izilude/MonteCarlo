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
        public List<string> SupportedObjects = new List<string>() {"Circle", "CircleWithPotential"};

        private SimulationObject _objectTemplate;
        private MonteCarloSimulationJob _currentJob = new MonteCarloSimulationJobAnnealed();

        public Form1()
        {
            InitializeComponent();

            propertyGrid1.SelectedObject = _currentJob;

            foreach (var ob in SupportedObjects)
            {
                objectTypeSelectionComboBox.Items.Add(ob);
            }
            objectTypeSelectionComboBox.SelectedIndex = 0;
        }
        
        private void runSimulationButton_Click(object sender, EventArgs e)
        {
            //var widthHeight = 100;

            //var box = new SimulationBox(widthHeight, widthHeight, widthHeight);

            //var radius = 10;
            //int N = 10;

            //double x = 0;
            //double y = 0;

            //for (int i = 0; i < N; i++)
            //{
            //    box.MonteCarloObjects.Add(new CircleWithPotential(x,y, radius));
            //    x += 2*radius;
            //    if (x > widthHeight)
            //    {
            //        x = 0;
            //        y += 2*radius;
            //    }
            //}

            //radius = 4;
            //for (int i = 0; i < 2*N; i++)
            //{
            //    box.MonteCarloObjects.Add(new CircleWithPotential(x, y, radius));
            //    x += 2 * radius;
            //    if (x > widthHeight)
            //    {
            //        x = 0;
            //        y += 2 * radius;
            //    }
            //}

            UpdateMonteCarloPlot(_currentJob.Box);

            _currentJob.ProgressEvent += NewJob_ProgressEvent;
            _currentJob.StartEvent += NewJob_StartEvent;
            _currentJob.StopEvent += NewJob_StopEvent;
            _currentJob.SimulationBoxChangedEvent += NewMonteCarloJob_SimulationBoxChangedEvent;
            JobEngine.EnqueueNewJob(_currentJob);
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

        private void addObjectsButton_Click(object sender, EventArgs e)
        {
            if (_objectTemplate == null) return;

            int number;
            if (!int.TryParse(numberOfObjectsToAdd.Text, out number))
            {
                MessageBox.Show("Number of Objects must be an integer!");
                return;
            }

            for (int i = 0; i < number; i++)
            {
                var newObject =  _objectTemplate.Duplicate();

                double x = JobEngine.Rand.NextDouble() * _currentJob.Box.XLength;
                double y = JobEngine.Rand.NextDouble() * _currentJob.Box.YLength;

                newObject.X = x;
                newObject.Y = y;
                newObject.PreviousX = x;
                newObject.PreviousY = y;

                _currentJob.Box.MonteCarloObjects.Add(newObject);
            }

            UpdateMonteCarloPlot(_currentJob.Box);

            propertyGrid1.SelectedObject = null;
            propertyGrid1.SelectedObject = _currentJob;
        }

        private void objectTypeSelectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var objectType = objectTypeSelectionComboBox.SelectedItem;
            if (objectType == null) return;

            switch (objectType)
            {
                case "Circle":
                    _objectTemplate = new Circle(1, 1, 1);
                    break;
                case "CircleWithPotential":
                    _objectTemplate = new CircleWithPotential(1, 1, 1);
                    break;
                default:
                    throw new Exception(String.Format("I don't know how to create a {0} simulation object", objectType));
            }

            objectTemplatePropertyGrid.SelectedObject = _objectTemplate;
        }
    }
}
