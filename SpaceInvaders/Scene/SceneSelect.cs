//-----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------- 

using System.Diagnostics;

namespace SpaceInvaders
{
    public class SceneSelect : SceneState
    {
        public SceneSelect(SceneContext sceneContext)
        {
            this.Initialize();

        }

        public override void Initialize()
        {
            SetUpManagers();

            SpriteBatchMan.Add(SpriteBatch.Name.Texts);

            TextureMan.Add(Texture.Name.SpaceInvaders, "SpaceInvaders_ROM.tga");

            GlyphMan.Add(Glyph.Name.SpaceInvaders, 65, Texture.Name.SpaceInvaders, 3, 36, 5, 8);    // .A
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 66, Texture.Name.SpaceInvaders, 11, 36, 5, 8);   // .B
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 67, Texture.Name.SpaceInvaders, 19, 36, 5, 8);   // .C
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 68, Texture.Name.SpaceInvaders, 27, 36, 5, 8);   // .D
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 69, Texture.Name.SpaceInvaders, 35, 36, 5, 8);   // .E
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 70, Texture.Name.SpaceInvaders, 43, 36, 5, 8);   // .F
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 71, Texture.Name.SpaceInvaders, 51, 36, 5, 8);   // .G
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 72, Texture.Name.SpaceInvaders, 59, 36, 5, 8);   // .H
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 73, Texture.Name.SpaceInvaders, 67, 36, 5, 8);   // .I
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 74, Texture.Name.SpaceInvaders, 75, 36, 5, 8);   // .J
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 75, Texture.Name.SpaceInvaders, 83, 36, 5, 8);   // .K
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 76, Texture.Name.SpaceInvaders, 91, 36, 5, 8);   // .L
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 77, Texture.Name.SpaceInvaders, 99, 36, 5, 8);   // .M
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 78, Texture.Name.SpaceInvaders, 3, 46, 5, 8);    // .N
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 79, Texture.Name.SpaceInvaders, 11, 46, 5, 8);   // .O
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 80, Texture.Name.SpaceInvaders, 19, 46, 5, 8);   // .P
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 81, Texture.Name.SpaceInvaders, 27, 46, 5, 8);   // .Q
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 82, Texture.Name.SpaceInvaders, 35, 46, 5, 8);   // .R
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 83, Texture.Name.SpaceInvaders, 43, 46, 5, 8);   // .S
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 84, Texture.Name.SpaceInvaders, 51, 46, 5, 8);   // .T
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 85, Texture.Name.SpaceInvaders, 59, 46, 5, 8);   // .U
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 86, Texture.Name.SpaceInvaders, 67, 46, 5, 8);   // .V
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 87, Texture.Name.SpaceInvaders, 75, 46, 5, 8);   // .W
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 88, Texture.Name.SpaceInvaders, 83, 46, 5, 8);   // .X
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 89, Texture.Name.SpaceInvaders, 91, 46, 5, 8);   // .Y
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 90, Texture.Name.SpaceInvaders, 99, 46, 5, 8);   // .Z

            GlyphMan.Add(Glyph.Name.SpaceInvaders, 48, Texture.Name.SpaceInvaders, 3, 56, 5, 8);    // 0
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 49, Texture.Name.SpaceInvaders, 11, 56, 5, 8);   // 1
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 50, Texture.Name.SpaceInvaders, 19, 56, 5, 8);   // 2
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 51, Texture.Name.SpaceInvaders, 27, 56, 5, 8);   // 3
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 52, Texture.Name.SpaceInvaders, 35, 56, 5, 8);   // 4
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 53, Texture.Name.SpaceInvaders, 43, 56, 5, 8);   // 5
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 54, Texture.Name.SpaceInvaders, 51, 56, 5, 8);   // 6
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 55, Texture.Name.SpaceInvaders, 59, 56, 5, 8);   // 7
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 56, Texture.Name.SpaceInvaders, 67, 56, 5, 8);   // 8
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 57, Texture.Name.SpaceInvaders, 75, 56, 5, 8);   // 9

            GlyphMan.Add(Glyph.Name.SpaceInvaders, 60, Texture.Name.SpaceInvaders, 83, 56, 5, 8);   // <
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 62, Texture.Name.SpaceInvaders, 91, 56, 5, 8);   // >
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 32, Texture.Name.SpaceInvaders, 99, 56, 1, 8);   // Space
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 61, Texture.Name.SpaceInvaders, 107, 56, 5, 8);  // =
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 42, Texture.Name.SpaceInvaders, 115, 56, 5, 8);  // *
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 63, Texture.Name.SpaceInvaders, 123, 56, 5, 8);  // ?
            GlyphMan.Add(Glyph.Name.SpaceInvaders, 45, Texture.Name.SpaceInvaders, 131, 56, 5, 8);  // -

            ImageMan.Add(Image.Name.UFO, Texture.Name.SpaceInvaders, 99, 3, 16, 8);
            ImageMan.Add(Image.Name.OctopusA, Texture.Name.SpaceInvaders, 3, 3, 12, 8);
            ImageMan.Add(Image.Name.OctopusB, Texture.Name.SpaceInvaders, 18, 3, 12, 8);
            ImageMan.Add(Image.Name.CrabA, Texture.Name.SpaceInvaders, 33, 3, 11, 8);
            ImageMan.Add(Image.Name.CrabB, Texture.Name.SpaceInvaders, 47, 3, 11, 8);
            ImageMan.Add(Image.Name.SquidA, Texture.Name.SpaceInvaders, 61, 3, 8, 8);
            ImageMan.Add(Image.Name.SquidB, Texture.Name.SpaceInvaders, 72, 3, 8, 8);

            Azul.Color ufoColor = new Azul.Color(.97f, .23f, .22f);


            // --- Aliens ---
            SpriteGameMan.Add(SpriteGame.Name.OctopusA, Image.Name.OctopusA, 80, 400, 36, 25);
            SpriteGameMan.Add(SpriteGame.Name.OctopusB, Image.Name.OctopusB, 80, 400, 36, 25);
            SpriteGameMan.Add(SpriteGame.Name.CrabA, Image.Name.CrabA, 80, 450, 28, 25);
            SpriteGameMan.Add(SpriteGame.Name.CrabB, Image.Name.CrabB, 80, 450, 28, 25);
            SpriteGameMan.Add(SpriteGame.Name.SquidA, Image.Name.SquidA, 80, 500, 24, 25);
            SpriteGameMan.Add(SpriteGame.Name.SquidB, Image.Name.SquidB, 80, 500, 24, 25);
            SpriteGameMan.Add(SpriteGame.Name.UFO, Image.Name.UFO, 500, 100, 48, 24, ufoColor);

            AnimationCmd pSquidCmd = new AnimationCmd(SpriteGame.Name.SquidA, TimerEvent.Name.AnimateAlien);
            pSquidCmd.Attach(Image.Name.SquidB);
            pSquidCmd.Attach(Image.Name.SquidA);
            TimerEventMan.Add(TimerEvent.Name.AnimateAlien, pSquidCmd, 0.5f);

            // Crab Animation
            AnimationCmd pCrabCmd = new AnimationCmd(SpriteGame.Name.CrabA, TimerEvent.Name.AnimateAlien);
            pCrabCmd.Attach(Image.Name.CrabB);
            pCrabCmd.Attach(Image.Name.CrabA);
            TimerEventMan.Add(TimerEvent.Name.AnimateAlien, pCrabCmd, 0.5f);

            // Octopus Animation
            AnimationCmd pOctopusCmd = new AnimationCmd(SpriteGame.Name.OctopusA, TimerEvent.Name.AnimateAlien);
            pOctopusCmd.Attach(Image.Name.OctopusB);
            pOctopusCmd.Attach(Image.Name.OctopusA);
            TimerEventMan.Add(TimerEvent.Name.AnimateAlien, pOctopusCmd, .5f);


            //TimedCharacterFactory.Install("= ? MYSTERY", 7.0f, 0.10f, 360, 300, 0.9f, 0.9f, 0.9f);
            //TimedCharacterFactory.Install("= 30 POINTS", 10.0f, 0.10f, 360, 250, 0.9f, 0.9f, 0.9f);
            //TimedCharacterFactory.Install("= 20 POINTS", 13.0f, 0.10f, 360, 200, 0.9f, 0.9f, 0.9f);
            //TimedCharacterFactory.Install("= 10 POINTS", 16.0f, 0.10f, 360, 150, 0.2f, 0.8f, 0.2f);


            SpriteBatch invadersBatch = SpriteBatchMan.Add(SpriteBatch.Name.SpaceInvaders, 0);
            SpriteBatch boxBatch = SpriteBatchMan.Add(SpriteBatch.Name.Boxes, 0);
            boxBatch.SetDrawEnable(false);




            UFO pUFO = new UFO(320, 300);
            pUFO.ActivateCollisionSprite(boxBatch);
            pUFO.ActivateSprite(invadersBatch);

            UFORoot pUFORoot = new UFORoot(GameObject.Name.UFO, SpriteGame.Name.NullObject, 0.0f, 0.0f);
            pUFO.ActivateSprite(invadersBatch);

            // Add to GameObject Tree - {update and collisions}
            pUFORoot.Add(pUFO);
            pUFO.Update();


            AlienFactory AF = new AlienFactory(SpriteBatch.Name.SpaceInvaders);
            AlienGrid pAlienGrid = (AlienGrid)AF.Create(GameObject.Name.AlienGrid);
            GameObjectNodeMan.Attach(pAlienGrid);

            AlienColumn pColA = (AlienColumn)AF.Create(GameObject.Name.AlienColumn);
            pAlienGrid.Add(pColA);

            pColA.Add(AF.Create(GameObject.Name.Crab, 320, 200));
            pColA.Add(AF.Create(GameObject.Name.Octopus, 320, 150));
            pColA.Add(AF.Create(GameObject.Name.Squid, 320, 250));

            string playerOneScore = SceneContext.GetScore();
            string highScore = SceneContext.GetHighScore();

            string credit = "CREDIT";
            string creditNumStr = "00";

            // ScoreBoard
            string scoreBoard1 = "SCORE<1>";
            string scoreBoard2 = "SCORE<2>";
            string highScoreBoard = "HI-SCORE";

            // Real Scores
            string playerTwoScore = "0";

            // Top Line
            Font pScoreBoardOne = FontMan.Add(Font.Name.ScoreBoardOne, SpriteBatch.Name.Texts, scoreBoard1, Glyph.Name.SpaceInvaders, 26, 740);
            Font pHighScoreBoard = FontMan.Add(Font.Name.HighScoreBoard, SpriteBatch.Name.Texts, highScoreBoard, Glyph.Name.SpaceInvaders, 265, 740);
            Font pScoreBoardTwo = FontMan.Add(Font.Name.ScoreBoardTwo, SpriteBatch.Name.Texts, scoreBoard2, Glyph.Name.SpaceInvaders, 503, 740);

            // Second Row
            Font pPlayerTwoScore = FontMan.Add(Font.Name.PlayerTwoScore, SpriteBatch.Name.Texts, playerTwoScore, Glyph.Name.SpaceInvaders, 540, 700);

            // Bottom Line
            Font pCredit = FontMan.Add(Font.Name.Credits, SpriteBatch.Name.Texts, credit, Glyph.Name.SpaceInvaders, 485, 30);
            Font pZeroes = FontMan.Add(Font.Name.Zeroes, SpriteBatch.Name.Texts, creditNumStr, Glyph.Name.SpaceInvaders, 608, 30);

            Font pPlayerOneScore = FontMan.Add(Font.Name.PlayerOneScore, SpriteBatch.Name.Texts, "0", Glyph.Name.SpaceInvaders, 63, 700);
            Font pHighScore = FontMan.Add(Font.Name.HighScore, SpriteBatch.Name.Texts, highScore, Glyph.Name.SpaceInvaders, 302, 700);

        }

        private void LoadOnEntry()
        {
            string highScore = SceneContext.GetHighScore();

            // Change message
            Font highScoreFont = FontMan.Find(Font.Name.HighScore);
            highScoreFont.UpdateMessage(highScore);



            TimedCharacterFactory.Install("SPACE  INVADERS", 4.0f, 0.10f, 230, 400, 0.9f, 0.9f, 0.9f);
            TimedCharacterFactory.Install("= ? MYSTERY", 7.0f, 0.10f, 360, 300, 0.9f, 0.9f, 0.9f);
            TimedCharacterFactory.Install("= 30 POINTS", 10.0f, 0.10f, 360, 250, 0.9f, 0.9f, 0.9f);
            TimedCharacterFactory.Install("= 20 POINTS", 13.0f, 0.10f, 360, 200, 0.9f, 0.9f, 0.9f);
            TimedCharacterFactory.Install("= 10 POINTS", 16.0f, 0.10f, 360, 150, 0.2f, 0.8f, 0.2f);

        }

        public override void Update(float systemTime)
        {
            // Single Step, Free running...
            Simulation.Update(systemTime);

            // Input
            InputMan.Update();

            // Run based on simulation stepping
            if (Simulation.GetTimeStep() > 0.0f)
            {
                // Fire off the timer events
                TimerEventMan.Update(Simulation.GetTotalTime());

                // Do the collision checks
                ColPairMan.Process();

                // walk through all objects and push to flyweight
                GameObjectNodeMan.Update();

                // Delete any objects here...
                DelayedObjectMan.Process();
            }
        }

        public override void Draw()
        {
            // draw all objects
            SpriteBatchMan.Draw();
        }

        public override void Entering()
        {

            // Update timer since last pause
            float t0 = GlobalTimer.GetTime();
            float t1 = this.TimeAtPause;
            float delta = t0 - t1;
            TimerEventMan.PauseUpdate(delta);
            SwitchActiveManagers();


            this.LoadOnEntry();
        }
        public override void Leaving()
        {
            this.TimeAtPause = TimerEventMan.GetCurrTime();


            // FontMan.RemoveAll();

            // FontMan.Dump();
            //  TimerEventMan.Dump();

        }

        private void SetUpManagers()
        {
            this.poSpriteBoxMan = new SpriteBoxMan();
            SpriteBoxMan.SetActive(this.poSpriteBoxMan);
            SpriteBoxMan.Add(SpriteBox.Name.NullObject, 0, 0, 0, 0);

            this.poSpriteBatchMan = new SpriteBatchMan();
            SpriteBatchMan.SetActive(this.poSpriteBatchMan);

            this.poSpriteGameProxyMan = new SpriteGameProxyMan();
            SpriteGameProxyMan.SetActive(this.poSpriteGameProxyMan);
            SpriteGameProxyMan.Add(SpriteGame.Name.NullObject);

            this.poGhostMan = new GhostMan();
            GhostMan.SetActive(this.poGhostMan);

            this.poInputMan = new InputMan();
            InputMan.SetActive(this.poInputMan);

            this.poGameObjectNodeMan = new GameObjectNodeMan();
            GameObjectNodeMan.SetActive(this.poGameObjectNodeMan);

            this.poTimerEventMan = new TimerEventMan();
            TimerEventMan.SetActive(this.poTimerEventMan);

            this.poColPairMan = new ColPairMan();
            ColPairMan.SetActive(this.poColPairMan);

            this.poFontMan = new FontMan();
            FontMan.SetActive(this.poFontMan);

            this.poDelayedObjectMan = new DelayedObjectMan();
            DelayedObjectMan.SetActive(this.poDelayedObjectMan);

        }

        private void SwitchActiveManagers()
        {
            SpriteBoxMan.SetActive(this.poSpriteBoxMan);
            InputMan.SetActive(this.poInputMan);
            GameObjectNodeMan.SetActive(this.poGameObjectNodeMan);
            TimerEventMan.SetActive(this.poTimerEventMan);
            ColPairMan.SetActive(this.poColPairMan);
            SpriteGameProxyMan.SetActive(this.poSpriteGameProxyMan);
            SpriteBatchMan.SetActive(this.poSpriteBatchMan);
            FontMan.SetActive(this.poFontMan);
            GhostMan.SetActive(this.poGhostMan);
            DelayedObjectMan.SetActive(this.poDelayedObjectMan);
        }

        // ---------------------------------------------------
        // Data
        // ---------------------------------------------------
        public SpriteBatchMan poSpriteBatchMan;
        public FontMan poFontMan;
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
