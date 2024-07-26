using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class UFOCategory : Leaf
    {
        protected UFOCategory(GameObject.Name name, SpriteGame.Name spriteName, float posX, float posY, UFOCategory.Type shipType)
        : base(name, spriteName, posX, posY)
        {
            this.UFOType = shipType;
        }
        public enum Type
        {
            UFO,
            UFORoot,
            Unitialized
        }
        // Data: ---------------
        ~UFOCategory()
        {
        }

        // this is just a placeholder, who knows what data will be stored here
        protected UFOCategory.Type UFOType;
    }
}
