//-----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------- 

using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class AlienCategory : Leaf
    {
        public enum Type
        {
            Squid,
            Crab,
            Octopus
        }

        protected AlienCategory(GameObject.Name gameName, SpriteGame.Name spriteName, float _x, float _y)
            : base(gameName, spriteName, _x, _y)
        {


        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an AlienGroup
            // Call the appropriate collision reaction            
            other.VisitAlien(this);
        }

        public override void VisitMissile(Missile m)
        {
            // Missile vs Aliens
            ColPair pColPair = ColPairMan.GetActiveColPair();
            pColPair.SetCollision(m, this);
            pColPair.NotifyListeners();
        }

        public override void VisitMissileGroup(MissileGroup m)
        {
            // Missile vs Bird
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(m);
            ColPair.Collide(pGameObj, this);
        }

        public override void VisitShieldBrick(ShieldBrick s)
        {
            ColPair pColPair = ColPairMan.GetActiveColPair();
            pColPair.SetCollision(s, this);
            pColPair.NotifyListeners();
        }

        public override void VisitWallGroup(WallGroup w)
        {
            ColPair pColPair = ColPairMan.GetActiveColPair();
            pColPair.SetCollision(w, this);
            pColPair.NotifyListeners();
        }



        public override void Move(float deltaX, float deltaY)
        {
            this.x += deltaX;
            this.y += deltaY;
        }

    }
}

// --- End of File ---
