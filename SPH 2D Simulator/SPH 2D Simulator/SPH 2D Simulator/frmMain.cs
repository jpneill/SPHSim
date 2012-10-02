using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Threading;


namespace SPH_2D_Simulator
{
    public partial class frmMain : Form
    {
        SpriteBatch spritebatch;
        Camera camera;
        SpherePrimitive sphere;
        CubePrimitive cube;
        Bitmap positions32, positions16;

        List<Particle> particles;

        private List<List<Particle>> plstArray;
        private Vector3[,] BmpConfig;

        Game_Engine CoreEngine;
        private int play_pause;
        private int a, ready, move_stop;
        private int position_in_array, green_particle;
        private float elapsed_time;

        public GraphicsDevice GraphicsDevice
        {
            get { return simDisplay1.GraphicsDevice; }
        }

        public frmMain()
        {
            InitializeComponent();

            timer1.Interval = 20;
            tbTimeInp.Text = "1";
            tbSRadius.Text = "10";
            tbSpringK.Text = "0.35";
            plstArray = new List<List<Particle>>();

            btPrep.Enabled = false;
            btPP.Enabled = false;
            btCSV.Enabled = false;
            cbParticles.Enabled = false;

            simDisplay1.OnInitialize += new EventHandler(simDisplay1_OnInitialize);
            simDisplay1.OnDraw += new EventHandler(simDisplay1_OnDraw);
        }

        #region Update Simulation Display
        void simDisplay1_OnDraw(object sender, EventArgs e)
        {
            GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.CornflowerBlue);
            spritebatch.Begin();
            if (ready == 1)
            {
                Microsoft.Xna.Framework.Matrix transpos;
                green_particle = 0;
                foreach (var p in plstArray.ElementAt(a))
                {
                    transpos = Microsoft.Xna.Framework.Matrix.CreateTranslation(new Vector3(p.Position.X, p.Position.Y, 0));
                    if (p.Ismovingboundary == false && p.Isstationaryboundary == false)
                    {
                        if (green_particle == position_in_array)
                        {
                            sphere.Draw(transpos, camera.View, camera.Projection, Microsoft.Xna.Framework.Color.Green);
                            tbParticleDensity.Text = p.Density.ToString("F5");
                            tbParticlePressure.Text = p.Pressure.ToString("F5");
                            tbParticleVelocity.Text = string.Format("({0:F3},{1:F3})", p.Velocity.X, p.Velocity.Y);
                        }
                        else
                            switch (p.Mass)
                            {
                                case 0:
                                    sphere.Draw(transpos, camera.View, camera.Projection, Microsoft.Xna.Framework.Color.White);
                                    break;

                                case 1:
                                    sphere.Draw(transpos, camera.View, camera.Projection, Microsoft.Xna.Framework.Color.Black);
                                    break;
                            }
                    }
                    if (p.Isstationaryboundary || p.Ismovingboundary)
                        cube.Draw(transpos, camera.View, camera.Projection, Microsoft.Xna.Framework.Color.Red);
                    green_particle++;
                }
                elapsed_time = a * 40;
                a++;
                if (a >= plstArray.Count)
                    a = 0;
                lblRuntime.Text = string.Format("Elapsed Simulation Time: {0}", elapsed_time / 1000);                
            }
            spritebatch.End();
        }

        void simDisplay1_OnInitialize(object sender, EventArgs e)
        {
            spritebatch = new SpriteBatch(GraphicsDevice);
            camera = new Camera(GraphicsDevice);
            sphere = new SpherePrimitive(GraphicsDevice, 2, 16);
            cube = new CubePrimitive(GraphicsDevice, 2);
        }


