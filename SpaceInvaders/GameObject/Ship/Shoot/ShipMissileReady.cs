//-----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShipMissileReady : ShipMissileState
    {

        public override void ShootMissile(Ship pShip)
        {
            Missile pMissile = ShipMan.ActivateMissile();
            pMissile.SetPos(pShip.x, pShip.y + 20);

            pShip.SetState(ShipMan.MissileState.Flying);
            SoundNodeMan.Play(SoundNode.Name.Shoot);
        }
    }
}

// --- End of File ---
