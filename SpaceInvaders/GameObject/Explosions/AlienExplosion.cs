using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class AlienExplosion : ExplosionCategory
    {
        public AlienExplosion(float posX, float posY)
        : base(GameObject.Name.AlienExplosion, SpriteGame.Name.AlienExplosion, posX, posY)
        {
        }

    }
}

