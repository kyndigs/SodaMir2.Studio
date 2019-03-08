namespace SodaMir2.Studio
{
    partial class ToolWindow
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
            this.cboInterpolation = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblZoomValue = new System.Windows.Forms.Label();
            this.ZoomSlider = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCoordinates = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // cboInterpolation
            // 
            this.cboInterpolation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboInterpolation.FormattingEnabled = true;
            this.cboInterpolation.Items.AddRange(new object[] {
            "Bicubic",
            "Bilinear",
            "Default",
            "High",
            "High Quality Bicubic",
            "High Quality Bilinear",
            "Low",
            "NearestNeighbor"});
            this.cboInterpolation.Location = new System.Drawing.Point(18, 132);
            this.cboInterpolation.Name = "cboInterpolation";
            this.cboInterpolation.Size = new System.Drawing.Size(182, 21);
            this.cboInterpolation.TabIndex = 14;
            this.cboInterpolation.Text = "Default";
            this.cboInterpolation.SelectedIndexChanged += new System.EventHandler(this.CboInterpolation_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Interpolation";
            // 
            // lblZoomValue
            // 
            this.lblZoomValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblZoomValue.AutoSize = true;
            this.lblZoomValue.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblZoomValue.Location = new System.Drawing.Point(181, 18);
            this.lblZoomValue.Name = "lblZoomValue";
            this.lblZoomValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblZoomValue.Size = new System.Drawing.Size(22, 13);
            this.lblZoomValue.TabIndex = 12;
            this.lblZoomValue.Text = "1.0";
            this.lblZoomValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ZoomSlider
            // 
            this.ZoomSlider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ZoomSlider.Location = new System.Drawing.Point(8, 47);
            this.ZoomSlider.Maximum = 7;
            this.ZoomSlider.Minimum = 1;
            this.ZoomSlider.Name = "ZoomSlider";
            this.ZoomSlider.Size = new System.Drawing.Size(200, 45);
            this.ZoomSlider.TabIndex = 11;
            this.ZoomSlider.Value = 1;
            this.ZoomSlider.Scroll += new System.EventHandler(this.ZoomSlider_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Zoom";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Coordinates";
            // 
            // txtCoordinates
            // 
            this.txtCoordinates.Location = new System.Drawing.Point(18, 211);
            this.txtCoordinates.Name = "txtCoordinates";
            this.txtCoordinates.Size = new System.Drawing.Size(182, 20);
            this.txtCoordinates.TabIndex = 16;
            // 
            // ToolWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 307);
            this.Controls.Add(this.txtCoordinates);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboInterpolation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblZoomValue);
            this.Controls.Add(this.ZoomSlider);
            this.Controls.Add(this.label1);
            this.HideOnClose = true;
            this.Name = "ToolWindow";
            this.Text = "ToolWindow";
            ((System.ComponentModel.ISupportInitialize)(this.ZoomSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cboInterpolation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblZoomValue;
        private System.Windows.Forms.TrackBar ZoomSlider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCoordinates;
    }
}