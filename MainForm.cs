using SodaMir2.Studio.Tools;
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
    public partial class MainForm : Form
    {
        private PropertiesDialog _propertiesDialog;
        private ImageGridDialog _imageGridDialog;
        private ToolWindow _imageToolsDialog;

        public MainForm()
        {
            InitializeComponent();
            IsMdiContainer = true;

            dockPanel1.Theme = vS2015BlueTheme1;
            EnableVSRenderer(VisualStudioToolStripExtender.VsVersion.Vs2015, vS2015BlueTheme1);

            
            _imageGridDialog = new ImageGridDialog();
            _imageGridDialog.Show(dockPanel1);
            _imageGridDialog.ParentForm = this;

            _imageToolsDialog = new ToolWindow();
            _imageToolsDialog.Initialize(this);

            propertiesToolStripMenuItem.Checked = true;
            _propertiesDialog = new PropertiesDialog();
            _propertiesDialog.Show(_imageGridDialog.Pane, DockAlignment.Bottom, 0.37);
        }

        private void EnableVSRenderer(VisualStudioToolStripExtender.VsVersion version, ThemeBase theme)
        {
            vsToolStripExtender1.SetStyle(mainMenu, version, theme);
        }

        public void CreateImagePreview(int index)
        {
            var doc = new ImagePreviewDocument();
            doc.Initialize(this);
            doc.CurrentImageIndex = index;
            doc.Text = String.Format("{0}: {1}", "Image", index);
            doc.Show(dockPanel1);
        }

        public void UpdateImagePreview()
        {
            if (dockPanel1.ActiveDocument == null)
            {
                CreateImagePreview(0);
            }

            var doc = (ImagePreviewDocument)dockPanel1.ActiveDocument;
            var grid = _imageGridDialog.GetImageGrid();

            doc.SetImage(grid);
            doc.Text = String.Format("{0}: {1}", grid.LibraryName, grid.SelectedIndex);

            _propertiesDialog.UpdateProperties(doc.CurrentImage, this);
            doc.CurrentProperties = _propertiesDialog.CurrentProperties;
            doc.UpdateImage(_imageToolsDialog.CurrentZoom, _imageToolsDialog.CurrentInterpolation);
        }

        private void openImageLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openImageLibDialog.ShowDialog();

            if (System.IO.File.Exists(openImageLibDialog.FileName))
            {
               _imageGridDialog.InitializeImageGrid(openImageLibDialog.FileName);

                //CreateImagePreview(0);
                UpdateImagePreview();
            }
        }

        public void UpdateCoords(int x, int y)
        {
            _imageToolsDialog.UpdateCoords(x, y);
        }

        public void UpdateDocument()
        {
            try
            {
                var doc = (ImagePreviewDocument)dockPanel1.ActiveDocument;
                var grid = _imageGridDialog.GetImageGrid();

                grid.SetSelectedIndex(doc.CurrentImageIndex);
                grid.ScrollToIndex(doc.CurrentImageIndex);
                doc.RefreshImage(grid);

                _propertiesDialog.UpdateProperties(doc.CurrentImage, doc.CurrentProperties);
                doc.UpdateImage(_imageToolsDialog.CurrentZoom, _imageToolsDialog.CurrentInterpolation);           
            }
            catch(Exception)
            {
                // Ignore
            }
        }

        private void dockPanel1_ActiveDocumentChanged(object sender, EventArgs e)
        {
            UpdateDocument();
        }

        private void ToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolsToolStripMenuItem.Checked)
            {
                _imageToolsDialog.Show(dockPanel1, DockState.DockLeft);
            }
            else
            {
                _imageToolsDialog.Hide();
            }
        }

        private void PropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (propertiesToolStripMenuItem.Checked)
            {
                _propertiesDialog.Show(_imageGridDialog.Pane, DockAlignment.Bottom, 0.37);
            }
            else
            {
                _propertiesDialog.Hide();
            }
        }

        private void ExportImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var image = _imageGridDialog.ExportImage();

                if (image != null)
                {
                    saveFileDialog1.ShowDialog();
                    image.Save(saveFileDialog1.FileName);
                    MessageBox.Show(saveFileDialog1.FileName + " Exported Succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }              
            }
            catch (Exception)
            {
                MessageBox.Show("Error Exporting Image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NpcManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var npcManager = new NpcManager();
            npcManager.Show();
        }

        private void ConvertWilsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var wilForm = new ConvertWils();
            wilForm.ShowDialog();
        }
    }
}
