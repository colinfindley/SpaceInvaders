//-----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------- 

using System.Diagnostics;

namespace SpaceInvaders
{
    public class AlienColumn : Composite
    {
        public AlienColumn()
            : base()
        {
            this.name = Name.AlienColumn;

            this.poColObj.pColSprite.SetColor(1, 0, 0);
        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an AlienColumn
            // Call the appropriate collision reaction            
            other.VisitColumn(this);
        }

        public override void VisitMissileGroup(MissileGroup m)
        {
            // MissileGroup vs Columns
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
            ColPair.Collide(m, pGameObj);
        }

        public override void VisitWallGroup(WallGroup w)
        {
            // MissileGroup vs Columns
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
            ColPair.Collide(w, pGameObj);
        }


        public override void Update()
        {
            // Go to first child
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }
    

    public override void Print()
    {
        Debug.WriteLine("");
        Debug.WriteLine("Column:");

        // walk through the list and render
        Iterator pIt = this.poDLinkMan.GetIterator();
        Debug.Assert(pIt != null);

        // Walk through the nodes
        for (pIt.First(); !pIt.IsDone(); pIt.Next())
        {
            GameObject pNode = (GameObject)pIt.Current();
            Debug.Assert(pNode != null);

            pNode.Dump();
        }
    }

    private static SpriteGameProxyNull psSpriteGameProxyNull = new SpriteGameProxyNull();
    }
}

// --- End of File ---
