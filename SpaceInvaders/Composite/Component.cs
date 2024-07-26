//-----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class Component : ColVisitor
    {
        public enum Container
        {
            LEAF,
            COMPOSITE,
            Unknown
        }

        public Component(Component.Container _type)
        {
            this.type = _type;
            this.pParent = null;
            this.pReverse = null;
        }
        virtual public void Resurrect()
        {
            this.pParent = null;
            this.pReverse = null;
        }
        public abstract void Print();
        public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract void DumpNode();
        public virtual void Move(float deltaX, float deltaY) { }

        public virtual int GetNumChildren()
        {
            return 0;
        }

        // Data
        public Container type;
        public Component pParent;
        public Component pReverse;
    }
}

// --- End of File ---



