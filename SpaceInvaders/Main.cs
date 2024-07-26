//-----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------- 

using System.Diagnostics;

namespace SpaceInvaders
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the instance
            // LTN since this is alive for the duration of the whole program
            SpaceInvaders game = new SpaceInvaders();
            Debug.Assert(game != null);

            // Start the game
            game.Run();
        }
    }
}

// --- End of File ---
