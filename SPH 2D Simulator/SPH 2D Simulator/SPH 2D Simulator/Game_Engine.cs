using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SPH_2D_Simulator
{
    class Game_Engine
    {
        #region parameters
        //Parameters/attributes and accessors
        private Wall_Collision collisionEngine;
        internal Wall_Collision CollisionEngine
        {
            get { return collisionEngine; }
            set { collisionEngine = value; }
        }

        private SPH_Engine fluidEngine;
        internal SPH_Engine FluidEngine
        {
            get { return fluidEngine; }
            set { fluidEngine = value; }
        }

        private Integration integrationEngine;
        internal Integration IntegrationEngine
        {
            get { return integrationEngine; }
            set { integrationEngine = value; }
        }

        float fluidmaxwidth;
        public float Fluidmaxwidth
        {
            get { return fluidmaxwidth; }
            set { fluidmaxwidth = value; }
        }

        float fluidmaxheight;
        public float Fluidmaxheight
        {
            get { return fluidmaxheight; }
            set { fluidmaxheight = value; }
        }

        float deltavalue;
        public float Deltavalue
        {
            get { return deltavalue; }
            set { deltavalue = value; }
        }

        private List<Particle> plst;
        internal List<Particle> Plst
        {
            get { return plst; }
            set { plst = value; }
        }

        private float box_width;
        public float Box_width
        {
            get { return box_width; }
            set { box_width = value; }
        }

        private float box_height;
        public float Box_height
        {
            get { return box_height; }
            set { box_height = value; }
        }
        #endregion

        #region constants
        //constants
        private float vsigma = 0.001f;
        public float Vsigma
        {
            get { return vsigma; }
            set { vsigma = value; }
        }

        private float vbeta = 0.001f;
        public float Vbeta
        {
            get { return vbeta; }
            set { vbeta = value; }
        }

        private float dt_cap = 0.01f;
        public float Dt_cap
        {
            get { return dt_cap; }
            set { dt_cap = value; }
        }

        private float window_bottom = 1.0f;
        public float Window_bottom
        {
            get { return window_bottom; }
            set { window_bottom = value; }
        }

        private float smoothing_radius = 10.0f;
        public float Smoothing_radius
        {
            get { return smoothing_radius; }
            set { smoothing_radius = value; }
        }

        private float stiffness_k = 0.02f;
        public float Stiffness_k
        {
            get { return stiffness_k; }
            set { stiffness_k = value; }
        }

        private float near_stiffness_k = 0.002f;
        public float Near_stiffness_k
        {
            get { return near_stiffness_k; }
            set { near_stiffness_k = value; }
        }

        private float rest_density = 10.0f;
        public float Rest_density
        {
            get { return rest_density; }
            set { rest_density = value; }
        }

        private float k = 0.2f;
        public float K
        {
            get { return k; }
            set { k = value; }
        }

        private float yield_ratio = 0.1f;
        public float Yield_ratio
        {
            get { return yield_ratio; }
            set { yield_ratio = value; }
        }

        private float plasticity = 0.5f;
        public float Plasticity
        {
            get { return plasticity; }
            set { plasticity = value; }
        }

        private Vector2 gravity = new Vector2(0.0f, -0.8f);
        public Vector2 Gravity
        {
            get { return gravity; }
            set { gravity = value; }
        }

        private float wall_k = 0.08f;//0.5
        public float Wall_k
        {
            get { return wall_k; }
            set { wall_k = value; }
        }

        private float adjustment;
        public float Adjustment
        {
            get { return adjustment; }
            set { adjustment = value; }
        }

        #endregion

        #region constructors
        //Constructors
        public Game_Engine()
        {
            this.plst = new List<Particle>();
            this.collisionEngine = new Wall_Collision();
            this.integrationEngine = new Integration();
        }
        #endregion

        #region methods
        //Methods
        //public
        public void Initialise(float fluid_width, float fluid_height, Vector3[,] Config)
        {
            adjustment = 0.2f;
            integrationEngine = new Integration();
            fluidmaxwidth = fluid_width;
            fluidmaxheight = fluid_height;
            InitialiseParticles(Config);
            this.fluidEngine = new SPH_Engine(plst.Count);
            fluidEngine.CreateSpringArray();
        }

        public void InitialiseParticles(Vector3[,] config)
        {
            float i, j;            
            //initialise fluid particles from array
            foreach (var v in config)
            {
                Particle p = new Particle();
                Vector2 temp = new Vector2(v.X, v.Y);
                p.Position = temp;
                p.Oldposition = temp;
                if (v.Z == 1)                
                    p.Mass = 1;

                plst.Add(p);
            }

            //Create four walls for the box
            box_width = config[config.GetLength(0) - 1, config.GetLength(1) - 1].X + 20;
            box_height = config[config.GetLength(0) - 1, 0].Y + 15;
            //initialise base particles
            for (i = 0; i <= /*256*/box_width; i += 3)
                for (j = 0; j <= 9; j += 3)
                {
                    Particle bp = new Particle();
                    Vector2 temp = new Vector2(i, j);
                    bp.Position = temp;
                    bp.Oldposition = temp;
                    bp.Isstationaryboundary = true;
                    plst.Add(bp);
                }
            //initialise left wall particles
            for (i = 0; i <= 9; i += 3)
                for (j = 12; j <= /*253*/box_height; j += 3)
                {
                    Particle mbp = new Particle();
                    Vector2 temp2 = new Vector2(i, j);
                    mbp.Position = temp2;
                    mbp.Oldposition = temp2;
                    mbp.Ismovingboundary = true;
                    plst.Add(mbp);
                }
            //initalise right wall particles
            for (i = box_width - 10; i <= box_width; i += 3)
                for (j = 12; j <= box_height; j += 3)
                {
                    Particle bp = new Particle();
                    Vector2 temp = new Vector2(i, j);
                    bp.Position = temp;
                    bp.Oldposition = temp;
                    bp.Isstationaryboundary = true;
                    plst.Add(bp);
                }
            //initialise top of box            
            for (i = 0; i <= box_width; i += 3)
                for (j = box_height + 2; j <= box_height + 10; j += 3)
                {
                    Particle bp = new Particle();
                    Vector2 temp = new Vector2(i, j);
                    bp.Position = temp;
                    bp.Oldposition = temp;
                    bp.Isstationaryboundary = true;
                    plst.Add(bp);
                }

            foreach (Particle p in plst)
            {
                p.Vsigma = vsigma;
                p.Vbeta = vbeta;
            }
        }

        public void CalculateBoundaryInteraction(float dt)
        {
            fluidEngine.ApplyBoundaryForces(plst, dt, smoothing_radius);
        }

        public void ResetViscoelasticity()
        {
            fluidEngine.ResetSprings();
        }

        public void InitialisePlasticity()
        {
            fluidEngine.InitialisePlasticity(plst, Smoothing_radius, k);
        }


        public void CalculateDensity(float dt)
        {
            fluidEngine.CalculateDensity(plst, smoothing_radius);
        }

        public void CalculatePressureForce(float dt)
        {
            fluidEngine.CalculatePressure(plst, stiffness_k, near_stiffness_k, rest_density, dt, smoothing_radius);
        }

        public void UpdateParticleVelocityPosition(float dt, int ismoving)
        {
            foreach (var p in plst)
                if (p.Isstationaryboundary == false && p.Ismovingboundary == false)
                {
                    integrationEngine.updatevel(p, dt);
                    p.Force = Gravity;
                }

            CalculateViscosity(dt);

            foreach (var p in plst)
            {
                if (p.Isstationaryboundary == false && p.Ismovingboundary == false)                
                    integrationEngine.updatepos(p, dt);
                    
                
                if (p.Ismovingboundary == true && ismoving == 1 && p.Position.X < box_width / 2)
                    p.Position += new Vector2(0.3f, 0);
            }
        }

        public void CalculateViscosity(float dt)
        {
            fluidEngine.CalculateViscosity(plst, smoothing_radius, dt);
        }

        public void CalculateSpringsForViscoelasticity(float dt)
        {
            fluidEngine.CalculateViscoElasticity(plst, smoothing_radius, k, yield_ratio, plasticity, dt);
        }

        public void CalculatePlasticity(float dt)
        {
            fluidEngine.CalculatePlasticity(plst, dt);
        }
        #endregion
    }
}
