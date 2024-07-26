//-----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------- 

using System.Diagnostics;

namespace SpaceInvaders
{
    class AnimationCmd : Command
    {
        public AnimationCmd(SpriteGame.Name spriteName, TimerEvent.Name animationType)
        {
            // initialized the sprite animation is attached to
            this.pSprite = SpriteGameMan.Find(spriteName);
            Debug.Assert(this.pSprite != null);

            this.poSLinkMan = new SLinkMan(); // LTN - this
            Debug.Assert(this.poSLinkMan != null);

            // need to keep iterator for state
            this.pIt = this.poSLinkMan.GetIterator();
            Debug.Assert(this.pIt != null);

            this.animationType = animationType;
        }

        public void Attach(Image.Name imageName)
        {
            // Get the image
            Image pImage = ImageMan.Find(imageName);
            Debug.Assert(pImage != null);

            // Create a new holder
            ImageNode pImageHolder = new ImageNode(pImage); // LTN - SLinkMan
            Debug.Assert(pImageHolder != null);

            // Attach it to the Animation Sprite ( Push to front )
            this.poSLinkMan.AddToFront(pImageHolder);

            // update the iterator
            this.pIt = this.poSLinkMan.GetIterator();
            Debug.Assert(this.pIt != null);
        }

        public override void Execute(float deltaTime)
        {
            // Wrap if at end of iteration list
            if (this.pIt.IsDone())
            {
                this.pIt.First();
            }

            // Get the image
            ImageNode pImageNode = (ImageNode)this.pIt.Current();
            Debug.Assert(pImageNode != null);

            // advance for next iteration
            this.pIt.Next();

            // change image
            this.pSprite.SwapImage(pImageNode.pImage);

            // Add itself back to timer
            TimerEventMan.Add(animationType, this, deltaTime);
        }

        // Data: ---------------
        private TimerEvent.Name animationType;
        private SpriteGame pSprite;
        private SLinkMan poSLinkMan;
        private Iterator pIt;
    }

}

// --- End of File ---
