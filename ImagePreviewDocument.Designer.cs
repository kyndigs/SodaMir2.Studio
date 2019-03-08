namespace SodaMir2.Studio
{
    partial class ImagePreviewDocument
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
            this.selectedPicturePreviewBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.selectedPicturePreviewBox)).BeginInit();
            this.SuspendLayout();
            // 
            // selectedPicturePreviewBox
            // 
            this.selectedPicturePreviewBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.selectedPicturePreviewBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedPicturePreviewBox.Location = new System.Drawing.Point(0, 0);
            this.selectedPicturePreviewBox.Name = "selectedPicturePreviewBox";
            this.selectedPicturePreviewBox.Size = new System.Drawing.Size(784, 565);
            this.selectedPicturePreviewBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.selectedPicturePreviewBox.TabIndex = 1;
            this.selectedPicturePreviewBox.TabStop = false;
            this.selectedPicturePreviewBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SelectedPicturePreviewBox_MouseMove);
            // 
            // ImagePreviewDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(784, 565);
            this.Controls.Add(this.selectedPicturePreviewBox);
            this.Name = "ImagePreviewDocument";
            this.Text = "ImagePreviewDocument";
            ((System.ComponentModel.ISupportInitialize)(this.selectedPicturePreviewBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox selectedPicturePreviewBox;
    }
}