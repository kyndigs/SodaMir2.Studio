namespace SodaMir2.Studio
{
    partial class ImageGridDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.imageGrid1 = new SodaMir2.Studio.Component.ImageGrid();
            this.SuspendLayout();
            // 
            // imageGrid1
            // 
            this.imageGrid1.AutoScroll = true;
            this.imageGrid1.AutoScrollMinSize = new System.Drawing.Size(464, 592);
            this.imageGrid1.CellHeight = 64;
            this.imageGrid1.CellWidth = 64;
            this.imageGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageGrid1.Location = new System.Drawing.Point(0, 0);
            this.imageGrid1.Name = "imageGrid1";
            this.imageGrid1.SelectedColor = System.Drawing.Color.RoyalBlue;
            this.imageGrid1.SelectedColorAlpha = 100;
            this.imageGrid1.Size = new System.Drawing.Size(446, 624);
            this.imageGrid1.TabIndex = 3;
            this.imageGrid1.Click += new System.EventHandler(this.imageGrid1_Click);
            // 
            // ImageGridDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(446, 624);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.imageGrid1);
            this.Name = "ImageGridDialog";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockRight;
            this.Text = "Images";
            this.Resize += new System.EventHandler(this.ImageGridDialog_Resize);
            this.Controls.SetChildIndex(this.imageGrid1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Component.ImageGrid imageGrid1;
    }
}