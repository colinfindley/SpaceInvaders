using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class TimerEventMan : ManBase
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        private TimerEventMan(int reserveNum, int reserveGrow)
                : base(new SLinkMan(), new SLinkMan(), reserveNum, reserveGrow)   // <--- Kick the can (delegate)
        {
            // initialize derived data here
            TimerEventMan.psTimerEventCompare = new TimerEvent();
            Debug.Assert(TimerEventMan.psTimerEventCompare != null);
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
                psInstance = new TimerEventMan(reserveNum, reserveGrow);
            }
        }
        public static void Destroy(bool bPrintEnable = false)
        {
            TimerEventMan pMan = TimerEventMan.privGetInstance();
            Debug.Assert(pMan != null);

            // Do something clever here
            // track peak number of active nodes
            // print stats on destroy
            // invalidate the singleton
            if (bPrintEnable)
            {
                TimerEventMan.DumpStats();
            }
        }

        public static TimerEvent Add(TimerEvent.Name name, string pTimerEventName)
        {
            TimerEventMan pMan = TimerEventMan.privGetInstance();
            Debug.Assert(pMan != null);

            Debug.Assert(pTimerEventName != null);

            TimerEvent pTimerEvent = (TimerEvent)pMan.baseAdd();
            Debug.Assert(pTimerEvent != null);

            // Initialize the data
            pTimerEvent.Set(name, pTimerEventName);
            return pTimerEvent;
        }

        public static TimerEvent Find(TimerEvent.Name name)
        {
            TimerEventMan pMan = TimerEventMan.privGetInstance();
            Debug.Assert(pMan != null);

            // Compare functions only compares two TimerEvents

            // So:  Use the Compare TimerEvent - as a reference
            //      use in the Compare() function
            TimerEventMan.psTimerEventCompare.name = name;

            TimerEvent pData = (TimerEvent)pMan.baseFind(TimerEventMan.psTimerEventCompare);
            return pData;
        }
        public static void Remove(TimerEvent pTimerEvent)
        {
            TimerEventMan pMan = TimerEventMan.privGetInstance();
            Debug.Assert(pMan != null);

            Debug.Assert(pTimerEvent != null);
            pMan.baseRemove(pTimerEvent);
        }
        public static void Dump()
        {
            Debug.WriteLine("\n   ------ TimerEvent Man: ------");

            TimerEventMan pMan = TimerEventMan.privGetInstance();
            Debug.Assert(pMan != null);

            pMan.baseDump();
        }

        public static void DumpStats()
        {
            Debug.WriteLine("\n   ------ TimerEvent Man: ------");

            TimerEventMan pMan = TimerEventMan.privGetInstance();
            Debug.Assert(pMan != null);

            pMan.baseDumpStats();

            Debug.WriteLine("   ------------\n");
        }


        //----------------------------------------------------------------------
        // Override Abstract methods
        //----------------------------------------------------------------------
        override protected NodeBase derivedCreateNode()
        {
            NodeBase pNodeBase = new TimerEvent();
            Debug.Assert(pNodeBase != null);

            return pNodeBase;
        }

        //------------------------------------
        // Private methods
        //------------------------------------
        private static TimerEventMan privGetInstance()
        {
            // Safety - this forces users to call Create() first before using class
            Debug.Assert(psInstance != null);

            return psInstance;
        }

        //------------------------------------
        // Data: unique data for this manager 
        //------------------------------------
        private static TimerEvent psTimerEventCompare;
        private static TimerEventMan psInstance = null;
    }
}

// --- End of File ---
