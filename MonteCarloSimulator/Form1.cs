using System;
using System.Windows.Forms;
using MonteCarloCore;

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
            MonteCarloEngine.EnqueueNewJob(new SumUpMonteCarloJob(1000));
            MonteCarloEngine.EnqueueNewJob(new SumUpMonteCarloJob(10000));
            MonteCarloEngine.EnqueueNewJob(new SumUpMonteCarloJob(100000));
            MonteCarloEngine.EnqueueNewJob(new SumUpMonteCarloJob(1000000));
            MonteCarloEngine.EnqueueNewJob(new SumUpMonteCarloJob(10000000));
            MonteCarloEngine.EnqueueNewJob(new SumUpMonteCarloJob(100000000));
        }
    }
}
