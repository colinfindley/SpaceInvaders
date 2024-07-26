//-----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipMan
    {
        public enum MissileState
        {
            Ready,
            Flying
        }

        public enum MoveState
        {
            MoveRight,
            MoveLeft,
            MoveBoth
        }

        public ShipMan()
        {
            // Store the states
            this.pStateMissileReady = new ShipMissileReady();
            this.pStateMissileFlying = new ShipMissileFlying();
           
            this.pStateMoveBoth = new ShipMoveBoth();
            this.pStateMoveRight = new ShipMoveRight();
            this.pStateMoveLeft = new ShipMoveLeft();

            // set active
            this.pShip = null;
            this.pMissile = null;
            ShipMan.psActiveSBMan = null;
        }

        public static void Create()
        {
            // make sure its the first time
            //Debug.Assert(instance == null);

            // Do the initialization
            if (instance == null)
            {
                instance = new ShipMan();
            }

            Debug.Assert(instance != null);
        }

        private static ShipMan privInstance()
        {
            Debug.Assert(instance != null);

            return instance;
        }

        public static void SetActive(ShipMan pSBMan)
        {
            ShipMan pMan = ShipMan.privInstance();
            Debug.Assert(pMan != null);

            Debug.Assert(pSBMan != null);
            ShipMan.psActiveSBMan = pSBMan;
            // Stuff to initialize after the instance was created
            psActiveSBMan.pShip = ActivateShip();
            psActiveSBMan.pShip.SetState(ShipMan.MoveState.MoveBoth);
            psActiveSBMan.pShip.SetState(ShipMan.MissileState.Ready);
        }

        public static Ship GetShip()
        {
            ShipMan pShipMan = ShipMan.psActiveSBMan;

            Debug.Assert(pShipMan != null);
            Debug.Assert(pShipMan.pShip != null);

            return pShipMan.pShip;
        }

        public static ShipMissileState GetState(MissileState state)
        {
            ShipMan pShipMan = ShipMan.psActiveSBMan;
            Debug.Assert(pShipMan != null);

            ShipMissileState pShipState = null;

            switch (state)
            {
                case ShipMan.MissileState.Ready:
                    pShipState = pShipMan.pStateMissileReady;
                    break;

                case ShipMan.MissileState.Flying:
                    pShipState = pShipMan.pStateMissileFlying;
                    break;

                default:
                    Debug.Assert(false);
                    break;
            }

            return pShipState;
        }
        public static ShipMoveState GetState(MoveState state)
        {
            ShipMan pShipMan = ShipMan.psActiveSBMan;
            Debug.Assert(pShipMan != null);

            ShipMoveState pShipState = null;

            switch (state)
            {
                case ShipMan.MoveState.MoveBoth:
                    pShipState = pShipMan.pStateMoveBoth;
                    break;

                case ShipMan.MoveState.MoveLeft:
                    pShipState = pShipMan.pStateMoveLeft;
                    break;

                case ShipMan.MoveState.MoveRight:
                    pShipState = pShipMan.pStateMoveRight;
                    break;

                default:
                    Debug.Assert(false);
                    break;
            }

            return pShipState;
        }

        public static Missile GetMissile()
        {
            ShipMan pShipMan = ShipMan.psActiveSBMan;

            Debug.Assert(pShipMan != null);
            Debug.Assert(pShipMan.pMissile != null);

            return pShipMan.pMissile;
        }

        public static Missile ActivateMissile()
        {
            ShipMan pShipMan = ShipMan.psActiveSBMan;
            Debug.Assert(pShipMan != null);

            // No need to re-calling new()
            Missile pMissile = null;
            GameObjectNode pGameObjNode = GhostMan.Find(GameObject.Name.Missile);
            if (pGameObjNode == null)
            {
                pMissile = new Missile(SpriteGame.Name.Missile, 336, 100);
            }
            else
            { 
                // Recycle it.
                pMissile = (Missile)pGameObjNode.pGameObj;
                GhostMan.Remove(pGameObjNode);
               // GhostMan.Dump();
                pMissile.Resurrect(400,100);
            }

            pShipMan.pMissile = pMissile;

            // Attached to SpriteBatches
            SpriteBatch pSB_Aliens = SpriteBatchMan.Find(SpriteBatch.Name.SpaceInvaders);
            SpriteBatch pSB_Boxes = SpriteBatchMan.Find(SpriteBatch.Name.Boxes);

            pMissile.ActivateCollisionSprite(pSB_Boxes);
            pMissile.ActivateSprite(pSB_Aliens);

            // Attach the missile to the missile root
            GameObject pMissileGroup = GameObjectNodeMan.Find(GameObject.Name.MissileGroup);
            Debug.Assert(pMissileGroup != null);

            // Add to GameObject Tree - {update and collisions}
            pMissileGroup.Add(pShipMan.pMissile);

            return pShipMan.pMissile;
        }


        public static void RespawnShip()
        {
            SpriteBatch pSB_Ship = SpriteBatchMan.Find(SpriteBatch.Name.Ship);
            SpriteBatch pSB_ShipBox = SpriteBatchMan.Find(SpriteBatch.Name.ShipBox);
            Ship pShip = ShipMan.psActiveSBMan.pShip;
            pShip.poColObj.poColRect.Set(pShip.x, pShip.y, 39, 24);
            pShip.shipDead = false;
            pSB_Ship.SetDrawEnable(true);

            //Bomb vs Ship
    

        }

        public static void HideShip()
        {
            SpriteBatch pSB_Ship = SpriteBatchMan.Find(SpriteBatch.Name.Ship);
            SpriteBatch pSB_ShipBox = SpriteBatchMan.Find(SpriteBatch.Name.ShipBox);
            Ship pShip = ShipMan.psActiveSBMan.pShip;
            pShip.poColObj.poColRect.Set(0, 0, 0, 0);
            pSB_Ship.SetDrawEnable(false);
            pShip.shipDead = true;
        }


        public static Ship ActivateShip()
        {
            ShipMan pShipMan = ShipMan.psActiveSBMan;
            Debug.Assert(pShipMan != null);


            // copy over safe copy
            // LTN - owned by ShipMan.. but needs some cleanup

            Ship pShip = new Ship(GameObject.Name.Ship, SpriteGame.Name.Ship, 336, 90);
            SpriteBatch pSB_Aliens = SpriteBatchMan.Find(SpriteBatch.Name.Ship);
            SpriteBatch pSB_Boxes = SpriteBatchMan.Find(SpriteBatch.Name.ShipBox);

            pShip.ActivateCollisionSprite(pSB_Boxes);
            pShip.ActivateSprite(pSB_Aliens);
            pShipMan.pShip = pShip;

            // Attach the sprite to the correct sprite batch
            //pSB_Aliens.Attach(pShip);

            // Attach the missile to the missile root
            GameObject pShipRoot = GameObjectNodeMan.Find(GameObject.Name.ShipRoot);
            Debug.Assert(pShipRoot != null);

            // Add to GameObject Tree - {update and collisions}
            pShipRoot.Add(pShipMan.pShip);

            return pShipMan.pShip;
        }

        // Data: ----------------------------------------------
        private static ShipMan instance = null;
        private static ShipMan psActiveSBMan = null;
        // Active
        private Ship pShip;
        private Missile pMissile;

        // Reference
        private ShipMissileReady pStateMissileReady;
        private ShipMissileFlying pStateMissileFlying;

        private ShipMoveBoth pStateMoveBoth;
        private ShipMoveRight pStateMoveRight;
        private ShipMoveLeft pStateMoveLeft;
    }
}

// --- End of File ---
