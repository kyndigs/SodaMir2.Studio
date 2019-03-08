namespace SodaMir2.Studio.Tools
{
    partial class NpcManager
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
            this.lstNpcList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNpcCount = new System.Windows.Forms.Label();
            this.picNpcPreview = new System.Windows.Forms.PictureBox();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            ((System.ComponentModel.ISupportInitialize)(this.picNpcPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // lstNpcList
            // 
            this.lstNpcList.FormattingEnabled = true;
            this.lstNpcList.Location = new System.Drawing.Point(12, 51);
            this.lstNpcList.Name = "lstNpcList";
            this.lstNpcList.Size = new System.Drawing.Size(222, 459);
            this.lstNpcList.TabIndex = 0;
            this.lstNpcList.SelectedIndexChanged += new System.EventHandler(this.LstNpcList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Npc Count:";
            // 
            // lblNpcCount
            // 
            this.lblNpcCount.AutoSize = true;
            this.lblNpcCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNpcCount.Location = new System.Drawing.Point(79, 21);
            this.lblNpcCount.Name = "lblNpcCount";
            this.lblNpcCount.Size = new System.Drawing.Size(13, 13);
            this.lblNpcCount.TabIndex = 2;
            this.lblNpcCount.Text = "0";
            // 
            // picNpcPreview
            // 
            this.picNpcPreview.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.picNpcPreview.Location = new System.Drawing.Point(240, 51);
            this.picNpcPreview.Name = "picNpcPreview";
            this.picNpcPreview.Size = new System.Drawing.Size(480, 459);
            this.picNpcPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picNpcPreview.TabIndex = 3;
            this.picNpcPreview.TabStop = false;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.HelpVisible = false;
            this.propertyGrid1.Location = new System.Drawing.Point(726, 51);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(234, 459);
            this.propertyGrid1.TabIndex = 4;
            this.propertyGrid1.ToolbarVisible = false;
            // 
            // NpcManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 523);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.picNpcPreview);
            this.Controls.Add(this.lblNpcCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstNpcList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "NpcManager";
            this.Text = "NpcManager";
            this.Load += new System.EventHandler(this.NpcManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picNpcPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstNpcList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNpcCount;
        private System.Windows.Forms.PictureBox picNpcPreview;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
    }
}