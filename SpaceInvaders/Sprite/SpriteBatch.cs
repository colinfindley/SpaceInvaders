//-----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------- 

using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteBatch : DLink
    {
        //------------------------------------
        // Enum
        //------------------------------------
        public enum Name
        {
            SpaceInvaders,
            Boxes,
            Texts,
            Shields,
            Uninitialized,
            Aesthetics,
            Explosions,
            Ship,
            ShipBox
        }

        //------------------------------------
        // Constructors
        //------------------------------------
        public SpriteBatch()
            : base()
        {
            this.name = SpriteBatch.Name.Uninitialized;
            // LTN - this
            this.poSpriteNodeMan = new SpriteNodeMan();
            Debug.Assert(this.poSpriteNodeMan != null);

            this.DrawEnable = true;
        }

        //------------------------------------
        // Methods
        //------------------------------------
        public void Set(SpriteBatch.Name name, int reserveNum = 3, int reserveGrow = 1, float _priority = 0)
        {
            this.name = name;
            this.priority = _priority;
            this.poSpriteNodeMan.Set(name, reserveNum, reserveGrow);
        }

        public void SetName(SpriteBatch.Name inName)
        {
            this.name = inName;
        }

        public SpriteNodeMan GetSpriteNodeMan()
        {
            return this.poSpriteNodeMan;
        }

        public SpriteNode Attach(SpriteBase pNode)
        {
            SpriteNode pSBNode = this.poSpriteNodeMan.Attach(pNode);
            return pSBNode;
        }
        public SpriteNode Attach(GameObject pGameObj)
        {
            Debug.Assert(pGameObj != null);
            SpriteNode pNode = this.poSpriteNodeMan.Attach(pGameObj.pSpriteProxy);


            // Initialize SpriteBatchNode
            pNode.Set(pGameObj.pSpriteProxy, this.poSpriteNodeMan);

            // Back pointer
            this.poSpriteNodeMan.SetSpriteBatch(this);

            return pNode;
        }


        override public float getPriority()
        {
            return this.priority;
        }

        private void privClear()
        {

        }

        //------------------------------------
        // Override
        //------------------------------------
        public override System.Enum GetName()
        {
            return this.name;
        }
        override public void Wash()
        {
            this.baseClear();
            this.privClear();
        }
        override public void Dump()
        {
            // we are using HASH code as its unique identifier 
            Debug.WriteLine("   {0} ({1})", this.name, this.GetHashCode());

            // Data:
            Debug.WriteLine("   Name: {0} ({1})", this.name, this.GetHashCode());

            // Let the base print its contribution
            this.baseDump();
        }
        public void SetDrawEnable(bool status)
        {
            this.DrawEnable = status;
        }
        public bool GetDrawEnable()
        {
            return this.DrawEnable;
        }
        //------------------------------------
        // Data
        //------------------------------------
        private bool DrawEnable;
        public SpriteBatch.Name name;
        private readonly SpriteNodeMan poSpriteNodeMan;

    }
}

// --- End of File ---
