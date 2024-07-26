using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteGameProxyMan : ManBase
    {

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        private SpriteGameProxyMan(int reserveNum, int reserveGrow)
                : base(new SLinkMan(), new SLinkMan(), reserveNum, reserveGrow)   // <--- Kick the can (delegate)
        {
            // initialize derived data here
            SpriteGameProxyMan.psSpriteGameProxyCompare = new SpriteGameProxy();
            Debug.Assert(SpriteGameProxyMan.psSpriteGameProxyCompare != null);
        }

        //----------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------
        public static void Create(int reserveNum = 3, int reserveGrow = 1)
        {
            // make sure values are ressonable 
            Debug.Assert(reserveNum >= 0);
            Debug.Assert(reserveGrow > 0);

            // initialize the singleton here
            Debug.Assert(psInstance == null);

            // Do the initialization
            if (psInstance == null)
            {
                psInstance = new SpriteGameProxyMan(reserveNum, reserveGrow);
            }
        }
        public static void Destroy(bool bPrintEnable = false)
        {
            SpriteGameProxyMan pMan = SpriteGameProxyMan.privGetInstance();
            Debug.Assert(pMan != null);

            // Do something clever here
            // track peak number of active nodes
            // print stats on destroy
            // invalidate the singleton
            if (bPrintEnable)
            {
                SpriteGameProxyMan.DumpStats();
            }
        }

        public static SpriteGameProxy Add(SpriteGameProxy.Name name, string pSpriteGameProxyName)
        {
            SpriteGameProxyMan pMan = SpriteGameProxyMan.privGetInstance();
            Debug.Assert(pMan != null);

            Debug.Assert(pSpriteGameProxyName != null);

            SpriteGameProxy pSpriteGameProxy = (SpriteGameProxy)pMan.baseAdd();
            Debug.Assert(pSpriteGameProxy != null);

            // Initialize the data
            pSpriteGameProxy.Set(name, pSpriteGameProxyName);
            return pSpriteGameProxy;
        }

        public static SpriteGameProxy Find(SpriteGameProxy.Name name)
        {
            SpriteGameProxyMan pMan = SpriteGameProxyMan.privGetInstance();
            Debug.Assert(pMan != null);

            // Compare functions only compares two SpriteGameProxys

            // So:  Use the Compare SpriteGameProxy - as a reference
            //      use in the Compare() function
            SpriteGameProxyMan.psSpriteGameProxyCompare.name = name;

            SpriteGameProxy pData = (SpriteGameProxy)pMan.baseFind(SpriteGameProxyMan.psSpriteGameProxyCompare);
            return pData;
        }
        public static void Remove(SpriteGameProxy pSpriteGameProxy)
        {
            SpriteGameProxyMan pMan = SpriteGameProxyMan.privGetInstance();
            Debug.Assert(pMan != null);

            Debug.Assert(pSpriteGameProxy != null);
            pMan.baseRemove(pSpriteGameProxy);
        }
        public static void Dump()
        {
            Debug.WriteLine("\n   ------ SpriteGameProxy Man: ------");

            SpriteGameProxyMan pMan = SpriteGameProxyMan.privGetInstance();
            Debug.Assert(pMan != null);

            pMan.baseDump();
        }

        public static void DumpStats()
        {
            Debug.WriteLine("\n   ------ SpriteGameProxy Man: ------");

            SpriteGameProxyMan pMan = SpriteGameProxyMan.privGetInstance();
            Debug.Assert(pMan != null);

            pMan.baseDumpStats();

            Debug.WriteLine("   ------------\n");
        }


        //----------------------------------------------------------------------
        // Override Abstract methods
        //----------------------------------------------------------------------
        override protected NodeBase derivedCreateNode()
        {
            NodeBase pNodeBase = new SpriteGameProxy();
            Debug.Assert(pNodeBase != null);

            return pNodeBase;
        }

        //------------------------------------
        // Private methods
        //------------------------------------
        private static SpriteGameProxyMan privGetInstance()
        {
            // Safety - this forces users to call Create() first before using class
            Debug.Assert(psInstance != null);

            return psInstance;
        }

        //------------------------------------
        // Data: unique data for this manager 
        //------------------------------------
        private static SpriteGameProxy psSpriteGameProxyCompare;
        private static SpriteGameProxyMan psInstance = null;
    }
}

// --- End of File ---
