//-----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ResurrectShipCmd : Command
    {
        public ResurrectShipCmd()
        {
        }

        public override void Execute(float deltaTime)
        {
            ShipMan.RespawnShip();
        }

    }
}

// --- End of File ---
