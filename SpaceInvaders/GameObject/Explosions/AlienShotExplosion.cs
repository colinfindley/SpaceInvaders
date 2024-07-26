//-----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------- 

namespace SpaceInvaders
{
    public class AlienShotExplosion : ExplosionCategory
    {
        public AlienShotExplosion(float posX, float posY)
        : base(GameObject.Name.AlienShotExplosion, SpriteGame.Name.AlienShotExplosion, posX, posY)
        {
        }
        
    }
}