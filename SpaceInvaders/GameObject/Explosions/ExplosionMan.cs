using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ExplosionMan
    {
        public static void Explode(GameObject.Name explosionType, float x, float y, float delay)
        {
            // Get Explosion from Factory
            ExplosionFactory EF = new ExplosionFactory();
            ExplosionCategory pExplosion = (ExplosionCategory)EF.Create(explosionType, x, y);

            // Render explosion then delete it after .15 deltaTime
            //pExplosion.pSpriteProxy.Render();
            DeleteSpriteCmd explode = new DeleteSpriteCmd(pExplosion);
            TimerEventMan.Add(TimerEvent.Name.DeleteSprite, explode, delay);
        }
    }
}
