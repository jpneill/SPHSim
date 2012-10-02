using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Xna.Framework;

namespace SPH_2D_Simulator
{   
    class Physics_Entity
    {
         //Parameters and Accessors
        private Vector2 velocity;
        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        private Vector2 position;
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        private Vector2 force;
        public Vector2 Force
        {
            get { return force; }
            set { force = value; }
        }

        private Vector2 oldposition;
        public Vector2 Oldposition
        {
            get { return oldposition; }
            set { oldposition = value; }
        }

        private bool isstationaryboundary;
        public bool Isstationaryboundary
        {
            get { return isstationaryboundary; }
            set { isstationaryboundary = value; }
        }

        private bool ismovingboundary;
        public bool Ismovingboundary
        {
            get { return ismovingboundary; }
            set { ismovingboundary = value; }
        }

        //Constructors
        public Physics_Entity() { }

        //methods
        public void AccumulateForce(Vector2 f)
        {
            this.force += f;
        }    
    
    }
}
