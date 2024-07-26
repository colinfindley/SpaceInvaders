//-----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class AlienGrid : Composite
    {
        public AlienGrid()
            : base()
        {
            this.name = Name.AlienGrid;

            this.poColObj.pColSprite.SetColor(0, 1, 0);

            this.delta = 4.0f;
            this.shiftDown = false;
            this.alienCount = 55;
        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an AlienGroup
            // Call the appropriate collision reaction            
            other.VisitGrid(this);
        }

        public override void VisitMissileGroup(MissileGroup m)
        {
            // MissileGroup vs Columns
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
            ColPair.Collide(m, pGameObj);
        }

        public override void VisitWallGroup(WallGroup w)
        {

            if (this.poColObj.poColRect.height == 0)
                return;

            // MissileGroup vs Columns
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(w);
            ColPair.Collide(pGameObj, this);
        }
        public override void VisitWallLeft(WallLeft w)
        {
            ColPair pColPair = ColPairMan.GetActiveColPair();
            pColPair.SetCollision(w, this);
            pColPair.NotifyListeners();
        }
        public override void VisitWallRight(WallRight w)
        {
            ColPair pColPair = ColPairMan.GetActiveColPair();
            pColPair.SetCollision(w, this);
            pColPair.NotifyListeners();
        }



        public override void Update()
        {
            //if (this.alienCount == 0)
            //{
            //    RespawnGrid();
            //}
            //Debug.WriteLine("update: {0}", this);
            base.BaseUpdateBoundingBox(this);

            base.Update();
        }

        public void RespawnAliens()
        {

            // Rereate all the aliens from scratch -- change to ghostMan if time
            AlienFactory AF = new AlienFactory(SpriteBatch.Name.SpaceInvaders);

            float horizontalSpread = 50.0f;
            int numberOfAlienColumns = 11;
            float startX = 86;


            for (int i = 0; i < numberOfAlienColumns; i++)
            {

                AlienColumn pColA = (AlienColumn)AF.Create(GameObject.Name.AlienColumn);
                this.Add(pColA);

                pColA.Add(AF.Create(GameObject.Name.Octopus, startX + i * horizontalSpread, 400));
                pColA.Add(AF.Create(GameObject.Name.Octopus, startX + i * horizontalSpread, 450));
                pColA.Add(AF.Create(GameObject.Name.Crab, startX + i * horizontalSpread, 500));
                pColA.Add(AF.Create(GameObject.Name.Crab, startX + i * horizontalSpread, 550));
                pColA.Add(AF.Create(GameObject.Name.Squid, startX + i * horizontalSpread, 600));
            }

            // Reset the speed but a little faster
            this.delta = Math.Abs(this.delta) + 4;
            TimerEventMan.ResetSpeed();
        }

        public void MoveGrid()
        {
            IteratorForwardComposite pFor = new IteratorForwardComposite(this);

            Component pNode = pFor.First();
            while (!pFor.IsDone())
            {

                GameObject pGameObj = (GameObject)pNode;
                pGameObj.x += this.delta;

                if (this.shiftDown == true)
                {
                    pGameObj.y -= 25;
                }

                pNode = pFor.Next();

            }
            this.shiftDown = false;
            this.Update();
        }


        public float GetDelta()
        {
            return this.delta;
        }

        public void SetDelta(float inDelta)
        {
            this.delta = inDelta;
        }

        public void ShiftDown()
        {
            this.shiftDown = true;
        }

        // Data: ---------------
        private float delta;
        private bool shiftDown;
        public int alienCount;

    }
}



// --- End of File ---
