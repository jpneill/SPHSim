using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPH_2D_Simulator
{
    class Spring_Array
    {
         //parameters
        private List<Spring> springlst;
        public List<Spring> Springlst
        {
            get { return springlst; }
            set { springlst = value; }
        }

        private bool[,] springarray;
        public bool[,] Springarray
        {
            get { return springarray; }
            set { springarray = value; }
        }
        
        //constructors
        public Spring_Array(int num_particles)
        {
            this.springarray = new bool[num_particles, num_particles];
            this.springlst = new List<Spring>();
        }
    }
}
