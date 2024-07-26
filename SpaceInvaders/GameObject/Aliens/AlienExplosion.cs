using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class AlienExplosion : AlienCategory
    {
        public AlienExplosion(SpriteGame.Name spriteName, float posX, float posY)
        : base(GameObject.Name.AlienExplosion, spriteName, posX, posY)
        {
        }
        public override void Accept(ColVisitor other)
        {
            //// Call the appropriate collision reaction            
            //other.VisitAlienExplosion(this);
        }

        public override void VisitMissileGroup(MissileGroup m)
        {

        }


        public override void Update()
        {

            base.Update();
        }

        // Data: ---------------

    }
}

