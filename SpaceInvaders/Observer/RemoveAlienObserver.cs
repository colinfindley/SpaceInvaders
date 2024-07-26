using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class RemoveAlienObserver : ColObserver
    {

        public RemoveAlienObserver(AlienGrid _pAlienGrid)
        {
            this.pAlien = null;
            this.pAlienGrid = _pAlienGrid;
        }
        public RemoveAlienObserver(RemoveAlienObserver b)
        {
            Debug.Assert(b != null);
            this.pAlien = b.pAlien;
            this.pAlienGrid = b.pAlienGrid;
        }

        public override void Notify()
        {
            // Delete missile
            //   Debug.WriteLine("RemoveAlienObserver: {0} {1}", this.pSubject.pObjA, this.pSubject.pObjB);


            this.pAlien = (AlienCategory)this.pSubject.pObjB;

            //    Debug.WriteLine(" brick {0}  parent {1}", this.pAlien, this.pAlien.pParent);

            Debug.Assert(this.pAlien != null);

            if (pAlien.bMarkForDeath == false)
            {
                pAlien.bMarkForDeath = true;
                //   Delay
                RemoveAlienObserver pObserver = new RemoveAlienObserver(this);
                DelayedObjectMan.Attach(pObserver);
            }
            else
            {
                pAlien.bMarkForDeath = true;
            }
        }
        public override void Execute()
        {
            // Delete obsolete parents
            GameObject pA = (GameObject)this.pAlien;
            GameObject pB = (GameObject)IteratorForwardComposite.GetParent(pA);
            GameObject pC = (GameObject)IteratorForwardComposite.GetParent(pB);


            // Root - do not delete
            //GameObject pD = (GameObject)IteratorForwardComposite.GetParent(pC);

            // Alien
            if (pA.GetNumChildren() == 0)
            {
                Debug.Assert(pA.pParent != null);
                pA.AddScore();
                pA.UpdateHighScore();
                pA.Remove();


                // Decrement alien count
                this.pAlienGrid.alienCount--;

                // Make it Go BOOM!
                SoundNodeMan.Play(SoundNode.Name.AlienDeath);
                ExplosionMan.Explode(GameObject.Name.AlienExplosion, pA.x, pA.y, .1f);

                // Aliens go faster now - both movement and animation
                TimerEventMan.IncreaseSpeed();
                
            }

            // Column 
            if (pB.GetNumChildren() == 0)
            {
                pB.Remove();

            }

            // Grid 
            if (pC.GetNumChildren() == 0)
            {
                this.pAlienGrid.RespawnAliens();
                TimerEventMan.IncreaseBombSpeed(.9f);
            }
        }

        private bool privCheckParent(GameObject pObj)
        {
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(pObj);
            if (pGameObj == null)
            {
                return true;
            }

            return false;
        }
        override public void Dump()
        {

        }
        override public System.Enum GetName()
        {
            return ColObserver.Name.RemoveAlienObserver;
        }



        // -------------------------------------------
        // data:
        // -------------------------------------------

        private GameObject pAlien;
        private AlienGrid pAlienGrid;
    }
}

// --- End of File ---


