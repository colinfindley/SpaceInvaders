//-----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SoundNodeMan : ManBase
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        private SoundNodeMan(int reserveNum, int reserveGrow)
                : base(new SLinkMan(), new SLinkMan(), reserveNum, reserveGrow)   // <--- Kick the can (delegate)
        {
            // initialize derived data here
            psSoundNodeCompare = new SoundNode();
        }

        //----------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------
        public static void Update()
        {
            pSoundEngine.Update();
        }

            public static void Create(int reserveNum = 2, int reserveGrow = 1)
        {
            // make sure values are ressonable 
            Debug.Assert(reserveNum >= 0);
            Debug.Assert(reserveGrow > 0);

            // initialize the singleton here
            Debug.Assert(psInstance == null);

            // Do the initialization
            if (psInstance == null)
            {
                psInstance = new SoundNodeMan(reserveNum, reserveGrow);
                pSoundEngine = new IrrKlang.ISoundEngine();
                pSoundEngine.SoundVolume = .4f;

            }
        }

        public static void Destroy(bool bPrintEnable = false)
        {
            SoundNodeMan pMan = SoundNodeMan.privGetInstance();
            Debug.Assert(pMan != null);

            // Do something clever here
            // track peak number of active nodes
            // print stats on destroy
            // invalidate the singleton
            if (bPrintEnable)
            {
                SoundNodeMan.DumpStats();
            }
        }

        public static SoundNode Add(SoundNode.Name name, string pSoundName, int reserveNum = 3, int reserveGrow = 1)
        {
            SoundNodeMan pMan = SoundNodeMan.privGetInstance();
            Debug.Assert(pMan != null);

            SoundNode pSoundNode = (SoundNode)pMan.baseAdd();
            Debug.Assert(pSoundNode != null);

            // Initialize the data
            IrrKlang.ISoundSource soundSource = pSoundEngine.AddSoundSourceFromFile(pSoundName);
            pSoundNode.Set(name, soundSource);
            return pSoundNode;
        }

        public IrrKlang.ISoundEngine GetSoundEngine()
        {
            return pSoundEngine;
        }

        public static SoundNode Find(SoundNode.Name name)
        {
            SoundNodeMan pMan = SoundNodeMan.privGetInstance();
            Debug.Assert(pMan != null);

            // Compare functions only compares two SoundNodes

            // So:  Use the Compare SoundNode - as a reference
            //      use in the Compare() function
            SoundNodeMan.psSoundNodeCompare.name = name;

            SoundNode pData = (SoundNode)pMan.baseFind(SoundNodeMan.psSoundNodeCompare);
            return pData;
        }

        public static void Play(SoundNode.Name name)
        {
            Debug.WriteLine(name.ToString());
            IrrKlang.ISoundSource soundSource = Find(name).loadedSound;
            pSoundEngine.Play2D(soundSource, false, false, false);
        }

        public static void PlayLooped(SoundNode.Name name)
        {
            IrrKlang.ISoundSource soundSource = Find(name).loadedSound;
            pSoundEngine.Play2D(soundSource, true, false, false);
        }

        public static void PauseAll()
        {
            pSoundEngine.StopAllSounds();
        }

        public static void Remove(SoundNode pTexture)
        {
            SoundNodeMan pMan = SoundNodeMan.privGetInstance();
            Debug.Assert(pMan != null);

            Debug.Assert(pTexture != null);
            pMan.baseRemove(pTexture);
        }

        public static void Dump()
        {
            Debug.WriteLine("\n   ------ Sound Man: ------");

            SoundNodeMan pMan = SoundNodeMan.privGetInstance();
            Debug.Assert(pMan != null);

            pMan.baseDump();
        }

        public static void DumpStats()
        {
            Debug.WriteLine("\n   ------ Sound Man: ------");

            SoundNodeMan pMan = SoundNodeMan.privGetInstance();
            Debug.Assert(pMan != null);

            pMan.baseDumpStats();

            Debug.WriteLine("   ------------\n");
        }


        //------------------------------------
        // Override Abstract methods
        //------------------------------------
        override protected NodeBase derivedCreateNode()
        {
            NodeBase pNodeBase = new SoundNode();
            Debug.Assert(pNodeBase != null);

            return pNodeBase;
        }

        //------------------------------------
        // Private methods
        //------------------------------------
        private static SoundNodeMan privGetInstance()
        {
            // Safety - this forces users to call Create() first before using class
            Debug.Assert(psInstance != null);

            return psInstance;
        }

        //------------------------------------
        // Data: unique data for this manager 
        //------------------------------------
        private static SoundNode psSoundNodeCompare;
        private static SoundNodeMan psInstance = null;
        private static IrrKlang.ISoundEngine pSoundEngine;
    }

}

// --- End of File ---