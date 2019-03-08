using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace SodaMir2.Studio
{
    public partial class ToolWindow : DockContent
    {
        private MainForm _parentForm { get; set; }
        public double CurrentZoom { get; set; }
        public InterpolationMode CurrentInterpolation { get; set; }

        public ToolWindow()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;
            CurrentZoom = 1.0;
            CurrentInterpolation = InterpolationMode.Default;
        }

        public void Initialize(MainForm parent)
        {
            _parentForm = parent;
        }

        public static double[] ZoomValues = new double[] { 1.0, 2.0, 4.0, 8.0, 16.0, 24.0, 32.0, 64.0 };

        private void ZoomSlider_Scroll(object sender, EventArgs e)
        {
            if (ZoomSlider.Value <= ZoomValues.Length - 1)
            {
                CurrentZoom = ZoomSlider.Value;
                lblZoomValue.Text = CurrentZoom.ToString();
                _parentForm.UpdateDocument();
            }
        }

        public InterpolationMode[] InterPolationValues = new InterpolationMode[]
        {
                    InterpolationMode.Bicubic,
                    InterpolationMode.Bilinear,
                    InterpolationMode.Default,
                    InterpolationMode.High,
                    InterpolationMode.HighQualityBicubic,
                    InterpolationMode.HighQualityBilinear,
                    InterpolationMode.Low,
                    InterpolationMode.NearestNeighbor
        };

        private void CboInterpolation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboInterpolation.SelectedIndex <= InterPolationValues.Length - 1)
            {
                CurrentInterpolation = InterPolationValues[cboInterpolation.SelectedIndex];
                _parentForm.UpdateDocument();
            }
        }

        public void UpdateCoords(int x, int y)
        {
            var xx = x;
            var yy = y;

            txtCoordinates.Text = xx + ":" + yy;
        }

    }
}
