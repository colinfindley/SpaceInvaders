//-----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------- 

using System.Diagnostics;

namespace SpaceInvaders
{
    class DelayedObjectMan
    {
        public static void SetActive(DelayedObjectMan pSBMan)
        {
            DelayedObjectMan pMan = DelayedObjectMan.privGetInstance();
            Debug.Assert(pMan != null);

            Debug.Assert(pSBMan != null);
            DelayedObjectMan.psActiveSBMan = pSBMan;
        }

        static public void Attach(ColObserver pObserver)
        {
            Debug.Assert(pObserver != null);
            DelayedObjectMan pDelayMan = psActiveSBMan;

            pDelayMan.poSLinkMan.AddToFront(pObserver);
        }

        static public void Process()
        {
            DelayedObjectMan pDelayMan = DelayedObjectMan.psActiveSBMan;
            Iterator pIt = pDelayMan.poSLinkMan.GetIterator();

            ColObserver pNode = null;
            for (pIt.First(); !pIt.IsDone(); pIt.Next())
            {
                pNode = (ColObserver)pIt.Current();
                Debug.Assert(pNode != null);
                pNode.Execute();
            }

            // remove
            pNode = (ColObserver)pIt.First();
            while (!pIt.IsDone())
            {
                ColObserver pTmp = pNode;
                pNode = (ColObserver)pIt.Next();

                // remove
                pDelayMan.poSLinkMan.Remove(pTmp);
            }
        }
        public DelayedObjectMan()
        {
            DelayedObjectMan.psActiveSBMan = null;
        }

        public static void Create()
        {
            // initialize the singleton here
            Debug.Assert(psInstance == null);

            // Do the initialization
            if (psInstance == null)
            {
                psInstance = new DelayedObjectMan();
            }
        }

        private static DelayedObjectMan privGetInstance()
        {

            // Safety - this forces users to call create first
            Debug.Assert(psInstance != null);

            return psInstance;
        }

        // -------------------------------------------
        // Data: 
        // -------------------------------------------

        private SLinkMan poSLinkMan = new SLinkMan();
        private static DelayedObjectMan psInstance = null;
        private static DelayedObjectMan psActiveSBMan;
    }
}

// --- End of File ---
