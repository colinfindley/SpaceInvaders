﻿//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ExplosionSoundObserver : ColObserver
    {
        public ExplosionSoundObserver()
        {

            this.pSndEngine = SoundManager.GetSoundEngine();
            Debug.Assert(this.pSndEngine != null);
            this.pSndSrc = SoundManager.Add("explosion.wav");
        }
        public override void Notify()
        {
            //Debug.WriteLine(" Snd_Observer: {0} {1}", this.pSubject.pObjA, this.pSubject.pObjB);

            pSndEngine.SoundVolume = 0.2f;
            pSndEngine.Play2D(pSndSrc, false, false, false);
        }



        override public void Dump()
        {
            Debug.Assert(false);
        }
        override public System.Enum GetName()
        {
            return Name.SoundObserver;
        }


        // Data
        IrrKlang.ISoundEngine pSndEngine;
        IrrKlang.ISoundSource pSndSrc;
    }
}

// --- End of File ---
