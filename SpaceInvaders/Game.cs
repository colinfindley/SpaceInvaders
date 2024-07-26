//-----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpaceInvaders : Azul.Game
    {

        //-----------------------------------------------------------------------------
        // Game::Initialize()
        //		Allows the engine to perform any initialization it needs to before 
        //      starting to run.  This is where it can query for any required services 
        //      and load any non-graphic related content. 
        //-----------------------------------------------------------------------------
        public override void Initialize()
        {
            this.SetWindowName("Space Invaders");
            this.SetWidthHeight(672, 768);
            this.SetClearColor(0, 0, 0, 1.0f);
        }

        //-----------------------------------------------------------------------------
        // Game::LoadContent()
        //		Allows you to load all content needed for your engine,
        //	    such as objects, graphics, etc.
        //-----------------------------------------------------------------------------
        public override void LoadContent()
        {

            //---------------------------------------------------------------------------------------------------------
            // Setup Managers - once here
            //---------------------------------------------------------------------------------------------------------

            Simulation.Create();
            TextureMan.Create();
            ImageMan.Create();
            SpriteGameMan.Create();
            SoundNodeMan.Create();

            //-------------------------------------------------------
            // Load the Sounds
            //-------------------------------------------------------

            SoundNodeMan.Add(SoundNode.Name.Explode, "explosion.wav");
            SoundNodeMan.Add(SoundNode.Name.AlienDeath, "invaderkilled.wav");
            SoundNodeMan.Add(SoundNode.Name.Shoot, "shoot.wav");
            SoundNodeMan.Add(SoundNode.Name.UFO_High_Pitch, "ufo_highpitch.wav");
            SoundNodeMan.Add(SoundNode.Name.UFO_Low_Pitch, "ufo_lowpitch.wav");
            SoundNodeMan.Add(SoundNode.Name.fastinvader1, "fastinvader4.wav");
            SoundNodeMan.Add(SoundNode.Name.fastinvader2, "fastinvader1.wav");
            SoundNodeMan.Add(SoundNode.Name.fastinvader3, "fastinvader2.wav");
            SoundNodeMan.Add(SoundNode.Name.fastinvader4, "fastinvader3.wav");


            SpriteBatchMan.Create();
            this.poSpriteBatchMan = new SpriteBatchMan();
            SpriteBatchMan.SetActive(this.poSpriteBatchMan);

            TimerEventMan.Create();
            this.poTimerEventMan = new TimerEventMan();
            TimerEventMan.SetActive(this.poTimerEventMan);

            SpriteBoxMan.Create();
            this.poSpriteBoxMan = new SpriteBoxMan();
            SpriteBoxMan.SetActive(this.poSpriteBoxMan);

            SpriteGameProxyMan.Create();
            this.poSpriteGameProxyMan = new SpriteGameProxyMan();
            SpriteGameProxyMan.SetActive(this.poSpriteGameProxyMan);

            GameObjectNodeMan.Create();
            this.poGameObjectNodeMan = new GameObjectNodeMan();
            GameObjectNodeMan.SetActive(this.poGameObjectNodeMan);

            this.poInputMan = new InputMan();
            InputMan.SetActive(this.poInputMan);

            ColPairMan.Create();
            this.poColPairMan = new ColPairMan();
            ColPairMan.SetActive(this.poColPairMan);

            DelayedObjectMan.Create();
            this.poDelayedObjectMan = new DelayedObjectMan();
            DelayedObjectMan.SetActive(this.poDelayedObjectMan);

            GlyphMan.Create();

            FontMan.Create();

            GhostMan.Create();
            this.poGhostMan = new GhostMan();
            GhostMan.SetActive(this.poGhostMan);

            SceneContext.Create();


 


 



        }

        //-----------------------------------------------------------------------------
        // Game::Update()
        //      Called once per frame, update data, tranformations, etc
        //      Use this function to control process order
        //      Input, AI, Physics, Animation, and Graphics
        //-----------------------------------------------------------------------------
        public override void Update()
        {

            GlobalTimer.Update(this.GetTime());

            // Hack to proof of concept... 
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_1) == true)
            {
                SceneContext.SetState(SceneContext.Scene.Select);
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_2) == true)
            {
                SceneContext.SetState(SceneContext.Scene.Play);
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_3) == true)
            {
                SceneContext.SetState(SceneContext.Scene.Over);
            }

            // Update the scene
            SceneContext.GetState().Update(this.GetTime());

        }

        //-----------------------------------------------------------------------------
        // Game::Draw()
        //		This function is called once per frame
        //	    Use this for draw graphics to the screen.
        //      Only do rendering here
        //-----------------------------------------------------------------------------
        public override void Draw()
        {
            //SpriteBatchMan.Draw();
            // Draw the scene
            SceneContext.GetState().Draw();


        }


        //-----------------------------------------------------------------------------
        // Game::UnLoadContent()
        //       unload content (resources loaded above)
        //       unload all content that was loaded before the Engine Loop started
        //-----------------------------------------------------------------------------
        public override void UnLoadContent()
        {
            GhostMan.Destroy();
            FontMan.Destroy();
            GlyphMan.Destroy();
            ColPairMan.Destroy();
            GameObjectNodeMan.Destroy();
            SpriteGameProxyMan.Destroy();
            TimerEventMan.Destroy();
            SpriteBoxMan.Destroy();
            SpriteBatchMan.Destroy();
            SpriteGameMan.Destroy();
            ImageMan.Destroy();
            TextureMan.Destroy();
            SoundNodeMan.Destroy();
        }

        public SpriteBatchMan poSpriteBatchMan;
        private SpriteBoxMan poSpriteBoxMan;
        private SpriteGameProxyMan poSpriteGameProxyMan;
        private GhostMan poGhostMan;
        private InputMan poInputMan;
        private GameObjectNodeMan poGameObjectNodeMan;
        private TimerEventMan poTimerEventMan;
        private ColPairMan poColPairMan;
        private DelayedObjectMan poDelayedObjectMan;


    }
}

// --- End of File ---
