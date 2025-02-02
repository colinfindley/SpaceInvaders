﻿//-----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class Composite : GameObject
    {
        public Composite()
            : base(Component.Container.COMPOSITE,
                  GameObject.Name.NullObject,
                  SpriteGame.Name.NullObject)
        {
            this.poDLinkMan = new DLinkMan();
        }

        public Composite(GameObject.Name name, SpriteGame.Name spriteName)
        : base(Component.Container.COMPOSITE,
               name,
               spriteName)
        {
            this.poDLinkMan = new DLinkMan();
        }
        override public void Resurrect()
        {
            // check the DLinkMan
            Debug.Assert(this.poDLinkMan.poHead == null);

            base.Resurrect();
        }

        public override int GetNumChildren()
        {
            int count = 0;

            // walk through the list and render
            Iterator pIt = this.poDLinkMan.GetIterator();
            Debug.Assert(pIt != null);

            for (pIt.First(); !pIt.IsDone(); pIt.Next())
            {
                count++;
            }

            return count;
        }
        public override void VisitMissileGroup(MissileGroup m)
        {
            // AlienColumn vs MissileGroup
            Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);

            // MissileGroup vs Columns
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
            ColPair.Collide(m, pGameObj);
        }



        public override void Move(float deltaX, float deltaY)
        {
            Iterator pIt = this.poDLinkMan.GetIterator();
            Debug.Assert(pIt != null);

            for (pIt.First(); !pIt.IsDone(); pIt.Next())
            {
                GameObject pNode = (GameObject)pIt.Current();
                Debug.Assert(pNode != null);
                pNode.Move(deltaX, deltaY);
            }
        }

        override public void Add(Component pComponent)
        {
            Debug.Assert(pComponent != null);
            Debug.Assert(this.poDLinkMan != null);
            this.poDLinkMan.AddToFront(pComponent);

            pComponent.pParent = this;
        }

        public Component GetHead()
        {
            Debug.Assert(this.poDLinkMan != null);
            Component pHead = (GameObject)this.poDLinkMan.poHead;
            return pHead;
        }
        override public void Remove(Component pComponent)
        {
            Debug.Assert(pComponent != null);
            Debug.Assert(this.poDLinkMan != null);
            this.poDLinkMan.Remove(pComponent);
        }
        public override void Print()
        {
            Debug.WriteLine("");
            Debug.WriteLine("Composite:");

            Iterator pIt = this.poDLinkMan.GetIterator();
            Debug.Assert(pIt != null);

            for (pIt.First(); !pIt.IsDone(); pIt.Next())
            {
                GameObject pNode = (GameObject)pIt.Current();
                Debug.Assert(pNode != null);

                pNode.Print();
            }
        }

        public override void Wash()
        {
            // shouldn't be called
            Debug.Assert(false);
        }

        override public void DumpNode()
        {
            if (IteratorForwardComposite.GetParent(this) != null)
            {
                Debug.WriteLine(" GameObject Name:({0}) parent:{1} <---- Composite", this.GetHashCode(), IteratorForwardComposite.GetParent(this).GetHashCode());
            }
            else
            {
                Debug.WriteLine(" GameObject Name:({0}) parent:null <---- Composite", this.GetHashCode());
            }
        }
        protected DLinkMan poDLinkMan;
    }
}

// --- End of File ---


