﻿//-----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class GhostMan : ManBase
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        public GhostMan(int reserveNum = 3, int reserveGrow = 1)
                : base(new DLinkMan(), new DLinkMan(), reserveNum, reserveGrow)   // <--- Kick the can (delegate)
        {
            // initialize derived data here
            this.poNodeCompare.pGameObj = this.poGameObj;
            GhostMan.psActiveGMan = null;
        }

        //----------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------
        public static void Create(int reserveNum = 0, int reserveGrow = 1)
        {
            // make sure values are ressonable 
            Debug.Assert(reserveNum >= 0);
            Debug.Assert(reserveGrow > 0);

            // initialize the singleton here
            Debug.Assert(pInstance == null);

            // Do the initialization
            if (pInstance == null)
            {
                pInstance = new GhostMan(reserveNum, reserveGrow);
            }
        }
        public static void Destroy()
        {
            // Do something clever here
            // track peak number of active nodes
            // print stats on destroy
            // invalidate the singleton
        }

        public static GameObjectNode Attach(GameObject pGameObject)
        {
            GhostMan pMan = GhostMan.psActiveGMan;
            GameObjectNode pNode = (GameObjectNode)pMan.baseAdd();

            pNode.Set(pGameObject);
            return pNode;
        }
        public static void SetActive(GhostMan pGMan)
        {
            GhostMan pMan = GhostMan.privGetInstance();
            Debug.Assert(pMan != null);

            Debug.Assert(pGMan != null);
            GhostMan.psActiveGMan = pGMan;
        }

        public static GameObjectNode Find(GameObject.Name name)
        {
            GhostMan pMan = GhostMan.psActiveGMan;

            // Compare functions only compares two Nodes

            // So:  Use the Compare Node - as a reference
            //      use in the Compare() function
            Debug.Assert(pMan.poNodeCompare.pGameObj != null);

            pMan.poNodeCompare.pGameObj.name = name;

            GameObjectNode pData = (GameObjectNode)pMan.baseFind(pMan.poNodeCompare);

            // OK to return null
            return pData;
        }


        public static void Remove(GameObjectNode pNode)
        {
            Debug.Assert(pNode != null);

            GhostMan pMan = GhostMan.psActiveGMan;
            Debug.Assert(pMan != null);

            pMan.baseRemove(pNode);
        }

        public static void Dump()
        {
            GhostMan pMan = GhostMan.psActiveGMan;

            pMan.baseDump();
        }

        //----------------------------------------------------------------------
        // Private methods
        //----------------------------------------------------------------------
        private static GhostMan privGetInstance()
        {
            // Safety - this forces users to call Create() first before using class
            Debug.Assert(pInstance != null);

            return pInstance;
        }

        //----------------------------------------------------------------------
        // Override Abstract methods
        //----------------------------------------------------------------------
        override protected NodeBase derivedCreateNode()
        {
            NodeBase pNodeBase = new GameObjectNode();
            Debug.Assert(pNodeBase != null);

            return pNodeBase;
        }

        //----------------------------------------------------------------------
        // Data: unique data for this manager 
        //----------------------------------------------------------------------
        private readonly GameObjectNode poNodeCompare = new GameObjectNode();
        private readonly GameObjectNull poGameObj = new GameObjectNull();
        private static GhostMan psActiveGMan = null;
        private static GhostMan pInstance = null;

    }
}

// --- End of File ---
