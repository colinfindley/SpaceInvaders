﻿//-----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class WallGroup : Composite
    {
        public WallGroup(GameObject.Name name, SpriteGame.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;

            this.poColObj.pColSprite.SetColor(1, 1, 1);

            this.name = name;
        }
        ~WallGroup()
        {

        }
        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitWallGroup(this);
        }
        public override void Update()
        {
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }

        public override void VisitMissileGroup(MissileGroup m)
        {
            // MissileRoot vs WallRoot
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(m);
            ColPair.Collide(pGameObj, this);
        }
        public override void VisitMissile(Missile m)
        {
            // Missile vs WallRoot
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
            ColPair.Collide(m, pGameObj);
        }
        public override void VisitBombRoot(BombRoot b)
        {
            // BombRoot vs WallRoot
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(b);
            ColPair.Collide(pGameObj, this);
        }
        public override void VisitBomb(Bomb b)
        {
            // Bomb vs WallRoot
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
            ColPair.Collide(b, pGameObj);
        }

        // Data: ---------------


    }
}

// --- End of File ---
