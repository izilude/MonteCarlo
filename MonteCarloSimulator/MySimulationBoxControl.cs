using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonteCarloCore.Simulation;
using MonteCarloCore.Simulation.Objects;

namespace MonteCarloSimulator
{
    public partial class MySimulationBoxControl : UserControl
    {
        private SimulationBox _box;

        public Pen BorderPen = new Pen(Color.Black);
        public Brush BackgroundBrush = new SolidBrush(Color.LightBlue);

        private Rectangle _area; 

        public MySimulationBoxControl()
        {
            InitializeComponent();

            _area = new Rectangle(this.Location, this.Size);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(BackgroundBrush, _area);

            if (_box == null) return;

            // convert from box dimensions to pixels
            double pixelsPerWidth = this.Width / _box.XLength;
            double pixelsPerHeight = this.Height / _box.YLength;

            foreach (var mcObject in _box.MonteCarloObjects)
            {
                if (mcObject is Circle)
                {
                    var circle = mcObject as Circle;

                    // center of sphere
                    int xPix = (int) (pixelsPerWidth * mcObject.X);
                    int yPix = (int) (pixelsPerHeight * mcObject.Y);
                    int width = (int) (pixelsPerWidth * circle.Radius);
                    int height = (int) (pixelsPerHeight * circle.Radius);
                    var rect = new Rectangle(xPix-width/2, yPix-height/2, width, height);

                    e.Graphics.FillEllipse(Brushes.Red,rect);
                }
            }
        }

        public void DrawSimulationBox(SimulationBox box)
        {
            _box = box;
            Invalidate();
        }
    }
}
