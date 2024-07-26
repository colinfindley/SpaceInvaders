//-----------------------------------------------------------------------------
// 
//-----------------------------------------------------------------------------
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShieldGrid : Composite
    {
        public ShieldGrid(GameObject.Name name, SpriteGame.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            //Debug.WriteLine("Grid proxy sprite: {0}", this.pSpriteProxy.GetHashCode());
            //Debug.WriteLine("Grid col   sprite: {0}",this.poColObj.pColSprite.GetHashCode());
            this.x = posX;
            this.y = posY;

            this.SetCollisionColor(0.0f, 0.0f, 1.0f);
        }

        public void Resurrect(float posX, float posY)
        {
            this.x = posX;
            this.y = posY;
            
            base.Resurrect();

            this.SetCollisionColor(0.0f, 0.0f, 1.0f);
        }
        ~ShieldGrid()
        {
        }

        public void ClearGrid()
        {
            IteratorForwardComposite pFor = new IteratorForwardComposite(this);

            Component pNode = pFor.First();
            while (!pFor.IsDone())
            {

                GameObject pGameObj = (GameObject)pNode;
                pGameObj.Remove();

                pNode = pFor.Next();

            }
        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitShieldGrid(this);
        }

        public override void VisitMissile(Missile m)
        {
            // Missile vs ShieldGrid
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
            ColPair.Collide(m, pGameObj);
        }
        public override void VisitBomb(Bomb b)
        {
            // Missile vs ShieldRoot
            ColPair.Collide(b, (GameObject)IteratorForwardComposite.GetChild(this));
        }

        public override void VisitColumn(AlienColumn a)
        {
            // Bomb vs ShieldColumn
            ColPair.Collide((GameObject)IteratorForwardComposite.GetChild(a), this);
        }
        public override void VisitAlien(AlienCategory a)
        {
            // Bomb vs ShieldColumn
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
            ColPair.Collide(a, pGameObj);
        }

        public override void Update()
        {
            // Go to first child
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }

        // -------------------------------------------
        // Data: 
        // -------------------------------------------


    }
}

// --- End of File ---
