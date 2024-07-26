//-----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class GridObserver : ColObserver
    {
        public GridObserver()
        {
            this.speedMultiplier = -1.2f;
            this.maxSpeed = 8;
            this.minSpeed = -8;
        }
        override public void Notify()
        {


            // OK do some magic
            AlienGrid pGrid = (AlienGrid)this.pSubject.pObjB;
            this.delta = pGrid.GetDelta();

            WallCategory pWall = (WallCategory)this.pSubject.pObjA;
            if (pWall.GetCategoryType() == WallCategory.Type.Right)
            {
                //IncreaseSpeed();
                pGrid.ShiftDown();
                pGrid.SetDelta(this.delta *= -1);
                pGrid.MoveGrid();

            }
            else if (pWall.GetCategoryType() == WallCategory.Type.Left)
            {
                //IncreaseSpeed();
                pGrid.ShiftDown();
                pGrid.SetDelta(this.delta *= -1);
                pGrid.MoveGrid();
            }
            else
            {
                Debug.Assert(false);
            }

        }
        private void IncreaseSpeed()
        {
            if (delta < maxSpeed || delta > this.minSpeed)
            {
                delta *= speedMultiplier;
            }
            else
            {
                delta *= -1;
            }
        }

        override public void Dump()
        {
            Debug.Assert(false);
        }
        override public System.Enum GetName()
        {
            return Name.GridObserver;
        }
        float delta;
        float speedMultiplier;
        float maxSpeed;
        float minSpeed;
    }
}

// --- End of File ---
