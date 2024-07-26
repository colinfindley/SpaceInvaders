using System;
using System.Diagnostics;


namespace SpaceInvaders
{
    class DelayBombCmd : Command
    {
        public DelayBombCmd(GameObject _pGameObject)
        {
            this.pGameObject = _pGameObject;
            this.invadersBatch = SpriteBatchMan.Find(SpriteBatch.Name.SpaceInvaders);
            Debug.Assert(this.invadersBatch != null);

            this.boxBatch = SpriteBatchMan.Find(SpriteBatch.Name.Boxes);
            Debug.Assert(this.boxBatch != null);
        }

        public override void Execute(float deltaTime)
        {
            pGameObject.Update();
            Bomb pBomb = new Bomb(GameObject.Name.SquigglyShot, SpriteGame.Name.SquigglyShotA, new FallZigZag(), pGameObject.x, pGameObject.y);
            //     Debug.WriteLine("----x:{0}", value);

            pBomb.ActivateCollisionSprite(this.boxBatch);
            pBomb.ActivateSprite(this.invadersBatch);

            // Attach the missile to the Bomb root
            GameObject pBombRoot = GameObjectNodeMan.Find(GameObject.Name.BombRoot);
            Debug.Assert(pBombRoot != null);

            // Add to GameObject Tree - {update and collisions}
            pBombRoot.Add(pBomb);
        }

        GameObject pGameObject;
        readonly SpriteBatch invadersBatch;
        readonly SpriteBatch boxBatch;
    }
}
// --- End of File ---