//-----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Squid : AlienCategory
    {
        public Squid(SpriteGame.Name spriteName, float posX, float posY)
        : base(GameObject.Name.Squid, spriteName, posX, posY)
        {
        }

        public override void AddScore()
        {
            int score = SceneContext.GetScoreInt();
            score += 30;
            SceneContext.SetScore(score);

            Font life = FontMan.Find(Font.Name.PlayerOneScore);
            life.UpdateMessage(score.ToString());
        }

        public override void Update()
        {
            base.Update();
        }

        // Data: ---------------

    }
}

// --- End of File ---
