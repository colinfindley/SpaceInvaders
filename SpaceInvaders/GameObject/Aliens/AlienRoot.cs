//-----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class AlienRoot : Composite
    {
        public AlienRoot()
            : base()
        {
            this.name = Name.AlienRoot;

        }
        public void Resurrect(float posX, float posY)
        {
            this.x = posX;
            this.y = posY;
            base.Resurrect();
        }
        ~AlienRoot()
        {
        }
        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            //other.VisitAlienRoot(this);
        }
        public override void VisitMissileGroup(MissileGroup m)
        {
            // MissileRoot vs AlienRoot
            //GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(m);
            //ColPair.Collide(pGameObj, this);
        }
        public override void VisitMissile(Missile m)
        {
            // Missile vs AlienRoot
            //GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
            //ColPair.Collide(m, pGameObj);
        }
        public override void VisitBombRoot(BombRoot b)
        {
            //// BombRoot vs AlienRoot
            //ColPair.Collide((GameObject)IteratorForwardComposite.GetChild(b), this);
        }
        public override void VisitBomb(Bomb b)
        {
            //// Missile vs AlienRoot
            //ColPair.Collide(b, (GameObject)IteratorForwardComposite.GetChild(this));
        }
        public override void Update()
        {
            // Go to first child
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }

        // ------------------------------------------
        // Data:
        // ------------------------------------------
        

    }
}

// --- End of File ---
