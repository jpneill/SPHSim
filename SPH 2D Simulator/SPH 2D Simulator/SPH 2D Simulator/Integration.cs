using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SPH_2D_Simulator
{
    class Integration
    {
        //constructors
        public Integration() { }

        //Methods
        public void updatevel(Physics_Entity entity, float dt)
        {
            Vector2 newpos;

            newpos = entity.Position + entity.Force * dt;
            entity.Velocity = (newpos - entity.Oldposition) / (dt);
        }

        public void updatepos(Physics_Entity entity, float dt)
        {
            entity.Position = entity.Position + entity.Force * dt;
            entity.Oldposition = entity.Position;
            entity.Position = entity.Position + entity.Velocity * dt;
        }
    }
}
