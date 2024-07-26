//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

namespace SpaceInvaders
{
    public class Input
    {
        public static void ReadKeyboardInput()
        {

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_U))
            {
                SpriteBatch boxBatch = SpriteBatchMan.Find(SpriteBatch.Name.Boxes);
                boxBatch.SetDrawEnable(true);
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_B))
            {
                SpriteBatch boxBatch = SpriteBatchMan.Find(SpriteBatch.Name.Boxes);
                boxBatch.SetDrawEnable(false);
            }

        }
    }
}

// --- End of File ---
