//-----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------- 

using System.Diagnostics;

namespace SpaceInvaders
{
    public class AlienFactory
    {
        public AlienFactory(SpriteBatch.Name spriteBatchName, SpriteBatch.Name BoxName = SpriteBatch.Name.Boxes)
        {
            this.pSpriteBatch = SpriteBatchMan.Find(spriteBatchName);
            Debug.Assert(this.pSpriteBatch != null);
            this.pBoxBatch = SpriteBatchMan.Find(BoxName);
            //Debug.Assert(this.pBoxBatch != null);

        }

        public GameObject Create(GameObject.Name Name, float posX = 0.0f, float posY = 0.0f)
        {
            GameObject pGameObj = null;

            // These are all LTN that are held onto by sprite batch man
            switch (Name)
            {
                case GameObject.Name.Octopus:
                    pGameObj = new Octopus(SpriteGame.Name.OctopusA, posX, posY);
                    break;

                case GameObject.Name.Crab:
                    pGameObj = new Crab(SpriteGame.Name.CrabA, posX, posY);
                    break;

                case GameObject.Name.Squid:
                    pGameObj = new Squid(SpriteGame.Name.SquidA, posX, posY);
                    break;
                case GameObject.Name.AlienGrid:
                    pGameObj = new AlienGrid();
                    break;

                case GameObject.Name.AlienColumn:
                    pGameObj = new AlienColumn();
                    break;
                case GameObject.Name.AlienRoot:
                    pGameObj = new AlienRoot();
                    break;

                default:
                    // something is wrong
                    Debug.Assert(false);
                    break;
            }

            // Attached to Group
            pGameObj.ActivateSprite(this.pSpriteBatch);
            pGameObj.ActivateCollisionSprite(this.pBoxBatch);

            return pGameObj;
        }

        // Data: ---------------------

        SpriteBatch pSpriteBatch;
        SpriteBatch pBoxBatch;
    }
}

// --- End of File ---