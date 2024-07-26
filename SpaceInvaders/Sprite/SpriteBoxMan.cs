//-----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------- 

using System.Diagnostics;

namespace SpaceInvaders
{
    class SpriteBoxMan : ManBase
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        public SpriteBoxMan(int reserveNum = 8, int reserveGrow = 1)
                // LTN - this
                : base(new DLinkMan(), new DLinkMan(), reserveNum, reserveGrow)   // <--- Kick the can (delegate)
        {
            SpriteBoxMan.psActiveSBMan = null;
        }

        //----------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------
        public static void Create(int reserveNum = 8, int reserveGrow = 1)
        {
            // make sure values are ressonable 
            Debug.Assert(reserveNum >= 0);
            Debug.Assert(reserveGrow > 0);

            // initialize the singleton here
            Debug.Assert(psInstance == null);

            // Do the initialization
            if (psInstance == null)
            {
                psInstance = new SpriteBoxMan(reserveNum, reserveGrow); // LTN - this
            }

            
        }
        public static void Destroy(bool bPrintEnable = false)
        {
            SpriteBoxMan pMan = SpriteBoxMan.psActiveSBMan;
            Debug.Assert(pMan != null);

            // Do something clever here
            // track peak number of active nodes
            // print stats on destroy
            // invalidate the singleton
            if (bPrintEnable)
            {
                SpriteBoxMan.DumpStats();
            }
        }
        public static SpriteBox Add(SpriteBox.Name name, float x, float y, float width, float height, Azul.Color pColor = null)
        {
            SpriteBoxMan pMan = SpriteBoxMan.psActiveSBMan;
            Debug.Assert(pMan != null);

            SpriteBox pNode = (SpriteBox)pMan.baseAdd();
            Debug.Assert(pNode != null);

            pNode.Set(name, x, y, width, height, pColor);

            return pNode;
        }

        public static void SetActive(SpriteBoxMan pSBMan)
        {
            SpriteBoxMan pMan = SpriteBoxMan.privGetInstance();
            Debug.Assert(pMan != null);

            Debug.Assert(pSBMan != null);
            SpriteBoxMan.psActiveSBMan = pSBMan;
        }

        public static SpriteBox Find(SpriteBox.Name name)
        {
            SpriteBoxMan pMan = SpriteBoxMan.psActiveSBMan;
            Debug.Assert(pMan != null);

            // Compare functions only compares two Sprites

            // So:  Use the Compare Sprite - as a reference
            //      use in the Compare() function
            SpriteBoxMan.psSpriteBoxCompare.name = name;

            SpriteBox pData = (SpriteBox)pMan.baseFind(SpriteBoxMan.psSpriteBoxCompare);
            return pData;
        }
        public static void Remove(SpriteBox pSpriteBox)
        {
            SpriteBoxMan pMan = SpriteBoxMan.psActiveSBMan;
            Debug.Assert(pMan != null);

            Debug.Assert(pSpriteBox != null);
            pMan.baseRemove(pSpriteBox);
        }
        public static void Dump()
        {
            Debug.WriteLine("\n   ------ SpriteBox Man: ------");

            SpriteBoxMan pMan = SpriteBoxMan.psActiveSBMan;
            Debug.Assert(pMan != null);

            pMan.baseDump();
        }
        public static void DumpStats()
        {
            Debug.WriteLine("\n   ------ SpriteBox Man: ------");

            SpriteBoxMan pMan = SpriteBoxMan.psActiveSBMan;
            Debug.Assert(pMan != null);

            pMan.baseDumpStats();

            Debug.WriteLine("   ------------\n");
        }

        //----------------------------------------------------------------------
        // Override Abstract methods
        //----------------------------------------------------------------------
        override protected NodeBase derivedCreateNode()
        {
            // LTN - active/reserve DLink list
            NodeBase pNodeBase = new SpriteBox();
            Debug.Assert(pNodeBase != null);

            return pNodeBase;
        }

        //------------------------------------
        // Private methods
        //------------------------------------
        private static SpriteBoxMan privGetInstance()
        {
            // Safety - this forces users to call Create() first before using class
            Debug.Assert(psInstance != null);

            return psInstance;
        }

        //------------------------------------
        // Data: unique data for this manager 
        //------------------------------------
        private static SpriteBox psSpriteBoxCompare = new SpriteBox();
        private static SpriteBoxMan psInstance = null;
        private static SpriteBoxMan psActiveSBMan = null;

    }
}

// --- End of File ---
