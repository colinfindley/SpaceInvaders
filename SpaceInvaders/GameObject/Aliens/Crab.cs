//-----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Crab : AlienCategory
    {
        public Crab(SpriteGame.Name spriteName, float posX, float posY)
        : base(GameObject.Name.Crab, spriteName, posX, posY)
        {
        }

        public override void Update()
        {

            base.Update();
        }
        public override void AddScore()
        {
            int score = SceneContext.GetScoreInt();
            score += 20;
            SceneContext.SetScore(score);

            Font life = FontMan.Find(Font.Name.PlayerOneScore);
            life.UpdateMessage(score.ToString());
        }

        // Data: ---------------

    }
}

// --- End of File ---
