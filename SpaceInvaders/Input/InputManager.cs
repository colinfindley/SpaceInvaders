//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;

namespace SpaceInvaders
{
    public class Input
    {
        public static void ReadKeyboardInput()
        {
            SpriteBatch boxBatch = SpriteBatchMan.Find(SpriteBatch.Name.Boxes);


            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_U))
            {
                boxBatch.EnableDraw = false;
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_B))
            {
                boxBatch.EnableDraw = true;
            }

        }
    }
}

// --- End of File ---
