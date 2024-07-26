using System;
using System.Diagnostics;


namespace SpaceInvaders

{
    public abstract class Command
    {
        public Command()
        {
        }
        abstract public void Execute();

        
    }

}

// --- End of File ---