using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class ExplosionCategory : Leaf
    {
        public enum Type
        {
            AlienExplosion,
            AlienShotExplosion,
            PlayerShotExplosion,
            SaucerExplosion
        }

        protected ExplosionCategory(GameObject.Name gameName, SpriteGame.Name spriteName, float _x, float _y)
        : base(gameName, spriteName, _x, _y)
        {
        }


        public void Resurrect(float posX, float posY)
        {
            this.x = posX;
            this.y = posY;
            this.pSpriteProxy.x = posX;
            this.pSpriteProxy.y = posY;
            this.poColObj.pColSprite.x = posX;
            this.poColObj.pColSprite.y = posY;
            this.poColObj.poColRect.x = posX;
            this.poColObj.poColRect.y = posY;
            GameObject root = (GameObject)this.pParent;
            root.x = posX;
            root.y = posY;
            root.pSpriteProxy.x = posX;
            root.pSpriteProxy.y = posY;
            root.poColObj.pColSprite.x = posX;
            root.poColObj.pColSprite.y = posY;
            root.poColObj.poColRect.x = posX;
            root.poColObj.poColRect.y = posY;
        }



        public override void Accept(ColVisitor other)
        {
            throw new NotImplementedException();
        }

    }
}
