//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

namespace SpaceInvaders
{
    abstract class AlienBase : Leaf
    {
        public enum Type
        {
            Squid,
            Crab,
            Octopus
        }

        protected AlienBase(GameObject.Name gameName, SpriteGame.Name spriteName, float _x, float _y)
            : base(gameName, spriteName, _x, _y)
        {

        }

        public override void Move(float deltaX, float deltaY)
        {
            this.x += deltaX;
            this.y += deltaY;
        }
    }
}

// --- End of File ---
