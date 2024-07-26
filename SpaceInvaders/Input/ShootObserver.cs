//-----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShootObserver : InputObserver
    {
        public override void Notify()
        {
            //Debug.WriteLine("Shoot Observer");
            Ship pShip = ShipMan.GetShip();
            if (pShip == null)
            {
                return;
            }

            pShip.ShootMissile();
        }
        override public void Dump()
        {
            Debug.Assert(false);
        }
        override public System.Enum GetName()
        {
            return Name.ShootObserver;
        }
    }
}

// --- End of File ---
