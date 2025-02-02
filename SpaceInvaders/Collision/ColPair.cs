﻿
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ColPair : DLink
    {
        public enum Name
        {
            Alien_Wall,
            Missile_Wall,
            Bomb_Wall,
            Bomb_Shield,
            Misslie_Shield,
            Missile_Alien,
            Bumper_Ship,
            Bomb_Ship,
            Bumper_Grid,

            NullObject,
            Not_Initialized,
            Bomb_Missile,
            Missile_Bomb,
            Missile_UFO,
            Alien_Shield,
        }

        public ColPair()
            : base()
        {
            this.treeA = null;
            this.treeB = null;
            this.name = ColPair.Name.Not_Initialized;

            this.poSubject = new ColSubject();
            Debug.Assert(this.poSubject != null);

        }

        ~ColPair()
        {

        }
        public void Set(ColPair.Name colpairName, GameObject pTreeRootA, GameObject pTreeRootB)
        {
            Debug.Assert(pTreeRootA != null);
            Debug.Assert(pTreeRootB != null);

            this.treeA = pTreeRootA;
            this.treeB = pTreeRootB;
            this.name = colpairName;
        }
        private void privClear()
        {
            this.treeA = null;
            this.treeB = null;
            this.name = ColPair.Name.Not_Initialized;
        }

        public void Process()
        {
            Collide(this.treeA, this.treeB);
        }

        static public void Collide(GameObject pSafeTreeA, GameObject pSafeTreeB)
        {
            // A vs B
            GameObject pNodeA = pSafeTreeA;
            GameObject pNodeB = pSafeTreeB;

            while (pNodeA != null)
            {
                // Restart compare
                pNodeB = pSafeTreeB;

                while (pNodeB != null)
                {
                    // who is being tested?
                    //Debug.WriteLine("ColPair: test:  {0}, {1}", pNodeA.name, pNodeB.name);

                    // Get rectangles
                    ColRect rectA = pNodeA.GetColObject().poColRect;
                    ColRect rectB = pNodeB.GetColObject().poColRect;

                    // test them
                    if (ColRect.Intersect(rectA, rectB))
                    {
                        // Boom - it works (Visitor in Action)
                        pNodeA.Accept(pNodeB);
                        break;
                    }

                    pNodeB = (GameObject)IteratorForwardComposite.GetSibling(pNodeB);
                }

                pNodeA = (GameObject)IteratorForwardComposite.GetSibling(pNodeA);
            }
        }

        public void Attach(ColObserver observer)
        {
            this.poSubject.Attach(observer);
        }
        public void NotifyListeners()
        {
            this.poSubject.Notify();
        }
        public void SetCollision(GameObject pObjA, GameObject pObjB)
        {
            Debug.Assert(pObjA != null);
            Debug.Assert(pObjB != null);

            // GameObject pAlien = AlienCategory.GetAlien(objA, objB);
            this.poSubject.pObjA = pObjA;
            this.poSubject.pObjB = pObjB;
        }

        //---------------------------------------------------------------------------------------------------------
        // Override
        //---------------------------------------------------------------------------------------------------------

        override public System.Enum GetName()
        {
            return this.name;
        }

        override public void Wash()
        {
            this.privClear();
        }

        override public void Dump()
        {
            // we are using HASH code as its unique identifier 
            Debug.WriteLine("   {0} ({1})", this.name, this.GetHashCode());

            if (treeA != null)
            {
                Debug.WriteLine("       TreeA: {0}", treeA.GetName());
            }
            else
            {
                Debug.WriteLine("       TreeA: null");
            }

            if (treeB != null)
            {
                Debug.WriteLine("       TreeB: {0}", treeB.GetName());
            }
            else
            {
                Debug.WriteLine("       TreeB: null");
            }

            base.baseDump();
        }

        // Data: ---------------
        public ColPair.Name name;
        public GameObject treeA;
        public GameObject treeB;
        public ColSubject poSubject;

    }
}

// --- End of File ---
