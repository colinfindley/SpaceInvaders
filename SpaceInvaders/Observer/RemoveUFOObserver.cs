using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class RemoveUFOObserver : ColObserver
    {
        public RemoveUFOObserver()
        {
            this.pUFO = null;
        }
        public RemoveUFOObserver(RemoveUFOObserver b)
        {
            Debug.Assert(b != null);
            this.pUFO = b.pUFO;
        }

        public override void Notify()
        {
            // Delete missile
            //   Debug.WriteLine("RemoveUFOObserver: {0} {1}", this.pSubject.pObjA, this.pSubject.pObjB);


            this.pUFO = (UFOCategory)this.pSubject.pObjB;

            //    Debug.WriteLine(" brick {0}  parent {1}", this.pUFO, this.pUFO.pParent);

            Debug.Assert(this.pUFO != null);

            if (pUFO.bMarkForDeath == false)
            {
                pUFO.bMarkForDeath = true;
                //   Delay
                RemoveUFOObserver pObserver = new RemoveUFOObserver(this);
                DelayedObjectMan.Attach(pObserver);
            }
            else
            {
                pUFO.bMarkForDeath = true;
            }
        }
        public override void Execute()
        {
            this.pUFO.Remove();
            this.pUFO.AddScore();
            this.pUFO.UpdateHighScore();
            SoundNodeMan.Play(SoundNode.Name.UFO_High_Pitch);
            ExplosionMan.Explode(GameObject.Name.AlienExplosion, pUFO.x, pUFO.y, .1f);
        }

        override public void Dump()
        {

        }
        override public System.Enum GetName()
        {
            return ColObserver.Name.RemoveUFOObserver;
        }



        // -------------------------------------------
        // data:
        // -------------------------------------------

        private GameObject pUFO;
    }
}

// --- End of File ---