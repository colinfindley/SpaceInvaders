﻿//-----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class WallRight : WallCategory
    {
        public WallRight(GameObject.Name name, SpriteGame.Name spriteName, float posX, float posY, float width, float height)
            : base(name, spriteName, posX, posY, Type.Right)
        {
            this.poColObj.poColRect.Set(posX, posY, width, height);

            this.x = posX;
            this.y = posY;

            this.poColObj.pColSprite.SetColor(1, 1, 0);
        }

        ~WallRight()
        {

        }
        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitWallRight(this);
        }
        public override void Update()
        {
            // Go to first child
            base.Update();
        }




        // Data: ---------------


    }
}

// --- End of File ---
