//-----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class UFO : UFOCategory
    {

        public UFO(float x = 700, float y = 650)
         : base(GameObject.Name.UFO, SpriteGame.Name.UFO, x, y, UFOCategory.Type.UFO)
        {
            this.UFOSpeed = .5f;
        }


        public override void Resurrect()
        {
            this.x = 700;
            this.y = 650;

            base.Resurrect();
            this.poColObj.pColSprite.SetColor(1, 1, 0);

        }

        public override void AddScore()
        {
            int score = SceneContext.GetScoreInt();
            score += 200;
            SceneContext.SetScore(score);

            Font life = FontMan.Find(Font.Name.PlayerOneScore);
            life.UpdateMessage(score.ToString());
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



        public override void Update()
        {
            base.Update();
            this.x -= UFOSpeed;

            // When it goes off screen
            if (this.x < -30)
            {
                Remove();
            }
        }

        public void SetPos(float xPos, float yPos)
        {
            this.x = xPos;
            this.y = yPos;
        }

        public override void Accept(ColVisitor other)
        {
            // Call the appropriate collision reaction
            other.VisitUFO(this);
        }

        public override void VisitMissile(Missile m)
        {
            // Missile vs Aliens
            ColPair pColPair = ColPairMan.GetActiveColPair();
            pColPair.SetCollision(m, this);
            pColPair.NotifyListeners();
        }




        // Data: --------------------
        public float UFOSpeed;
        public float width;
    }
}

// --- End of File ---
