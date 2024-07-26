//-----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Missile : MissileCategory
    {
        public Missile(SpriteGame.Name spriteName, float posX, float posY)
            : base(GameObject.Name.Missile, spriteName, posX, posY)
        {
            this.x = posX;
            this.y = posY;

            this.delta = 7.0f;

            this.poColObj.pColSprite.SetColor(1, 1, 0);
        }
        public void Resurrect(float posX, float posY)
        {
            this.x = posX;
            this.y = posY;
            this.delta = 7.0f;

            base.Resurrect();
            this.poColObj.pColSprite.SetColor(1, 1, 0);

        }
        public override void Update()
        {
            base.Update();
            this.y += delta;
        }

        ~Missile()
        {

        }

        public override void Remove()
        {
            // Since the Root object is being drawn
            // 1st set its size to zero
            this.poColObj.poColRect.Set(0, 0, 0, 0);
            base.Update();

            // Update the parent (missile root)
            GameObject pParent = (GameObject)this.pParent;
            pParent.Update();

            // Now remove it
            base.Remove();
        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have a Missile
            // Call the appropriate collision reaction            
            other.VisitMissile(this);
        }

        public override void VisitBomb(Bomb b)
        {
            // Bomb vs ShieldBrick
            //Debug.WriteLine(" ---> Done");
            ColPair pColPair = ColPairMan.GetActiveColPair();
            pColPair.SetCollision(b,this);
            pColPair.NotifyListeners();
            SoundNodeMan.Play(SoundNode.Name.Explode);
        }




        public void SetPos(float xPos, float yPos)
        {
            this.x = xPos;
            this.y = yPos;
        }


        // Data -------------------------------------
        public float delta;
    }
}

// --- End of File ---
