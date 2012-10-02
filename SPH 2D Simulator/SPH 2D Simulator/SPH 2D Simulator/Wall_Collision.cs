using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SPH_2D_Simulator
{
    class Wall_Collision
    {
         //constructors
        public Wall_Collision() { }

        //methods

        public void checkforwall(Physics_Entity entity, float wall_k, Vector2 pos, float min_x, float max_x, float min_y, float max_y)
        {
            if (entity.Position.X < min_x + pos.X)
            {
                Vector2 changeForce = new Vector2(entity.Force.X - (entity.Position.X - (min_x + pos.X)) * wall_k, entity.Force.Y);
                entity.Force = changeForce;
            }

            if (entity.Position.X > max_x + pos.X)
            {
                Vector2 changeForce = new Vector2(entity.Force.X - (entity.Position.X - (max_x + pos.X)) * wall_k, entity.Force.Y);
                entity.Force = changeForce;
            }

            if (entity.Position.Y < min_y + pos.Y)
            {
                Vector2 changeForce = new Vector2(entity.Force.X, entity.Force.Y - (entity.Position.Y - (min_y + pos.Y)) * wall_k);
                entity.Force = changeForce;
            }

            if (entity.Position.Y > max_y + pos.Y)
            {
                Vector2 changeForce = new Vector2(entity.Force.X, entity.Force.Y - (entity.Position.Y - (max_y + pos.Y)) * wall_k);
                entity.Force = changeForce;
            }
        }

        public void checkwall(Physics_Entity entity, float top, float bottom, float left, float right)
        {
            if (entity.Position.X < left || entity.Position.X > right)
            {
                Vector2 newvel = new Vector2(entity.Velocity.X * -1, entity.Velocity.Y);
                entity.Velocity = newvel;
            }

            if (entity.Position.Y < bottom || entity.Position.Y > top)
            {
                Vector2 newvel = new Vector2(entity.Velocity.X, entity.Velocity.Y * -1);
                entity.Velocity = newvel;
            }
        }
    }
}
