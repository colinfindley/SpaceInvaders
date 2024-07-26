//-----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class MissileCategory : Leaf
    {
        public enum Type
        {
            Missile,
            MissileGroup,
            Unitialized
        }

        protected MissileCategory(GameObject.Name gameName, SpriteGame.Name spriteName, float _x, float _y)
        : base(gameName, spriteName, _x, _y)
        {
        }

        override public void Resurrect()
        {
            base.Resurrect();
        }


        ~MissileCategory()
        {
        }
    }
}

// --- End of File ---
