using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SoundManager
    {
        private SoundManager()
        {
            this.pSoundEngine.SoundVolume = 0.2f;
        }

        ~SoundManager()
        {
            this.pSoundEngine = null;
            SoundManager.pInstance = null;
        }

        //----------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------
        public static void Create()
        {
            // Do the initialization
            if (pInstance == null)
            {
                pInstance = new SoundManager();
            }
        }

        public static IrrKlang.ISoundSource Add(string soundFile)
        {
            IrrKlang.ISoundEngine engine = GetSoundEngine();
            return engine.AddSoundSourceFromFile(soundFile);
        }

        public static IrrKlang.ISoundEngine GetSoundEngine()
        {
             pInstance = SoundManager.privGetInstance();
            Debug.Assert(pInstance != null);

            Debug.Assert(pInstance.pSoundEngine != null);
            return pInstance.pSoundEngine;
        }

        //----------------------------------------------------------------------
        // Private methods
        //----------------------------------------------------------------------
        private static SoundManager privGetInstance()
        {
            Debug.Assert(pInstance != null);
            return pInstance;
        }

        private static SoundManager pInstance;
        private IrrKlang.ISoundEngine pSoundEngine = new IrrKlang.ISoundEngine();
    }
}