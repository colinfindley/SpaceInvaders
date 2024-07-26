using System;
using System.Diagnostics;


namespace SpaceInvaders
{
    public class PlayerExplosion : ExplosionCategory
    {
        public PlayerExplosion(float posX, float posY)
        : base(GameObject.Name.PlayerExplosion, SpriteGame.Name.PlayerExplosionA, posX, posY)
        {
        }
    }
}
