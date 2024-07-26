//-----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------- 

namespace SpaceInvaders
{
    class SpriteGameProxyNull : SpriteGameProxy
    {
        public SpriteGameProxyNull()
            : base(SpriteGameProxy.Name.NullObject)
        {

        }

        public override void Render()
        {
            // do nothing
        }

        public override void Update()
        {
            // do nothing
        }
    }
}

// --- End of File ---
