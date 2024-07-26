//-----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class DeleteSpriteCmd : Command
    {
        public DeleteSpriteCmd(GameObject _pGameObject)
        {
            this.pGameObject = _pGameObject;
        }

        public override void Execute(float deltaTime)
        {
            this.pGameObject.Remove();
        }

        GameObject pGameObject;
    }
}

// --- End of File ---


