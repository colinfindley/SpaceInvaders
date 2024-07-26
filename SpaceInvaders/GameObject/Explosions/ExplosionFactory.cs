//-----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------- 

using System.Diagnostics;

namespace SpaceInvaders
{
    public class ExplosionFactory
    {
        public ExplosionFactory()
        {
            this.pSpriteBatch = SpriteBatchMan.Find(SpriteBatch.Name.Explosions);
            Debug.Assert(this.pSpriteBatch != null);
            this.pBoxBatch = SpriteBatchMan.Find(SpriteBatch.Name.Aesthetics);
            Debug.Assert(this.pBoxBatch != null);

        }

        public GameObject Create(GameObject.Name explosionType, float posX = 0.0f, float posY = 0.0f)
        {
            // Check to see if we can get it from GhostMan
            ExplosionCategory pExplosion = null;
            GameObjectNode pGameObjNode = GhostMan.Find(explosionType);

            if (pGameObjNode == null)
            {
                pExplosion = CreateNewExplosion(explosionType, posX, posY);
            }
            else
            {
                // Recycle it.
                pExplosion = (ExplosionCategory)pGameObjNode.pGameObj;
                GhostMan.Remove(pGameObjNode);
                // GhostMan.Dump();
                pExplosion.Resurrect(posX, posY);


                // Attached to SpriteBatches
                SpriteBatch pSB_Aliens = SpriteBatchMan.Find(SpriteBatch.Name.SpaceInvaders);
                SpriteBatch pSB_Boxes = SpriteBatchMan.Find(SpriteBatch.Name.Aesthetics);

                pExplosion.ActivateCollisionSprite(pSB_Boxes);
                pExplosion.ActivateSprite(pSB_Aliens);
            }

            // Attach the missile to the missile root
            GameObject pExplosionRoot = GameObjectNodeMan.Find(GameObject.Name.ExplosionRoot);
            Debug.Assert(pExplosionRoot != null);

            // Add to GameObject Tree - {update and collisions}
            pExplosionRoot.Add(pExplosion);
            return pExplosion;    
        }

        public ExplosionCategory CreateNewExplosion(GameObject.Name explosionType, float posX = 0.0f, float posY = 0.0f)
        {
            GameObject pGameObj = null;

            // These are all LTN that are held onto by sprite batch man
            switch (explosionType)
            {
                case GameObject.Name.AlienExplosion:
                    pGameObj = new AlienExplosion(posX, posY);
                    break;

                case GameObject.Name.AlienShotExplosion:
                    pGameObj = new AlienShotExplosion(posX, posY);
                    break;
                case GameObject.Name.PlayerExplosion:
                    pGameObj = new PlayerExplosion(posX, posY);
                    break;
                case GameObject.Name.SaucerExplosion:
                    pGameObj = new ExplosionRoot();
                    break;

                default:
                    // something is wrong
                    Debug.Assert(false);
                    break;
            }

            // Attached to Group
            pGameObj.pSpriteProxy.x = posX;
            pGameObj.pSpriteProxy.y = posY;

            pGameObj.ActivateSprite(this.pSpriteBatch);
            pGameObj.ActivateCollisionSprite(this.pBoxBatch);

            return (ExplosionCategory)pGameObj;
        }

        // Data: ---------------------

        SpriteBatch pSpriteBatch;
        SpriteBatch pBoxBatch;
    }
}

// --- End of File ---