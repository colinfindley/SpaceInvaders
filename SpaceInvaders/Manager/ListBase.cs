//-----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class ListBase
    {
        abstract public void AddToFront(NodeBase pNode);
        abstract public void Remove(NodeBase pNode);
        abstract public NodeBase RemoveFromFront();


        abstract public Iterator GetIterator();
        virtual public void PriorityInsert(NodeBase _pNode, float priority)
        {
            Debug.Assert(false);
        }
    }
}

// --- End of File ---
