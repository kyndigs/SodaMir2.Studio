namespace SodaMir2.Studio
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImageLibraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.componentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.npcManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImageLibDialog = new System.Windows.Forms.OpenFileDialog();
            this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.vS2015DarkTheme1 = new WeifenLuo.WinFormsUI.Docking.VS2015DarkTheme();
            this.vsToolStripExtender1 = new WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender(this.components);
            this.vS2015BlueTheme1 = new WeifenLuo.WinFormsUI.Docking.VS2015BlueTheme();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.convertWilsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.componentsToolStripMenuItem,
            this.imageToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1329, 24);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openImageLibraryToolStripMenuItem,
            this.createNewToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openImageLibraryToolStripMenuItem
            // 
            this.openImageLibraryToolStripMenuItem.Name = "openImageLibraryToolStripMenuItem";
            this.openImageLibraryToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openImageLibraryToolStripMenuItem.Text = "Open";
            this.openImageLibraryToolStripMenuItem.Click += new System.EventHandler(this.openImageLibraryToolStripMenuItem_Click);
            // 
            // createNewToolStripMenuItem
            // 
            this.createNewToolStripMenuItem.Name = "createNewToolStripMenuItem";
            this.createNewToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.createNewToolStripMenuItem.Text = "Create New";
            // 
            // componentsToolStripMenuItem
            // 
            this.componentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.convertWilsToolStripMenuItem,
            this.npcManagerToolStripMenuItem});
            this.componentsToolStripMenuItem.Name = "componentsToolStripMenuItem";
            this.componentsToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.componentsToolStripMenuItem.Text = "Components";
            // 
            // npcManagerToolStripMenuItem
            // 
            this.npcManagerToolStripMenuItem.Name = "npcManagerToolStripMenuItem";
            this.npcManagerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.npcManagerToolStripMenuItem.Text = "Npc Manager";
            this.npcManagerToolStripMenuItem.Click += new System.EventHandler(this.NpcManagerToolStripMenuItem_Click);
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.exportImagesToolStripMenuItem});
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.imageToolStripMenuItem.Text = "Image";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            // 
            // exportImagesToolStripMenuItem
            // 
            this.exportImagesToolStripMenuItem.Name = "exportImagesToolStripMenuItem";
            this.exportImagesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportImagesToolStripMenuItem.Text = "Export";
            this.exportImagesToolStripMenuItem.Click += new System.EventHandler(this.ExportImagesToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.propertiesToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.CheckOnClick = true;
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.propertiesToolStripMenuItem.Text = "Properties";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.PropertiesToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.CheckOnClick = true;
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.toolsToolStripMenuItem.Text = "Tools";
            this.toolsToolStripMenuItem.Click += new System.EventHandler(this.ToolsToolStripMenuItem_Click);
            // 
            // dockPanel1
            // 
            this.dockPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.Location = new System.Drawing.Point(0, 24);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Size = new System.Drawing.Size(1329, 826);
            this.dockPanel1.TabIndex = 4;
            this.dockPanel1.ActiveDocumentChanged += new System.EventHandler(this.dockPanel1_ActiveDocumentChanged);
            // 
            // vsToolStripExtender1
            // 
            this.vsToolStripExtender1.DefaultRenderer = null;
            // 
            // convertWilsToolStripMenuItem
            // 
            this.convertWilsToolStripMenuItem.Name = "convertWilsToolStripMenuItem";
            this.convertWilsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.convertWilsToolStripMenuItem.Text = "Convert Wils";
            this.convertWilsToolStripMenuItem.Click += new System.EventHandler(this.ConvertWilsToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1329, 850);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.mainMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "SodaMir2.Studio";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openImageLibraryToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openImageLibDialog;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
        private WeifenLuo.WinFormsUI.Docking.VS2015DarkTheme vS2015DarkTheme1;
        private WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender vsToolStripExtender1;
        private WeifenLuo.WinFormsUI.Docking.VS2015BlueTheme vS2015BlueTheme1;
        private System.Windows.Forms.ToolStripMenuItem createNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem componentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem npcManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertWilsToolStripMenuItem;
    }
}

