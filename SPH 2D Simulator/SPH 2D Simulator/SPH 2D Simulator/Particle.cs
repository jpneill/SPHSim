using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Xna.Framework;

namespace SPH_2D_Simulator
{
    [Serializable]

    class Particle : Physics_Entity, ISerializable
    {
        //parameters and accessors
        private float density;
        public float Density
        {
            get { return density; }
            set { density = value; }
        }

        private float neardensity;
        public float Neardensity
        {
            get { return neardensity; }
            set { neardensity = value; }
        }

        private float vsigma;
        public float Vsigma
        {
            get { return vsigma; }
            set { vsigma = value; }
        }

        private float vbeta;
        public float Vbeta
        {
            get { return vbeta; }
            set { vbeta = value; }
        }

        private List<N_Particle> neighbourlist;
        internal List<N_Particle> Neighbourlist
        {
            get { return neighbourlist; }
            set { neighbourlist = value; }
        }

        private int mass;
        public int Mass
        {
            get { return mass; }
            set { mass = value; }
        }

        private float pressure;
        public float Pressure
        {
            get { return pressure; }
            set { pressure = value; }
        }

        //constructors
        public Particle()
        {
            this.neighbourlist = new List<N_Particle>();
            this.Force = new Vector2();
            this.Oldposition = new Vector2();
            this.Position = new Vector2();
            this.Velocity = new Vector2();
        }

        public Particle(SerializationInfo sinfo, StreamingContext scon)
        {
            Position = (Vector2)sinfo.GetValue("Position", typeof(Vector2));
            Oldposition = (Vector2)sinfo.GetValue("Oldposition", typeof(Vector2));
            Velocity = (Vector2)sinfo.GetValue("Velocity", typeof(Vector2));
            Force = (Vector2)sinfo.GetValue("Force", typeof(Vector2));
            neighbourlist = (List<N_Particle>)sinfo.GetValue("neighbourlist", typeof(List<N_Particle>));
            density = sinfo.GetSingle("density");
            neardensity = sinfo.GetSingle("neardensity");
            vbeta = sinfo.GetSingle("vbeta");
            vsigma = sinfo.GetSingle("vsigma");
            mass = sinfo.GetInt32("mass");
            Ismovingboundary = sinfo.GetBoolean("Ismovingboundary");
            Isstationaryboundary = sinfo.GetBoolean("Isstationaryboundary");
            pressure = sinfo.GetSingle("pressure");
        }

        public void GetObjectData(SerializationInfo sinfo, StreamingContext scon)
        {
            sinfo.AddValue("Position", Position);
            sinfo.AddValue("Oldposition", Oldposition);
            sinfo.AddValue("Force", Force);
            sinfo.AddValue("Velocity", Velocity);
            sinfo.AddValue("neighbourlist", neighbourlist);
            sinfo.AddValue("density", density);
            sinfo.AddValue("neardensity", neardensity);
            sinfo.AddValue("vbeta", vbeta);
            sinfo.AddValue("vsigma", vsigma);
            sinfo.AddValue("mass", mass);
            sinfo.AddValue("Isstationaryboundary", Isstationaryboundary);
            sinfo.AddValue("Ismovingboundary", Ismovingboundary);
            sinfo.AddValue("pressure", pressure);
        }

        public Particle Copy()
        {
            return new Particle
            {
                Position = this.Position,
                Density = this.Density,
                Force = this.Force,
                Ismovingboundary = this.Ismovingboundary,
                Isstationaryboundary = this.Isstationaryboundary,
                Neardensity = this.Neardensity,
                Neighbourlist = this.Neighbourlist,
                Oldposition = this.Oldposition,
                Vbeta = this.Vbeta,
                Velocity = this.Velocity,
                Vsigma = this.Vsigma,
                Mass = this.Mass,
                Pressure = this.Pressure
            };
        }


    }
}
