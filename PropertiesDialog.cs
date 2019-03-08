using SodaMir2.ImageLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace SodaMir2.Studio
{
    public partial class PropertiesDialog : ToolWindow
    {
        private MainForm _parentForm { get; set; }

        public PropertiesDialog()
        {
            InitializeComponent();
        }

        public ImageProperties CurrentProperties { get; set; }

        public void UpdateProperties(SodaImage img, ImageProperties properties)
        {
            if (img == null)
            {
                propertyGrid1.SelectedObject = img;
                return;
            }

            propertyGrid1.SelectedObject = properties;
            CurrentProperties = properties;
        }

        public void UpdateProperties(SodaImage img, MainForm form)
        {
            _parentForm = form;

            if(img == null)
            {
                propertyGrid1.SelectedObject = img;
                CurrentProperties = null;
                return;
            }

            var properties = new ImageProperties()
            {
                Height = img.Height,
                Width = img.Width,
                PlacementX = img.PlacementX,
                PlacementY = img.PlacementY,
                Size = img.Size,
                Position = img.Position
            };

            propertyGrid1.SelectedObject = properties;
            CurrentProperties = properties;

        }

        public void ClearProperties()
        {
            propertyGrid1.SelectedObject = null;
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            _parentForm.UpdateDocument();
        }
    }
}
