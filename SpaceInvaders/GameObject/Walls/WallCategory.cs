//-----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class WallCategory : Leaf
    {
        public enum Type
        {
            WallGroup,
            Right,
            Left,
            Bottom,
            Top,

            Unitialized
        }

        protected WallCategory(GameObject.Name gameName, SpriteGame.Name spriteName, float _x, float _y, WallCategory.Type _type)
        : base(gameName, spriteName, _x, _y)
        {
            WallType = _type;
        }

        public override void VisitMissile(Missile m)
        {
            // Missile vs Aliens
            ColPair pColPair = ColPairMan.GetActiveColPair();
            pColPair.SetCollision(m, this);
            pColPair.NotifyListeners();
        }

        ~WallCategory()
        {
        }

        public WallCategory.Type GetCategoryType()
        {
            return this.WallType;
        }

        // Data ----------
        protected WallCategory.Type WallType;

    }
}

// --- End of File ---
