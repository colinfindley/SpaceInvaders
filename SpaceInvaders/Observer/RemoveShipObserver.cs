using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class RemoveShipObserver : ColObserver
    {
        public RemoveShipObserver(AlienGrid alienGrid, GameObject leftShip, GameObject middleShip, GameObject rightShip)
        {
            this.pShip = null;
            this.leftShip = leftShip;
            this.middleShip = middleShip;
            this.rightShip = rightShip;
            this.alienGrid = alienGrid;
        }
        public RemoveShipObserver(RemoveShipObserver b, AlienGrid alienGrid, GameObject leftShip, GameObject middleShip, GameObject rightShip)
        {
            Debug.Assert(b != null);
            this.pShip = b.pShip;
            this.leftShip = leftShip;
            this.middleShip = middleShip;
            this.rightShip = rightShip;
            this.alienGrid = alienGrid;
        }

        public override void Notify()
        {
            // Delete missile
            //   Debug.WriteLine("RemoveShipObserver: {0} {1}", this.pSubject.pObjA, this.pSubject.pObjB);


            this.pShip = (ShipCategory)this.pSubject.pObjB;

            //    Debug.WriteLine(" brick {0}  parent {1}", this.pShip, this.pShip.pParent);

            Debug.Assert(this.pShip != null);

            if (pShip.bMarkForDeath == false)
            {
                pShip.bMarkForDeath = true;
                //   Delay
                RemoveShipObserver pObserver = new RemoveShipObserver(this, this.alienGrid, this.leftShip, this.middleShip, this.rightShip);
                DelayedObjectMan.Attach(pObserver);
            }
            else
            {
                pShip.bMarkForDeath = true;
            }
        }
        public override void Execute()
        {
            // Disable Draw and Disable movement but don't delete ship
            ShipMan.HideShip();
            SoundNodeMan.Play(SoundNode.Name.Explode);
            ExplosionMan.Explode(GameObject.Name.PlayerExplosion, pShip.x, pShip.y, 2f);

            // Update lives
            int livesLeft = SceneContext.GetLivesLeftInt();
            livesLeft -= 1;
            SceneContext.SetLivesLeft(livesLeft);
            
            // Change message
            Font life = FontMan.Find(Font.Name.LivesLeft);
            life.UpdateMessage(livesLeft.ToString());
            

            // Ressurect that ship
            ResurrectShipCmd resurrect = new ResurrectShipCmd();
            pShip.bMarkForDeath = false;

            if (livesLeft == 2)
            {
                // Delete the backup ships which are props
                this.rightShip.Remove();

                TimerEventMan.Add(TimerEvent.Name.ResurrectShip, resurrect, 1f);


            } else if (livesLeft == 1)
            {
                this.middleShip.Remove();
                TimerEventMan.Add(TimerEvent.Name.ResurrectShip, resurrect, 1f);

            } else 
            {
                this.leftShip.Remove();
                SceneContext.roundCount++;
                SceneContext.SetLivesLeft(3);
                // Game Over
                SceneContext.SetState(SceneContext.Scene.Over);
            }

        }

        override public void Dump()
        {

        }
        override public System.Enum GetName()
        {
            return ColObserver.Name.RemoveShipObserver;
        }



        // -------------------------------------------
        // data:
        // -------------------------------------------

        private GameObject pShip;
        private AlienGrid alienGrid;
        private GameObject leftShip;
        private GameObject middleShip;
        private GameObject rightShip;
    }
}

// --- End of File ---