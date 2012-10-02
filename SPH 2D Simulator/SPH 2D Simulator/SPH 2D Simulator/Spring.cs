using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SPH_2D_Simulator
{
    class Spring
    {
        //Parameters and Accessors
        private int point1;
        public int Point1
        {
            get { return point1; }
            set { point1 = value; }
        }

        private int point2;
        public int Point2
        {
            get { return point2; }
            set { point2 = value; }
        }

        private float restlength;
        public float Restlength
        {
            get { return restlength; }
            set { restlength = value; }
        }

        private float coefficient;
        public float Coefficient
        {
            get { return coefficient; }
            set { coefficient = value; }
        }

        private float coefficientofdamping;
        public float Coefficientofdamping
        {
            get { return coefficientofdamping; }
            set { coefficientofdamping = value; }
        }

        //Constructors
        public Spring() { }

        //Methods
        public Vector2 CalculateForce(Vector2 force, Spring spring, Physics_Entity p1, Physics_Entity p2)
        {
            Vector2 vector_between_p1_p2;
            float current_length;

            vector_between_p1_p2.X = p2.Position.X - p1.Position.X;
            vector_between_p1_p2.Y = p2.Position.Y - p1.Position.Y;

            current_length = vector_between_p1_p2.Length();
            vector_between_p1_p2.Normalize();
            force = vector_between_p1_p2 * (spring.Restlength - current_length) * spring.Coefficient;
            return force;
        }
    }
}
