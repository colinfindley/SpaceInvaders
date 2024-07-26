using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class UFOSpawnEvent : Command
    {
        public UFOSpawnEvent(Random pRandom)
        {
            this.pUFORoot = GameObjectNodeMan.Find(GameObject.Name.UFORoot);
            Debug.Assert(this.pUFORoot != null);

            this.invadersBatch = SpriteBatchMan.Find(SpriteBatch.Name.SpaceInvaders);
            Debug.Assert(this.invadersBatch != null);

            this.boxBatch = SpriteBatchMan.Find(SpriteBatch.Name.Boxes);
            Debug.Assert(this.boxBatch != null);

            this.pRandom = pRandom;
        }

        override public void Execute(float deltaTime)
        {
            // Create UFO
            SpawnUFO();

            // Add it back at a random time
            deltaTime = pRandom.Next(20, 30);
            float bombDelayTime = pRandom.Next(1, 4);
            DelayBombCmd delayBomb = new DelayBombCmd(pUFO);
            TimerEventMan.Add(TimerEvent.Name.DelayBomb, delayBomb, bombDelayTime);
            TimerEventMan.Add(TimerEvent.Name.UFOSpawn, this, deltaTime);

        }

        private void SpawnUFO()
        {

            // No need to re-calling new()
            UFO pUFO = null;
            GameObjectNode pGameObjNode = GhostMan.Find(GameObject.Name.UFO);
            if (pGameObjNode == null)
            {
                pUFO = new UFO();
            }
            else
            {
                // Recycle it.
                pUFO = (UFO)pGameObjNode.pGameObj;
                GhostMan.Remove(pGameObjNode);
                // GhostMan.Dump();
                pUFO.Resurrect();
            }

            this.pUFO = pUFO;

            // Attached to SpriteBatches
            SpriteBatch pSB_Aliens = SpriteBatchMan.Find(SpriteBatch.Name.SpaceInvaders);
            SpriteBatch pSB_Boxes = SpriteBatchMan.Find(SpriteBatch.Name.Boxes);

            pUFO.ActivateCollisionSprite(pSB_Boxes);
            pUFO.ActivateSprite(pSB_Aliens);

            // Attach the UFO to the UFO root
            GameObject pUFORoot = GameObjectNodeMan.Find(GameObject.Name.UFORoot);
            Debug.Assert(pUFORoot != null);

            // Add to GameObject Tree - {update and collisions}
            pUFORoot.Add(this.pUFO);
            SoundNodeMan.Play(SoundNode.Name.UFO_Low_Pitch);
        }

        GameObject pUFORoot;
        UFO pUFO;
        SpriteBatch invadersBatch;
        SpriteBatch boxBatch;
        Random pRandom;
    }
}