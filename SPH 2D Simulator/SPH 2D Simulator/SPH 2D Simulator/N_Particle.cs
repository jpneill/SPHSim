using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace SPH_2D_Simulator
{
    [Serializable]
    class N_Particle : ISerializable
    {
        private float smoothingkernel;
        public float Smoothingkernel
        {
            get { return smoothingkernel; }
            set { smoothingkernel = value; }
        }

        private float smoothingkernelsquared;
        public float Smoothingkernelsquared
        {
            get { return smoothingkernelsquared; }
            set { smoothingkernelsquared = value; }
        }

        private float distance;
        public float Distance
        {
            get { return distance; }
            set { distance = value; }
        }

        private int particleindex;
        public int Particleindex
        {
            get { return particleindex; }
            set { particleindex = value; }
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

        //constructors
        public N_Particle() { }

        public N_Particle(SerializationInfo sinfo, StreamingContext scon)
        {
            particleindex = sinfo.GetInt32("particleindex");
            ismovingboundary = sinfo.GetBoolean("ismovingboundary");
            isstationaryboundary = sinfo.GetBoolean("isstationaryboundary");
            distance = sinfo.GetSingle("distance");
            smoothingkernel = sinfo.GetSingle("smoothingkernel");
            smoothingkernelsquared = sinfo.GetSingle("smoothingkernelsquared");
        }

        public void GetObjectData(SerializationInfo sinfo, StreamingContext scon)
        {
            sinfo.AddValue("particleindex", particleindex);
            sinfo.AddValue("ismovingboundary", ismovingboundary);
            sinfo.AddValue("isstationaryboundary", isstationaryboundary);
            sinfo.AddValue("distance", distance);
            sinfo.AddValue("smoothingkernel", smoothingkernel);
            sinfo.AddValue("smoothingkernelsquared", smoothingkernelsquared);
        }
    }
}
