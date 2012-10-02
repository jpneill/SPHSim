using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SPH_2D_Simulator
{
    class Camera
    {
        private int near = 1;

        public int Near
        {
            get { return near; }
            set { near = value; }
        }

        private int far = 1000;

        public int Far
        {
            get { return far; }
            set { far = value; }
        }

        private Matrix view;
        public Matrix View
        {
            get { return view; }
        }

        private Matrix projection;
        public Matrix Projection
        {
            get { return projection; }
        }

        private Vector3 cameraPosition = new Vector3(200, 135, 400);
        public Vector3 CameraPosition
        {
            get { return cameraPosition; }
            set { cameraPosition = value; }
        }

        public Camera(GraphicsDevice g)
        {
            Reset(g);
        }
        
        public void Reset(GraphicsDevice g)
        {
            float aspect = g.Viewport.AspectRatio;
            view = Matrix.CreateLookAt(cameraPosition, new Vector3(200, 135, 0), Vector3.Up);
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, aspect, near, far);
        }
    }
}
