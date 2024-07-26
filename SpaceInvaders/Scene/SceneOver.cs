//-----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------- 
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SceneOver : SceneState
    {
        public SceneOver(SceneContext sceneContext)
        {
            this.Initialize();

        }

        public override void Initialize()
        {
            SetUpManagers();


            SpriteBatch pSB_Texts = SpriteBatchMan.Add(SpriteBatch.Name.Texts);

            TextureMan.Add(Texture.Name.HotPink, "HotPink.tga");
            TextureMan.Add(Texture.Name.SpaceInvaders, "SpaceInvaders_ROM.tga");
            TextureMan.Add(Texture.Name.Environment, "Birds_N_Shield.tga");




            //-------------------------------------------------------
            // Add to GlyphMan
            //-------------------------------------------------------

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


            string credit = "CREDIT";
            string creditNumStr = "00";
            //creditNumStr = creditNumStr[0] + " " + creditNumStr[1];

            // ScoreBoard
            string scoreBoard1 = "SCORE<1>";
            string scoreBoard2 = "SCORE<2>";
            string highScoreBoard = "HI-SCORE";

            // Real Scores
            string playerTwoScore = "0";
            string playerOneScore = SceneContext.GetScore();
            string highScore = SceneContext.GetScore();
            string livesLeft = SceneContext.GetLivesLeft();

            // Top Line
            Font pScoreBoardOne = FontMan.Add(Font.Name.ScoreBoardOne, SpriteBatch.Name.Texts, scoreBoard1, Glyph.Name.SpaceInvaders, 26, 740);
            Font pHighScoreBoard = FontMan.Add(Font.Name.HighScoreBoard, SpriteBatch.Name.Texts, highScoreBoard, Glyph.Name.SpaceInvaders, 265, 740);
            Font pScoreBoardTwo = FontMan.Add(Font.Name.ScoreBoardTwo, SpriteBatch.Name.Texts, scoreBoard2, Glyph.Name.SpaceInvaders, 503, 740);

            // Second Row
            Font pPlayerTwoScore = FontMan.Add(Font.Name.PlayerTwoScore, SpriteBatch.Name.Texts, playerTwoScore, Glyph.Name.SpaceInvaders, 540, 700);

            // Bottom Line
            Font pCredit = FontMan.Add(Font.Name.Credits, SpriteBatch.Name.Texts, credit, Glyph.Name.SpaceInvaders, 485, 30);
            Font pZeroes = FontMan.Add(Font.Name.Zeroes, SpriteBatch.Name.Texts, creditNumStr, Glyph.Name.SpaceInvaders, 608, 30);


        }

        private void LoadOnEntry()
        {
            // Real Scores
            string playerOneScore = SceneContext.GetScore();
            string highScore = SceneContext.GetHighScore();
            // reset Score
            SceneContext.SetScore(0);


            // Second Row
            Font pPlayerOneScore = FontMan.Add(Font.Name.PlayerOneScore, SpriteBatch.Name.Texts, playerOneScore, Glyph.Name.SpaceInvaders, 63, 700);
            Font pHighScore = FontMan.Add(Font.Name.HighScore, SpriteBatch.Name.Texts, highScore, Glyph.Name.SpaceInvaders, 302, 700);
            TimedCharacterFactory.Install("GAME  OVER", 2.0f, 0.30f, 275, 400, .97f, .1f, .1f);
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
            // We want a different canvas for this scene
            SwitchActiveManagers();
            LoadOnEntry();
        }
        public override void Leaving()
        {
            // update SpriteBatchMan()
            this.TimeAtPause = TimerEventMan.GetCurrTime();
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
