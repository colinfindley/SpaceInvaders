namespace SpaceInvaders
{
    class MoveCmd : Command
    {
        public MoveCmd(AlienGrid _pGrid)
        {

            this.pGrid = _pGrid;
            this.steps = 0;
        }

        public override void Execute(float deltaTime)
        {                
            pGrid.MoveGrid();
            PlaySound();
            this.steps++;
            TimerEventMan.Add(TimerEvent.Name.Move, this, deltaTime);
        }

        private void PlaySound()
        {
            int soundNumber = this.steps % 4;
            if (soundNumber == 0)
            {
                SoundNodeMan.Play(SoundNode.Name.fastinvader1);
            }
            else if (soundNumber == 1)
            {
                SoundNodeMan.Play(SoundNode.Name.fastinvader2);
            }
            else if (soundNumber == 2)
            {
                SoundNodeMan.Play(SoundNode.Name.fastinvader3);
            }
            else if (soundNumber == 3)
            {
                SoundNodeMan.Play(SoundNode.Name.fastinvader4);
            }

        }
        // Data: ---------------
        AlienGrid pGrid;
        int steps;
    }
}

