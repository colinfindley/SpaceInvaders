﻿//-----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SampleCmd : Command
    {
        public SampleCmd(String txt)
        {
            // string only for testing
            this.pString = txt;
        }

        public override void Execute(float deltaTime)
        {
            Debug.WriteLine(" {0} time:{1} ", this.pString, TimerEventMan.GetCurrTime());
        }

        private String pString;
    }
}

// --- End of File ---
