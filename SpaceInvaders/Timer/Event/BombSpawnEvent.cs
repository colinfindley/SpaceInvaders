//-----------------------------------------------------------------------------
// 
//-----------------------------------------------------------------------------
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class BombSpawnEvent : Command
    {
        public BombSpawnEvent(Random pRandom, AlienGrid alienGrid, FallStrategy fallStrategy, SpriteGame.Name bombType, GameObject.Name gameObjectType)
        {
            this.pBombRoot = GameObjectNodeMan.Find(GameObject.Name.BombRoot);
            Debug.Assert(this.pBombRoot != null);

            this.invadersBatch = SpriteBatchMan.Find(SpriteBatch.Name.SpaceInvaders);
            Debug.Assert(this.invadersBatch != null);

            this.boxBatch = SpriteBatchMan.Find(SpriteBatch.Name.Boxes);
            Debug.Assert(this.boxBatch != null);

            this.pRandom = pRandom;
            this.gameObjectType = gameObjectType;
            this.alienGrid = alienGrid;
            this.fallStrategy = fallStrategy;
            this.bombType = bombType;
            
        }

        override public void Execute(float deltaTime)
        {
            //Debug.WriteLine("event: {0}", deltaTime);

            // Create Bomb
            GameObject randomAlien = getRandomAlien();
            Bomb pBomb = new Bomb(gameObjectType, bombType, this.fallStrategy, randomAlien.x , randomAlien.y);
            //     Debug.WriteLine("----x:{0}", value);

            pBomb.ActivateCollisionSprite(this.boxBatch);
            pBomb.ActivateSprite(this.invadersBatch);

            // Attach the missile to the Bomb root
            GameObject pBombRoot = GameObjectNodeMan.Find(GameObject.Name.BombRoot);
            Debug.Assert(pBombRoot != null);

            // Add to GameObject Tree - {update and collisions}
            pBombRoot.Add(pBomb);

            int time = (int)deltaTime;
            this.pRandom.Next(time, time + 3);
            TimerEventMan.Add(TimerEvent.Name.BombSpawn, this, deltaTime);

        }
        public Component GetRandomColumn()
        {
            Random random = new Random();

            // Find number of columns left and select one at random by iterating random # times
            IteratorForwardComposite pFor = new IteratorForwardComposite(alienGrid);
            int columnsLeft = pFor.First().GetNumChildren();
            int n = random.Next(0, columnsLeft);
            Component column = IteratorForwardComposite.GetChild(alienGrid);

            for (int i = 0; i < n; i++)
            {
                column = IteratorForwardComposite.GetSibling(column);
            }

            return column;
        }

        private GameObject getRandomAlien()
        {
            // Get column and convert to something iterable
            Component randomColumn = GetRandomColumn();
            DLink pNode = IteratorForwardComposite.GetChild(randomColumn);

            // Now get the child in the last column
            while (pNode.pNext != null)
            {
                pNode = pNode.pNext;
            }

            return (GameObject)pNode;
        }


        readonly FallStrategy fallStrategy;
        GameObject.Name gameObjectType;
        public SpriteGame.Name bombType;
        readonly GameObject pBombRoot;
        readonly SpriteBatch invadersBatch;
        readonly SpriteBatch boxBatch;
        readonly AlienGrid alienGrid;
        public Random pRandom;
    }


    

}

// --- End of File ---
