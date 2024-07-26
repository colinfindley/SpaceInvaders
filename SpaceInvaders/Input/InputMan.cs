//-----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class InputMan
    {
        public InputMan()
        {
            this.poSubjectArrowLeft = new InputSubject();
            this.poSubjectArrowRight = new InputSubject();
            this.poSubjectSpace = new InputSubject();
            InputMan.psActiveInputMan = null;
            this.privSpaceKeyPrev = false;
        }

        private static InputMan privGetInstance()
        {
            if (pInstance == null)
            {
                pInstance = new InputMan();
            }
            Debug.Assert(pInstance != null);

            return pInstance;
        }

        public static void SetActive(InputMan pSBMan)
        {
            Debug.Assert(pSBMan != null);
            InputMan.psActiveInputMan = pSBMan;
        }

        public static InputSubject GetArrowRightSubject()
        {
            InputMan pMan = InputMan.psActiveInputMan;
            return pMan.poSubjectArrowRight;
        }

        public static InputSubject GetArrowLeftSubject()
        {
            InputMan pMan = InputMan.psActiveInputMan;
            return pMan.poSubjectArrowLeft;
        }

        public static InputSubject GetSpaceSubject()
        {
            InputMan pMan = InputMan.psActiveInputMan;
            return pMan.poSubjectSpace;
        }

        public static void Update()
        {
            InputMan pMan = InputMan.psActiveInputMan;

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_U))
            {
                SpriteBatch pSB = SpriteBatchMan.Find(SpriteBatch.Name.Boxes);
                SpriteBatch pSB1 = SpriteBatchMan.Find(SpriteBatch.Name.ShipBox);
                Debug.Assert(pSB != null);
                pSB.SetDrawEnable(false);
                pSB1.SetDrawEnable(false);
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_B))
            {
                SpriteBatch pSB = SpriteBatchMan.Find(SpriteBatch.Name.Boxes);
                SpriteBatch pSB1 = SpriteBatchMan.Find(SpriteBatch.Name.ShipBox);
                Debug.Assert(pSB != null);
                pSB.SetDrawEnable(true);
                pSB1.SetDrawEnable(true);
            }

            // LeftKey: (no history) -----------------------------------------------------------
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_LEFT) == true)
            {
                pMan.poSubjectArrowLeft.Notify();
            }

            // RightKey: (no history) -----------------------------------------------------------
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_RIGHT) == true)
            {
                pMan.poSubjectArrowRight.Notify();
            }

            // SpaceKey: (with key history) -----------------------------------------------------------
            bool spaceKeyCurr = Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_SPACE);

            if (spaceKeyCurr == true && pMan.privSpaceKeyPrev == false)
            {
                pMan.poSubjectSpace.Notify();
            }

            pMan.privSpaceKeyPrev = spaceKeyCurr;

        }

        // Data: ----------------------------------------------
        private static InputMan pInstance = null;
        private bool privSpaceKeyPrev;
        private static InputMan psActiveInputMan = null;
        private InputSubject poSubjectArrowRight;
        private InputSubject poSubjectArrowLeft;
        private InputSubject poSubjectSpace;
    }
}

// --- End of File ---
