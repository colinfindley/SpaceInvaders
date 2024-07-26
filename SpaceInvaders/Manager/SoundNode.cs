using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SoundNode : SLink
    {
        //------------------------------------
        // Enum
        //------------------------------------
        public enum Name
        {
            Shoot,
            Explode,
            AlienDeath,
            PlayerDeath,
            Music,
            Uninitialized,
            UFO_High_Pitch,
            UFO_Low_Pitch
        }

        //------------------------------------
        // Constructors
        //------------------------------------
        public SoundNode()
            : base()
        {
            this.name = SoundNode.Name.Uninitialized;
        }

        //------------------------------------
        // Methods
        //------------------------------------
        public void Set(SoundNode.Name _name, IrrKlang.ISoundSource soundSource)
        {
            this.name = _name;
            this.loadedSound = soundSource;
        }

        public void SetName(SoundNode.Name inName)
        {
            this.name = inName;
        }


        private void privClear()
        {

        }

        //------------------------------------
        // Override
        //------------------------------------
        public override System.Enum GetName()
        {
            return this.name;
        }
        override public void Wash()
        {
            this.baseClear();
            this.privClear();
        }
        override public void Dump()
        {
            // we are using HASH code as its unique identifier 
            Debug.WriteLine("   {0} ({1})", this.name, this.GetHashCode());

            // Data:
            Debug.WriteLine("   Name: {0} ({1})", this.name, this.GetHashCode());

            // Let the base print its contribution
            this.baseDump();
        }

        //------------------------------------
        // Data
        //------------------------------------

        public SoundNode.Name name;
        public IrrKlang.ISoundSource loadedSound;


    }
}

// --- End of File ---
