
using System;
using System.Diagnostics;

namespace SpaceInvaders
{

    abstract public class ColObserver : SLink
    {
        //------------------------------------
        // Enum
        //------------------------------------
        public enum Name
        {
            SoundObserver,
            GridObserver,
            ShipReadyObserver,
            ShipRemoveMissileObserver,
            ShipMoveObserver,
            BombObserver,
            AlienObserver,

            RemoveAlienObserver,
            RemoveBrickObserver,
            RemoveMissileObserver,
            RemoveBombObserver,
            RemoveShipObserver,

            Uninitialized,
            RemoveUFOObserver,
        }
        public abstract void Notify();

        // WHY not add a Command pattern into our Observer!
        public virtual void Execute()
        {
            // default implementation
        }

        override public void Wash()
        {
            Debug.Assert(false);
        }

        public ColSubject pSubject;
    }


}

// --- End of File ---