        //force form to draw on every timer tick
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Refresh();
        }
        #endregion

        #region Form Controls
        private void btConfigure_Click(object sender, EventArgs e)
        {
            int y2, y1, i, j;
            float x, y;
            var checkedbutton = gbSimSize.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            positions32 = new Bitmap(32, 32);
            positions16 = new Bitmap(16, 16);


            switch (checkedbutton.Name)
            {
                case "rbt16x16":
                    pictureBox1.Image = positions16;
                    //calculate end point of line from angle
                    y2 = (int)(8 * Math.Tan((Math.PI / 180) * Convert.ToInt32(tbAngle.Text)) + 8);
                    y1 = (int)(8 - 8 * Math.Tan((Math.PI / 180) * Convert.ToInt32(tbAngle.Text)));

                    //draw image
                    using (Graphics g = Graphics.FromImage(positions16))
                    {
                        g.Clear(System.Drawing.Color.White);
                        g.DrawLine(new Pen(System.Drawing.Color.Black, Convert.ToInt32(tbThickness.Text)), new System.Drawing.Point(-5, pictureBox1.Image.Height - y1), new System.Drawing.Point(16, pictureBox1.Image.Height - y2));

                        pictureBox1.Invalidate();
                    }

                    //Create Array
                    BmpConfig = new Vector3[16, 16];
                    for (i = 0; i < 16; i++)
                        for (j = 0; j < 16; j++)
                        {
                            x = i * Convert.ToSingle(tbParticleSep.Text) + 20;
                            y = (16 - j) * Convert.ToSingle(tbParticleSep.Text) + 15;
                            BmpConfig[i, j] = new Vector3(x, y, 0);
                            System.Drawing.Color colour = positions16.GetPixel(i, j);
                            if (colour.ToArgb() == System.Drawing.Color.Black.ToArgb())
                                BmpConfig[i, j] = new Vector3(x, y, 1);
                        }
                    break;

                case "rbt32x32":
                    pictureBox1.Image = positions32;
                    //calculate end point of line from angle
                    y2 = (int)(16 * Math.Tan((Math.PI / 180) * Convert.ToInt32(tbAngle.Text)) + 16);
                    y1 = (int)(16 - 16 * Math.Tan((Math.PI / 180) * Convert.ToInt32(tbAngle.Text)));

                    //draw image
                    using (Graphics g = Graphics.FromImage(positions32))
                    {
                        g.Clear(System.Drawing.Color.White);
                        g.DrawLine(new Pen(System.Drawing.Color.Black, Convert.ToInt32(tbThickness.Text)), new System.Drawing.Point(-5, pictureBox1.Image.Height - y1), new System.Drawing.Point(32, pictureBox1.Image.Height - y2));
                        //g.FillRectangle(new SolidBrush(System.Drawing.Color.Black), 0, pictureBox1.Image.Height / 2, pictureBox1.Image.Width, pictureBox1.Image.Height / 2);

                        pictureBox1.Invalidate();
                    }
                    //change the 8s to 32 again
                    //Create Array
                    BmpConfig = new Vector3[32, 32];
                    for (i = 0; i < 32; i++)
                        for (j = 0; j < 32; j++)
                        {
                            x = i * Convert.ToSingle(tbParticleSep.Text) + 20;
                            y = (32 - j) * Convert.ToSingle(tbParticleSep.Text) + 15;
                            BmpConfig[i, j] = new Vector3(x, y, 0);
                            System.Drawing.Color colour = positions32.GetPixel(i, j);
                            if (colour.ToArgb() == System.Drawing.Color.Black.ToArgb())
                                BmpConfig[i, j] = new Vector3(x, y, 1);
                        }
                    break;
            }

            btPrep.Enabled = true;
        }

        private void btPP_Click(object sender, EventArgs e)
        {
            switch (play_pause)
            {
                case 0:
                    play_pause = 1;
                    btPP.Text = "Pause";
                    btPrep.Enabled = false;
                    btConfigure.Enabled = false;
                    btCSV.Enabled = false;
                    tbTimeInp.Enabled = false;
                    tbSpringK.Enabled = false;
                    tbSRadius.Enabled = false;
                    cbParticles.Enabled = false;
                    timer1.Start();
                    break;

                case 1:
                    play_pause = 0;
                    btPP.Text = "Play";
                    btPrep.Enabled = true;
                    btConfigure.Enabled = true;
                    btCSV.Enabled = true;
                    tbTimeInp.Enabled = true;
                    tbSpringK.Enabled = true;
                    tbSRadius.Enabled = true;
                    cbParticles.Enabled = true;
                    timer1.Stop();
                    particles = new List<Particle>(plstArray.ElementAt(a).Select(c => c.Copy()));
                    particles.RemoveAll(p => p.Isstationaryboundary);
                    particles.RemoveAll(p => p.Ismovingboundary);
                    cbParticles.BeginUpdate();
                    int m = 0;
                    foreach (var p in particles)
                    {
                        if (p.Ismovingboundary || p.Isstationaryboundary)
                            continue;
                        cbParticles.Items.Add("Particle " + m.ToString());
                        m++;
                    }
                    cbParticles.EndUpdate();
                    break;
            }
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            simDisplay1.Location = new System.Drawing.Point(287, simDisplay1.Location.Y);
            simDisplay1.Width = this.Width - simDisplay1.Location.X - 30;
            simDisplay1.Height = (int)(0.9 * this.Height);
            this.Refresh();
        }


        private void btPrep_Click(object sender, EventArgs e)
        {
            int i;
            double tmp, tmp2;
            float ArraySize = Convert.ToSingle(tbTimeInp.Text);
            var checkedbutton = gbMovingBoundary.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            a = 0;
            btPP.Enabled = false;
            btConfigure.Enabled = false;
            plstArray.Clear();
            CoreEngine = new Game_Engine();
            if (cbGravity.Checked)
                CoreEngine.Gravity = new Vector2(0, -1);
            else
                CoreEngine.Gravity = new Vector2(0, 0);
            CoreEngine.K = (float)Convert.ToDouble(tbSpringK.Text);
            CoreEngine.Smoothing_radius = (float)Convert.ToDouble(tbSRadius.Text);
            CoreEngine.Initialise(200, 200, BmpConfig);
            plstArray.Add(new List<Particle>(CoreEngine.Plst));
            simDisplay1.Refresh();

            //do all calculations for simulation here
            for (i = 1; i <= ArraySize * 25; i++)
            {
                if (i > 25)
                    switch (checkedbutton.Name)
                    {
                        //no movement of boundaries
                        case "rbNoMove":
                            break;

                        //pause for 2 seconds then move for 2 seconds
                        case "rbPauseMove":
                            if (i % 100 < 50)
                                move_stop = 0;
                            else
                                move_stop = 1;
                            break;

                        //start moving continuously after 1 second has passed
                        case "rbContMove":
                            move_stop = 1;
                            break;
                    }

                //CoreEngine.CalculateSpringsForViscoelasticity(0.01f);
                CoreEngine.InitialisePlasticity();
                CoreEngine.CalculatePlasticity(0.01f);
                CoreEngine.CalculateBoundaryInteraction(0.01f);
                CoreEngine.CalculateDensity(0.01f);
                CoreEngine.CalculatePressureForce(0.01f);
                CoreEngine.UpdateParticleVelocityPosition(0.01f, move_stop);
                List<Particle> listp = new List<Particle>(CoreEngine.Plst.Select(c => c.Copy()));
                plstArray.Add(listp);
                tmp = (ArraySize * 25);
                tmp2 = i / tmp;
                lblPrepUpdate.Text = string.Format("Performing Calculations:\n{0} particles\n({1:f}%)", listp.Count, tmp2 * 100);
                lblPrepUpdate.Refresh();
            }
            lblPrepUpdate.Text = "Calculations Complete";
            btPP.Enabled = true;
            btConfigure.Enabled = true;
            ready = 1;
            lblSimReady.Text = "Simulation Ready";
        }
        #endregion

        #region save and load
        private void Serialize(string filename)
        {
            Stream s = File.Open(filename, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(s, plstArray);
            s.Close();
        }

        private void DeSerialize(string filename)
        {
            Stream s = File.Open(filename, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            plstArray = (List<List<Particle>>)bf.Deserialize(s);
            s.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "SPH Files (*.sph)|*.sph|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ready == 1)
                {
                    ready = 0;
                    lblSimReady.Text = "Simulation Not Ready";
                    lblSimReady.Refresh();
                }
                filename = ofd.FileName;                
                backgroundWorker1.RunWorkerAsync(ofd.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "SPH Files (*.sph)|*.sph";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                filename = sfd.FileName;
                Serialize(filename);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.ReportProgress(0);
            DeSerialize(e.Argument.ToString());
            ready = 1;
            backgroundWorker1.ReportProgress(100);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
            {
                lblSimReady.Text = "Loading File";
                btPP.Enabled = false;
                btPrep.Enabled = false;
                tbSpringK.Enabled = false;
                tbSRadius.Enabled = false;
                tbTimeInp.Enabled = false;
                menuStrip1.Enabled = false;
            }
            else if (e.ProgressPercentage == 100)
            {
                lblSimReady.Text = "Load Complete";
                btPrep.Enabled = true;
                btPP.Enabled = true;
                tbTimeInp.Enabled = true;
                tbSRadius.Enabled = true;
                tbSpringK.Enabled = true;
                menuStrip1.Enabled = true;
            }
        }
        #endregion

        #region individual particle data and CSV file output
        private void cbParticles_SelectedIndexChanged(object sender, EventArgs e)
        {
            position_in_array = cbParticles.SelectedIndex;
            tbParticlePressure.Text = particles.ElementAt(position_in_array).Pressure.ToString("F5");
            tbParticleDensity.Text = particles.ElementAt(position_in_array).Density.ToString("F5");
            tbParticleVelocity.Text = string.Format("({0:F3},{1:F3})", particles.ElementAt(position_in_array).Velocity.X, particles.ElementAt(position_in_array).Velocity.Y);
        }

        private void btCSV_Click(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var p in particles)
            {
                builder.Append(p.Position.X.ToString());
                builder.Append(",");
                builder.Append(p.Position.Y.ToString());
                builder.Append(",");
                builder.Append(p.Density.ToString());
                builder.Append(",");
                builder.Append(p.Pressure.ToString());
                builder.Append("\n");
            }

            if (!Directory.Exists(@"C:\SPH CSV files"))
                Directory.CreateDirectory(@"C:\SPH CSV files");

            using (StreamWriter theWriter = new StreamWriter(@"C:\SPH CSV files\Test.csv"))
            {
                theWriter.Write(builder.ToString());
            }
        }
        #endregion
    }
}
