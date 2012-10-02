using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SPH_2D_Simulator
{
    class SPH_Engine
    {
        #region parameters
        //parameters
        private Spring_Array SpringArray;
        internal Spring_Array SpringArray1
        {
            get { return SpringArray; }
            set { SpringArray = value; }
        }

        private int num_particles;
        public int Num_particles
        {
            get { return num_particles; }
            set { num_particles = value; }
        }

        private int dt_scalefactor = 100;

        static Random rand;
        #endregion

        #region constructors
        //constructor
        public SPH_Engine() { }

        public SPH_Engine(int n)
        {
            this.num_particles = n;
            this.SpringArray = new Spring_Array(n);
            rand = new Random();
        }
        #endregion

        #region methods
        //methods
        public void CreateSpringArray()
        {
            this.SpringArray = new Spring_Array(num_particles);
        }

        public void CalculateDensity(List<Particle> plst, float smoothing_radius)
        {
            int pindex, nindex;
            float density, near_density, distance_squared, distance, smoothing_kernel, smoothing_kernel_squared, smoothing_kernel_cubic;
            Vector2 vector_between_particle_neighbour;

            pindex = 0;
            foreach (Particle p in plst)
            {
                p.Density = 0.0f;
                p.Neardensity = 0.0f;
                p.Neighbourlist.Clear();
                density = 0.0f;
                near_density = 0.0f;

                for (nindex = pindex + 1; nindex < plst.Count; nindex++)
                {
                    vector_between_particle_neighbour.X = plst.ElementAt(nindex).Position.X - plst.ElementAt(pindex).Position.X;
                    vector_between_particle_neighbour.Y = plst.ElementAt(nindex).Position.Y - plst.ElementAt(pindex).Position.Y;
                    distance_squared = vector_between_particle_neighbour.LengthSquared();
                    distance = (float)Math.Sqrt(distance_squared);

                    if (distance_squared < smoothing_radius * smoothing_radius)
                    {
                        N_Particle nparticle = new N_Particle();
                        smoothing_kernel = 1 - distance / smoothing_radius;
                        //smoothing_kernel_squared = (smoothing_kernel * smoothing_kernel);
                        smoothing_kernel_squared = (float)(6 / (smoothing_radius * Math.PI * smoothing_radius)) * (smoothing_kernel * smoothing_kernel);
                        //smoothing_kernel_cubic = smoothing_kernel_squared * smoothing_kernel;
                        smoothing_kernel_cubic = (float)(10 / (Math.PI * smoothing_radius * smoothing_radius)) * (smoothing_kernel * smoothing_kernel * smoothing_kernel);
                        density += smoothing_kernel_squared;
                        near_density += smoothing_kernel_cubic;
                        plst.ElementAt(nindex).Density += smoothing_kernel_squared;
                        plst.ElementAt(nindex).Neardensity += smoothing_kernel_cubic;
                        nparticle.Particleindex = nindex;
                        nparticle.Smoothingkernel = smoothing_kernel;
                        nparticle.Smoothingkernelsquared = smoothing_kernel_squared;

                        nparticle.Distance = distance;
                        nparticle.Ismovingboundary = plst.ElementAt(nindex).Ismovingboundary;
                        nparticle.Isstationaryboundary = plst.ElementAt(nindex).Isstationaryboundary;
                        plst.ElementAt(pindex).Neighbourlist.Add(nparticle);
                    }
                }
                p.Density += density;
                p.Neardensity += near_density;

                pindex++;
            }
        }

        public void CalculatePressure(List<Particle> plst, float stiffness, float near_stiffness, float rest_density, float dt, float smoothing_radius)
        {
            int pindex, nindex;
            float pressure, near_pressure, smoothing_kernel, smoothing_kernel_squared, scalar_pressure;

            Vector2 particle_pressure;
            Vector2 vector_between_particle_neighbour;
            Vector2 neighbour_pressure;
            N_Particle nparticle = new N_Particle();

            pindex = 0;

            foreach (Particle p in plst)
            {

                pressure = stiffness * (p.Density - rest_density);
                near_pressure = near_stiffness * p.Neardensity;
                particle_pressure.X = particle_pressure.Y = 0; //reset particle pressure vector to 0

                foreach (N_Particle n in p.Neighbourlist)
                {
                    nindex = n.Particleindex;
                    //smoothing_kernel = n.Smoothingkernel;
                    smoothing_kernel = (float)(n.Smoothingkernel * (3 / (Math.PI * smoothing_radius * smoothing_radius)));
                    smoothing_kernel_squared = n.Smoothingkernelsquared;
                    vector_between_particle_neighbour.X = plst.ElementAt(nindex).Position.X - plst.ElementAt(pindex).Position.X;
                    vector_between_particle_neighbour.Y = plst.ElementAt(nindex).Position.Y - plst.ElementAt(pindex).Position.Y;
                    scalar_pressure = pressure * smoothing_kernel + near_pressure * smoothing_kernel_squared;
                    scalar_pressure *= dt * dt * dt_scalefactor * dt_scalefactor;

                    if (n.Distance != 0)
                        neighbour_pressure = vector_between_particle_neighbour / n.Distance * scalar_pressure;
                    else
                        neighbour_pressure.X = neighbour_pressure.Y = 0;

                    plst.ElementAt(nindex).AccumulateForce(neighbour_pressure);
                    particle_pressure -= neighbour_pressure;
                }
                p.Pressure = (float)(Math.Sqrt(particle_pressure.X * particle_pressure.X + particle_pressure.Y * particle_pressure.Y));
                p.AccumulateForce(particle_pressure);
                pindex++;
            }
        }

        public void CalculateViscosity(List<Particle> plst, float smoothing_radius, float dt)
        {
            int pindex, nindex;
            float length, q, inward_radial_vel;

            N_Particle nparticle = new N_Particle();

            Vector2 vector_between_neighbour_particle;
            Vector2 normalised_vector_between_neighbour_particle;
            Vector2 impulse;

            pindex = 0;
            foreach (Particle p in plst)
            {
                foreach (N_Particle n in p.Neighbourlist)
                {
                    nparticle = n;
                    nindex = nparticle.Particleindex;
                    vector_between_neighbour_particle = plst.ElementAt(nindex).Position - plst.ElementAt(pindex).Position;
                    length = nparticle.Distance;
                    q = length / smoothing_radius;
                    normalised_vector_between_neighbour_particle = vector_between_neighbour_particle / length;
                    //calculate inward radial velocity
                    Vector2 temp = new Vector2();
                    temp.X = plst.ElementAt(pindex).Velocity.X - plst.ElementAt(nindex).Velocity.X;
                    temp.Y = plst.ElementAt(pindex).Velocity.Y - plst.ElementAt(nindex).Velocity.Y;
                    inward_radial_vel = Vector2.Dot(temp, normalised_vector_between_neighbour_particle);

                    if (inward_radial_vel > 0.0f)
                    {
                        impulse = normalised_vector_between_neighbour_particle * (plst.ElementAt(nindex).Vsigma * inward_radial_vel + plst.ElementAt(nindex).Vbeta * inward_radial_vel * inward_radial_vel) * (1 - q);
                        impulse *= dt * dt_scalefactor;
                        if (plst.ElementAt(pindex).Ismovingboundary == false && plst.ElementAt(pindex).Isstationaryboundary == false)
                            plst.ElementAt(pindex).Velocity -= impulse;
                        if (plst.ElementAt(pindex).Ismovingboundary == false && plst.ElementAt(pindex).Isstationaryboundary == false)
                            plst.ElementAt(nindex).Velocity += impulse;
                    }
                }

                pindex++;
            }
        }

        public void CalculateViscoElasticity(List<Particle> plst, float smoothing_radius, float k, float yield_ratio, float pconst, float dt)
        {
            int pindex, sindex, sp1index, sp2index;
            float restlength, tolerable_def, distance_between_neighbour_particle, tempfloat;

            Vector2 sdisplacement;
            Vector2 temp;

            //create springs
            pindex = 0;
            foreach (Particle p in plst)
            {
                foreach (N_Particle n in p.Neighbourlist)
                {
                    N_Particle nparticle = new N_Particle();
                    Spring spring = new Spring();
                    nparticle = n;


                    if (!SpringArray.Springarray[pindex, nparticle.Particleindex])
                    {
                        SpringArray.Springarray[pindex, nparticle.Particleindex] = true;
                        spring.Point1 = pindex;
                        spring.Point2 = nparticle.Particleindex;
                        spring.Restlength = smoothing_radius;
                        tempfloat = rand.Next((int)(k * 10), (int)(k * 10 + 3));
                        spring.Coefficient = tempfloat / 10;
                        //spring.Coefficient = k;
                        SpringArray.Springlst.Add(spring);
                    }
                }


                pindex++;
            }

            //Alter the rest length of springs
            sindex = 0;
            foreach (Spring s in SpringArray.Springlst.ToList())
            {
                sp1index = s.Point1;
                sp2index = s.Point2;
                restlength = s.Restlength;
                tolerable_def = yield_ratio * restlength;
                temp.X = plst.ElementAt(sp2index).Position.X - plst.ElementAt(sp1index).Position.X;
                temp.Y = plst.ElementAt(sp2index).Position.Y - plst.ElementAt(sp1index).Position.Y;
                distance_between_neighbour_particle = temp.Length();

                if (distance_between_neighbour_particle > (restlength + tolerable_def))
                    s.Restlength += dt * dt_scalefactor * pconst * (distance_between_neighbour_particle - restlength - tolerable_def);
                else if (distance_between_neighbour_particle < (restlength - tolerable_def))
                    s.Restlength -= dt * dt_scalefactor * pconst * (restlength - tolerable_def - distance_between_neighbour_particle);

                if (s.Restlength > smoothing_radius && sindex < plst.Count)
                {
                    SpringArray.Springarray[sindex, sindex] = false;
                    SpringArray.Springlst.RemoveAt(sindex);
                    sindex--;
                }
                sindex++;
            }

            //update position of particle due to spring forces
            sindex = 0;
            foreach (Spring s in SpringArray.Springlst)
            {
                Vector2 sforce = new Vector2(0, 0);
                sp1index = s.Point1;
                sp2index = s.Point2;
                restlength = s.Restlength;
                sforce = s.CalculateForce(sforce, s, plst.ElementAt(sp1index), plst.ElementAt(sp2index));

                sdisplacement = sforce * (1.0f - restlength / smoothing_radius) * dt * dt_scalefactor * dt * dt_scalefactor;
                if (plst.ElementAt(sp1index).Ismovingboundary == false && plst.ElementAt(sp1index).Isstationaryboundary == false)
                    plst.ElementAt(sp1index).Position -= sdisplacement;
                if (plst.ElementAt(sp2index).Ismovingboundary == false && plst.ElementAt(sp2index).Isstationaryboundary == false)
                    plst.ElementAt(sp2index).Position += sdisplacement;

                sindex++;
            }
        }

        public void ResetSprings()
        {
            this.SpringArray = new Spring_Array(num_particles);
        }

        public void InitialisePlasticity(List<Particle> plst, float smoothing_radius, float k)
        {
            int pindex1, pindex2;
            float distance, tempfloat;

            if (SpringArray.Springarray == null)
                ResetSprings();

            pindex1 = 0;
            foreach (Particle p in plst)
            {
                //if the particle is boundary move on to the next particle since we don't want moving particles to attach to the boundary
                if (p.Ismovingboundary || p.Isstationaryboundary)
                    continue;

                pindex2 = 0;
                foreach (Particle p2 in plst)
                {
                    //if the particle is a boundary move on to the next particle
                    if (p2.Ismovingboundary || p2.Isstationaryboundary)
                        continue;

                    Spring spring = new Spring();
                    Vector2 vector_between_particle_neighbour = new Vector2();
                    vector_between_particle_neighbour.X = p2.Position.X - p.Position.X;
                    vector_between_particle_neighbour.Y = p2.Position.Y - p.Position.Y;
                    distance = vector_between_particle_neighbour.Length();

                    if (0 < distance && distance < smoothing_radius && !SpringArray.Springarray[pindex1, pindex2])
                    {
                        spring.Point1 = pindex1;
                        spring.Point2 = pindex2;
                        spring.Restlength = distance;
                        tempfloat = rand.Next((int)(k * 10), (int)(k * 10 + 3));
                        if (p.Mass == 1 && p2.Mass == 1)
                            spring.Coefficient = tempfloat / 10;
                        else if (p.Mass == 0 && p2.Mass == 0)
                            spring.Coefficient = tempfloat / 20;
                        else
                            spring.Coefficient = k;
                        SpringArray.Springlst.Add(spring);
                        SpringArray.Springarray[pindex1, pindex2] = true;
                        SpringArray.Springarray[pindex2, pindex1] = true;
                    }
                    pindex2++;
                }
                pindex1++;
            }
        }

        public void CalculatePlasticity(List<Particle> plst, float dt)
        {
            int sindex, sp1index, sp2index;
            float restlength;

            sindex = 0;
            foreach (Spring s in SpringArray.Springlst)
            {
                Vector2 sforce = new Vector2(0, 0);
                Vector2 sdisplacement;
                sp1index = s.Point1;
                sp2index = s.Point2;
                restlength = s.Restlength;
                sforce = s.CalculateForce(sforce, s, plst.ElementAt(sp1index), plst.ElementAt(sp2index));
                sdisplacement = sforce * dt * dt_scalefactor;
                if (plst.ElementAt(sp1index).Isstationaryboundary == false && plst.ElementAt(sp1index).Ismovingboundary == false)
                    plst.ElementAt(sp1index).Position -= sdisplacement;
                if (plst.ElementAt(sp2index).Isstationaryboundary == false && plst.ElementAt(sp2index).Ismovingboundary == false)
                    plst.ElementAt(sp2index).Position += sdisplacement;

                sindex++;
            }
        }

        public void ApplyBoundaryForces(List<Particle> plst, float dt, float smoothing_radius)
        {
            float distance, distance_squared, ratio;
            float ratio_squared, ratio_p4, ratio_p12;
            float D; //this variable should be of the same magnitude as the largest attained velocity by a particle            

            //for each particle that is not a boundary particle look at neighbours and check if any are boundary particles            
            foreach (var p in plst)
            {
                if (p.Ismovingboundary || p.Isstationaryboundary)
                    continue;

                //if they are not boundary particles look at the neighbour list
                //for each neighbour that is a boundary particle apply a repulsive force
                foreach (var n in p.Neighbourlist)
                {
                    if (!n.Ismovingboundary && !n.Isstationaryboundary)//other fluid particle
                        continue;

                    Vector2 vector_between_particle_boundary = new Vector2();
                    Vector2 boundary_force = new Vector2();
                    vector_between_particle_boundary.X = plst.ElementAt(n.Particleindex).Position.X - p.Position.X;
                    vector_between_particle_boundary.Y = plst.ElementAt(n.Particleindex).Position.Y - p.Position.Y;
                    distance = vector_between_particle_boundary.Length();
                    distance_squared = distance * distance;
                    ratio = 3 / distance;
                    D = 1000;
                    if (ratio <= 1)//apply force
                    {
                        //different ratio powers
                        ratio_squared = ratio * ratio;
                        ratio_p4 = ratio_squared * ratio_squared;
                        ratio_p12 = ratio_p4 * ratio_p4 * ratio_p4;

                        boundary_force = D * (ratio_p12 - ratio_p4) * (vector_between_particle_boundary / distance_squared);
                        p.AccumulateForce(boundary_force);
                    }

                }

            }

        }
        #endregion
    }
}
