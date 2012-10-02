namespace SPH_2D_Simulator
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btPP = new System.Windows.Forms.Button();
            this.btPrep = new System.Windows.Forms.Button();
            this.lblPrepUpdate = new System.Windows.Forms.Label();
            this.lblTimeInp = new System.Windows.Forms.Label();
            this.tbTimeInp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbGravity = new System.Windows.Forms.CheckBox();
            this.tbSRadius = new System.Windows.Forms.TextBox();
            this.tbSpringK = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblSimReady = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btConfigure = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbAngle = new System.Windows.Forms.TextBox();
            this.tbThickness = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbParticles = new System.Windows.Forms.ComboBox();
            this.tbParticlePressure = new System.Windows.Forms.TextBox();
            this.btCSV = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbParticleDensity = new System.Windows.Forms.TextBox();
            this.tbParticleVelocity = new System.Windows.Forms.TextBox();
            this.lblRuntime = new System.Windows.Forms.Label();
            this.tbParticleSep = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.gbSimSize = new System.Windows.Forms.GroupBox();
            this.rbt16x16 = new System.Windows.Forms.RadioButton();
            this.rbt32x32 = new System.Windows.Forms.RadioButton();
            this.gbMovingBoundary = new System.Windows.Forms.GroupBox();
            this.rbContMove = new System.Windows.Forms.RadioButton();
            this.rbPauseMove = new System.Windows.Forms.RadioButton();
            this.rbNoMove = new System.Windows.Forms.RadioButton();
            this.simDisplay1 = new SPH_2D_Simulator.SimDisplay();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbSimSize.SuspendLayout();
            this.gbMovingBoundary.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btPP
            // 
            this.btPP.Location = new System.Drawing.Point(12, 485);
            this.btPP.Name = "btPP";
            this.btPP.Size = new System.Drawing.Size(110, 36);
            this.btPP.TabIndex = 2;
            this.btPP.Text = "Play";
            this.btPP.UseVisualStyleBackColor = true;
            this.btPP.Click += new System.EventHandler(this.btPP_Click);
            // 
            // btPrep
            // 
            this.btPrep.Location = new System.Drawing.Point(12, 407);
            this.btPrep.Name = "btPrep";
            this.btPrep.Size = new System.Drawing.Size(110, 36);
            this.btPrep.TabIndex = 6;
            this.btPrep.Text = "Prepare Simulation";
            this.btPrep.UseVisualStyleBackColor = true;
            this.btPrep.Click += new System.EventHandler(this.btPrep_Click);
            // 
            // lblPrepUpdate
            // 
            this.lblPrepUpdate.AutoSize = true;
            this.lblPrepUpdate.Location = new System.Drawing.Point(131, 407);
            this.lblPrepUpdate.Name = "lblPrepUpdate";
            this.lblPrepUpdate.Size = new System.Drawing.Size(120, 13);
            this.lblPrepUpdate.TabIndex = 9;
            this.lblPrepUpdate.Text = "Performing Calculations:";
            // 
            // lblTimeInp
            // 
            this.lblTimeInp.AutoSize = true;
            this.lblTimeInp.Location = new System.Drawing.Point(22, 312);
            this.lblTimeInp.Name = "lblTimeInp";
            this.lblTimeInp.Size = new System.Drawing.Size(84, 13);
            this.lblTimeInp.TabIndex = 8;
            this.lblTimeInp.Text = "Simulation Time:";
            // 
            // tbTimeInp
            // 
            this.tbTimeInp.Location = new System.Drawing.Point(133, 309);
            this.tbTimeInp.Name = "tbTimeInp";
            this.tbTimeInp.Size = new System.Drawing.Size(81, 20);
            this.tbTimeInp.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 338);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Smoothing Radius:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 364);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Spring Constant:";
            // 
            // cbGravity
            // 
            this.cbGravity.AutoSize = true;
            this.cbGravity.Location = new System.Drawing.Point(46, 207);
            this.cbGravity.Name = "cbGravity";
            this.cbGravity.Size = new System.Drawing.Size(59, 17);
            this.cbGravity.TabIndex = 12;
            this.cbGravity.Text = "Gravity";
            this.cbGravity.UseVisualStyleBackColor = true;
            // 
            // tbSRadius
            // 
            this.tbSRadius.Location = new System.Drawing.Point(133, 335);
            this.tbSRadius.Name = "tbSRadius";
            this.tbSRadius.Size = new System.Drawing.Size(81, 20);
            this.tbSRadius.TabIndex = 13;
            // 
            // tbSpringK
            // 
            this.tbSpringK.Location = new System.Drawing.Point(133, 361);
            this.tbSpringK.Name = "tbSpringK";
            this.tbSpringK.Size = new System.Drawing.Size(81, 20);
            this.tbSpringK.TabIndex = 14;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(847, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // lblSimReady
            // 
            this.lblSimReady.AutoSize = true;
            this.lblSimReady.Location = new System.Drawing.Point(13, 455);
            this.lblSimReady.Name = "lblSimReady";
            this.lblSimReady.Size = new System.Drawing.Size(109, 13);
            this.lblSimReady.TabIndex = 18;
            this.lblSimReady.Text = "Simulation Not Ready";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox1.Location = new System.Drawing.Point(122, 246);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // btConfigure
            // 
            this.btConfigure.Location = new System.Drawing.Point(25, 242);
            this.btConfigure.Name = "btConfigure";
            this.btConfigure.Size = new System.Drawing.Size(91, 40);
            this.btConfigure.TabIndex = 20;
            this.btConfigure.Text = "&Configure Particles";
            this.btConfigure.UseVisualStyleBackColor = true;
            this.btConfigure.Click += new System.EventHandler(this.btConfigure_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Angle";
            // 
            // tbAngle
            // 
            this.tbAngle.Location = new System.Drawing.Point(152, 84);
            this.tbAngle.Name = "tbAngle";
            this.tbAngle.Size = new System.Drawing.Size(62, 20);
            this.tbAngle.TabIndex = 23;
            this.tbAngle.Text = "0";
            // 
            // tbThickness
            // 
            this.tbThickness.Location = new System.Drawing.Point(152, 60);
            this.tbThickness.Name = "tbThickness";
            this.tbThickness.Size = new System.Drawing.Size(62, 20);
            this.tbThickness.TabIndex = 25;
            this.tbThickness.Text = "3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Thickness";
            // 
            // cbParticles
            // 
            this.cbParticles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbParticles.FormattingEnabled = true;
            this.cbParticles.Location = new System.Drawing.Point(12, 556);
            this.cbParticles.Name = "cbParticles";
            this.cbParticles.Size = new System.Drawing.Size(231, 21);
            this.cbParticles.TabIndex = 27;
            this.cbParticles.SelectedIndexChanged += new System.EventHandler(this.cbParticles_SelectedIndexChanged);
            // 
            // tbParticlePressure
            // 
            this.tbParticlePressure.Location = new System.Drawing.Point(101, 587);
            this.tbParticlePressure.Name = "tbParticlePressure";
            this.tbParticlePressure.Size = new System.Drawing.Size(142, 20);
            this.tbParticlePressure.TabIndex = 28;
            // 
            // btCSV
            // 
            this.btCSV.Location = new System.Drawing.Point(12, 678);
            this.btCSV.Name = "btCSV";
            this.btCSV.Size = new System.Drawing.Size(86, 42);
            this.btCSV.TabIndex = 29;
            this.btCSV.Text = "Create CSV";
            this.btCSV.UseVisualStyleBackColor = true;
            this.btCSV.Click += new System.EventHandler(this.btCSV_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 590);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Particle Pressure:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 540);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Select A Particle:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 616);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Particle Density:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 638);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Particle Velocity:";
            // 
            // tbParticleDensity
            // 
            this.tbParticleDensity.Location = new System.Drawing.Point(101, 613);
            this.tbParticleDensity.Name = "tbParticleDensity";
            this.tbParticleDensity.Size = new System.Drawing.Size(142, 20);
            this.tbParticleDensity.TabIndex = 34;
            // 
            // tbParticleVelocity
            // 
            this.tbParticleVelocity.Location = new System.Drawing.Point(101, 639);
            this.tbParticleVelocity.Name = "tbParticleVelocity";
            this.tbParticleVelocity.Size = new System.Drawing.Size(142, 20);
            this.tbParticleVelocity.TabIndex = 35;
            // 
            // lblRuntime
            // 
            this.lblRuntime.AutoSize = true;
            this.lblRuntime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRuntime.Location = new System.Drawing.Point(280, 30);
            this.lblRuntime.Name = "lblRuntime";
            this.lblRuntime.Size = new System.Drawing.Size(144, 20);
            this.lblRuntime.TabIndex = 36;
            this.lblRuntime.Text = "Elapsed Time (s): 0";
            // 
            // tbParticleSep
            // 
            this.tbParticleSep.Location = new System.Drawing.Point(152, 34);
            this.tbParticleSep.Name = "tbParticleSep";
            this.tbParticleSep.Size = new System.Drawing.Size(62, 20);
            this.tbParticleSep.TabIndex = 37;
            this.tbParticleSep.Text = "8";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(40, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 13);
            this.label9.TabIndex = 38;
            this.label9.Text = "Particle Separation";
            // 
            // gbSimSize
            // 
            this.gbSimSize.Controls.Add(this.rbt16x16);
            this.gbSimSize.Controls.Add(this.rbt32x32);
            this.gbSimSize.Location = new System.Drawing.Point(25, 127);
            this.gbSimSize.Name = "gbSimSize";
            this.gbSimSize.Size = new System.Drawing.Size(111, 66);
            this.gbSimSize.TabIndex = 39;
            this.gbSimSize.TabStop = false;
            this.gbSimSize.Text = "Size of Initial State";
            // 
            // rbt16x16
            // 
            this.rbt16x16.AutoSize = true;
            this.rbt16x16.Checked = true;
            this.rbt16x16.Location = new System.Drawing.Point(21, 19);
            this.rbt16x16.Name = "rbt16x16";
            this.rbt16x16.Size = new System.Drawing.Size(60, 17);
            this.rbt16x16.TabIndex = 1;
            this.rbt16x16.TabStop = true;
            this.rbt16x16.Text = "16 x 16";
            this.rbt16x16.UseVisualStyleBackColor = true;
            // 
            // rbt32x32
            // 
            this.rbt32x32.AutoSize = true;
            this.rbt32x32.Location = new System.Drawing.Point(21, 42);
            this.rbt32x32.Name = "rbt32x32";
            this.rbt32x32.Size = new System.Drawing.Size(60, 17);
            this.rbt32x32.TabIndex = 0;
            this.rbt32x32.Text = "32 x 32";
            this.rbt32x32.UseVisualStyleBackColor = true;
            // 
            // gbMovingBoundary
            // 
            this.gbMovingBoundary.Controls.Add(this.rbContMove);
            this.gbMovingBoundary.Controls.Add(this.rbPauseMove);
            this.gbMovingBoundary.Controls.Add(this.rbNoMove);
            this.gbMovingBoundary.Location = new System.Drawing.Point(152, 127);
            this.gbMovingBoundary.Name = "gbMovingBoundary";
            this.gbMovingBoundary.Size = new System.Drawing.Size(114, 97);
            this.gbMovingBoundary.TabIndex = 40;
            this.gbMovingBoundary.TabStop = false;
            this.gbMovingBoundary.Text = "Moving Boundary";
            // 
            // rbContMove
            // 
            this.rbContMove.AutoSize = true;
            this.rbContMove.Location = new System.Drawing.Point(14, 70);
            this.rbContMove.Name = "rbContMove";
            this.rbContMove.Size = new System.Drawing.Size(78, 17);
            this.rbContMove.TabIndex = 2;
            this.rbContMove.Text = "Continuous";
            this.rbContMove.UseVisualStyleBackColor = true;
            // 
            // rbPauseMove
            // 
            this.rbPauseMove.AutoSize = true;
            this.rbPauseMove.Location = new System.Drawing.Point(14, 47);
            this.rbPauseMove.Name = "rbPauseMove";
            this.rbPauseMove.Size = new System.Drawing.Size(85, 17);
            this.rbPauseMove.TabIndex = 1;
            this.rbPauseMove.Text = "With Pauses";
            this.rbPauseMove.UseVisualStyleBackColor = true;
            // 
            // rbNoMove
            // 
            this.rbNoMove.AutoSize = true;
            this.rbNoMove.Checked = true;
            this.rbNoMove.Location = new System.Drawing.Point(14, 24);
            this.rbNoMove.Name = "rbNoMove";
            this.rbNoMove.Size = new System.Drawing.Size(51, 17);
            this.rbNoMove.TabIndex = 0;
            this.rbNoMove.TabStop = true;
            this.rbNoMove.Text = "None";
            this.rbNoMove.UseVisualStyleBackColor = true;
            // 
            // simDisplay1
            // 
            this.simDisplay1.Location = new System.Drawing.Point(280, 58);
            this.simDisplay1.Name = "simDisplay1";
            this.simDisplay1.Size = new System.Drawing.Size(522, 257);
            this.simDisplay1.TabIndex = 5;
            this.simDisplay1.Text = "simDisplay1";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(847, 723);
            this.Controls.Add(this.gbMovingBoundary);
            this.Controls.Add(this.gbSimSize);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbParticleSep);
            this.Controls.Add(this.lblRuntime);
            this.Controls.Add(this.tbParticleVelocity);
            this.Controls.Add(this.tbParticleDensity);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btCSV);
            this.Controls.Add(this.tbParticlePressure);
            this.Controls.Add(this.cbParticles);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbThickness);
            this.Controls.Add(this.tbAngle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btConfigure);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblSimReady);
            this.Controls.Add(this.tbSpringK);
            this.Controls.Add(this.tbSRadius);
            this.Controls.Add(this.cbGravity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTimeInp);
            this.Controls.Add(this.tbTimeInp);
            this.Controls.Add(this.lblPrepUpdate);
            this.Controls.Add(this.btPrep);
            this.Controls.Add(this.simDisplay1);
            this.Controls.Add(this.btPP);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "SPH Sim";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbSimSize.ResumeLayout(false);
            this.gbSimSize.PerformLayout();
            this.gbMovingBoundary.ResumeLayout(false);
            this.gbMovingBoundary.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btPP;
        private SimDisplay simDisplay1;
        private System.Windows.Forms.Button btPrep;
        private System.Windows.Forms.Label lblPrepUpdate;
        private System.Windows.Forms.Label lblTimeInp;
        private System.Windows.Forms.TextBox tbTimeInp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbGravity;
        private System.Windows.Forms.TextBox tbSRadius;
        private System.Windows.Forms.TextBox tbSpringK;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblSimReady;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btConfigure;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbAngle;
        private System.Windows.Forms.TextBox tbThickness;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbParticles;
        private System.Windows.Forms.TextBox tbParticlePressure;
        private System.Windows.Forms.Button btCSV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbParticleDensity;
        private System.Windows.Forms.TextBox tbParticleVelocity;
        private System.Windows.Forms.Label lblRuntime;
        private System.Windows.Forms.TextBox tbParticleSep;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox gbSimSize;
        private System.Windows.Forms.RadioButton rbt16x16;
        private System.Windows.Forms.RadioButton rbt32x32;
        private System.Windows.Forms.GroupBox gbMovingBoundary;
        private System.Windows.Forms.RadioButton rbContMove;
        private System.Windows.Forms.RadioButton rbPauseMove;
        private System.Windows.Forms.RadioButton rbNoMove;
    }
}

