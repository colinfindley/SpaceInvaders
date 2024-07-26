//-----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;
namespace SpaceInvaders
{
    public class ScenePlay : SceneState
    {
        public ScenePlay(SceneContext sceneContext)
        {
            Debug.Assert(sceneContext != null);
            this.Initialize();

        }

        public override void Initialize()
        {

            //-------------------------------------------------------
            // Initialize local instances of managers here and switch the active frame
            //-------------------------------------------------------
            SetUpManagers();

            //-------------------------------------------------------
            // Load the Textures
            //-------------------------------------------------------

            TextureMan.Add(Texture.Name.HotPink, "HotPink.tga");
            TextureMan.Add(Texture.Name.SpaceInvaders, "SpaceInvaders_ROM.tga");
            TextureMan.Add(Texture.Name.Environment, "Birds_N_Shield.tga");


            //-------------------------------------------------------
            // Create Images
            //-------------------------------------------------------

            ImageMan.Add(Image.Name.HotPink, Texture.Name.HotPink, 0, 0, 128, 128);
            ImageMan.Add(Image.Name.OctopusA, Texture.Name.SpaceInvaders, 3, 3, 12, 8);
            ImageMan.Add(Image.Name.OctopusB, Texture.Name.SpaceInvaders, 18, 3, 12, 8);
            ImageMan.Add(Image.Name.CrabA, Texture.Name.SpaceInvaders, 33, 3, 11, 8);
            ImageMan.Add(Image.Name.CrabB, Texture.Name.SpaceInvaders, 47, 3, 11, 8);
            ImageMan.Add(Image.Name.SquidA, Texture.Name.SpaceInvaders, 61, 3, 8, 8);
            ImageMan.Add(Image.Name.SquidB, Texture.Name.SpaceInvaders, 72, 3, 8, 8);
            ImageMan.Add(Image.Name.AlienExplosion, Texture.Name.SpaceInvaders, 83, 3, 13, 8);
            ImageMan.Add(Image.Name.SaucerExplosion, Texture.Name.SpaceInvaders, 118, 3, 21, 8);
            ImageMan.Add(Image.Name.PlayerShotExplosion, Texture.Name.SpaceInvaders, 7, 25, 8, 8);
            ImageMan.Add(Image.Name.AlienShotExplosion, Texture.Name.SpaceInvaders, 86, 25, 6, 8);
            ImageMan.Add(Image.Name.PlayerExplosionA, Texture.Name.SpaceInvaders, 19, 14, 16, 8);
            ImageMan.Add(Image.Name.PlayerExplosionB, Texture.Name.SpaceInvaders, 38, 14, 16, 8);
            ImageMan.Add(Image.Name.UFO, Texture.Name.SpaceInvaders, 99, 3, 16, 8);

            ImageMan.Add(Image.Name.Ship, Texture.Name.SpaceInvaders, 3, 14, 13, 8);
            ImageMan.Add(Image.Name.Wall, Texture.Name.SpaceInvaders, 131, 59, 5, 1);
            ImageMan.Add(Image.Name.Missile, Texture.Name.SpaceInvaders, 3, 29, 1, 4);


            ImageMan.Add(Image.Name.SquigglyShotA, Texture.Name.SpaceInvaders, 18, 26, 3, 7);
            ImageMan.Add(Image.Name.SquigglyShotB, Texture.Name.SpaceInvaders, 24, 26, 3, 7);
            ImageMan.Add(Image.Name.SquigglyShotC, Texture.Name.SpaceInvaders, 30, 26, 3, 7);
            ImageMan.Add(Image.Name.SquigglyShotD, Texture.Name.SpaceInvaders, 36, 26, 3, 7);
            ImageMan.Add(Image.Name.PlungerShotA, Texture.Name.SpaceInvaders, 42, 27, 3, 6);
            ImageMan.Add(Image.Name.PlungerShotB, Texture.Name.SpaceInvaders, 48, 27, 3, 6);
            ImageMan.Add(Image.Name.PlungerShotC, Texture.Name.SpaceInvaders, 54, 27, 3, 6);
            ImageMan.Add(Image.Name.PlungerShotD, Texture.Name.SpaceInvaders, 60, 27, 3, 6);
            ImageMan.Add(Image.Name.RollingShotA, Texture.Name.SpaceInvaders, 65, 26, 3, 7);
            ImageMan.Add(Image.Name.RollingShotB, Texture.Name.SpaceInvaders, 70, 26, 3, 7);
            ImageMan.Add(Image.Name.RollingShotC, Texture.Name.SpaceInvaders, 75, 26, 3, 7);
            ImageMan.Add(Image.Name.RollingShotD, Texture.Name.SpaceInvaders, 80, 26, 3, 7);

            ImageMan.Add(Image.Name.Brick, Texture.Name.Environment, 20, 210, 10, 5);
            ImageMan.Add(Image.Name.BrickLeft_Top0, Texture.Name.Environment, 15, 180, 10, 10);
            ImageMan.Add(Image.Name.BrickLeft_Bottom, Texture.Name.Environment, 36, 215, 10, 5);
            ImageMan.Add(Image.Name.BrickRight_Top0, Texture.Name.Environment, 75, 180, 10, 10);
            ImageMan.Add(Image.Name.BrickRight_Bottom, Texture.Name.Environment, 55, 215, 10, 5);

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


            //-------------------------------------------------------
            // Create Sprites
            //-------------------------------------------------------
            
            // Colors
            Azul.Color shipColor = new Azul.Color(.28f, .87f, .33f, 1.0f);
            Azul.Color wallColor = new Azul.Color(.28f, .87f, .33f);
            Azul.Color ufoColor = new Azul.Color(.97f, .23f, .22f);

            float brickWidth = 11;
            float brickHeight = 11;
            float bombWidth = 9;
            float bombHeight = 21;


            // --- Aliens ---
            SpriteGameMan.Add(SpriteGame.Name.OctopusA, Image.Name.OctopusA, 80, 400, 36, 25);
            SpriteGameMan.Add(SpriteGame.Name.OctopusB, Image.Name.OctopusB, 80, 400, 36, 25);
            SpriteGameMan.Add(SpriteGame.Name.CrabA, Image.Name.CrabA, 80, 450, 28, 25);
            SpriteGameMan.Add(SpriteGame.Name.CrabB, Image.Name.CrabB, 80, 450, 28, 25);
            SpriteGameMan.Add(SpriteGame.Name.SquidA, Image.Name.SquidA, 80, 500, 24, 25);
            SpriteGameMan.Add(SpriteGame.Name.SquidB, Image.Name.SquidB, 80, 500, 24, 25);
            SpriteGameMan.Add(SpriteGame.Name.UFO, Image.Name.UFO, 500, 100, 48, 24, ufoColor);

            // --- Defender Objects ---
            SpriteGameMan.Add(SpriteGame.Name.Missile, Image.Name.Missile, 0, 0, 3, 12);
            SpriteGameMan.Add(SpriteGame.Name.Ship, Image.Name.Ship, 275, 100, 39, 24, shipColor);
            SpriteGameMan.Add(SpriteGame.Name.backupShip, Image.Name.Ship, 275, 100, 39, 24, shipColor);
            SpriteGameMan.Add(SpriteGame.Name.backupShip2, Image.Name.Ship, 275, 100, 39, 24, shipColor);
            SpriteGameMan.Add(SpriteGame.Name.backupShip3, Image.Name.Ship, 275, 100, 39, 24, shipColor);

            SpriteGameMan.Add(SpriteGame.Name.Wall, Image.Name.Wall, 448, 900, 850, 3, wallColor);

            // --- Bombs ---
            SpriteGameMan.Add(SpriteGame.Name.SquigglyShotA, Image.Name.SquigglyShotA, 200, 20, bombWidth, bombHeight);
            SpriteGameMan.Add(SpriteGame.Name.SquigglyShotB, Image.Name.SquigglyShotB, 200, 200, bombWidth, bombHeight);
            SpriteGameMan.Add(SpriteGame.Name.SquigglyShotC, Image.Name.SquigglyShotC, 200, 200, bombWidth, bombHeight);
            SpriteGameMan.Add(SpriteGame.Name.SquigglyShotD, Image.Name.SquigglyShotD, 200, 200, bombWidth, bombHeight);
            SpriteGameMan.Add(SpriteGame.Name.PlungerShotA, Image.Name.PlungerShotA, 100, 100, bombWidth, bombHeight);
            SpriteGameMan.Add(SpriteGame.Name.PlungerShotB, Image.Name.PlungerShotB, 100, 100, bombWidth, bombHeight);
            SpriteGameMan.Add(SpriteGame.Name.PlungerShotC, Image.Name.PlungerShotC, 100, 100, bombWidth, bombHeight);
            SpriteGameMan.Add(SpriteGame.Name.PlungerShotD, Image.Name.PlungerShotD, 100, 100, bombWidth, bombHeight);
            SpriteGameMan.Add(SpriteGame.Name.RollingShotA, Image.Name.RollingShotA, 100, 100, bombWidth, bombHeight);
            SpriteGameMan.Add(SpriteGame.Name.RollingShotB, Image.Name.RollingShotB, 100, 100, bombWidth, bombHeight);
            SpriteGameMan.Add(SpriteGame.Name.RollingShotC, Image.Name.RollingShotC, 100, 100, bombWidth, bombHeight);
            SpriteGameMan.Add(SpriteGame.Name.RollingShotD, Image.Name.RollingShotD, 100, 100, bombWidth, bombHeight);

            // --- Shields ---
            SpriteGameMan.Add(SpriteGame.Name.Brick, Image.Name.Brick, 50, 25, brickWidth, brickHeight);
            SpriteGameMan.Add(SpriteGame.Name.Brick_LeftTop0, Image.Name.BrickLeft_Top0, 50, 25, brickWidth, brickHeight);
            SpriteGameMan.Add(SpriteGame.Name.Brick_LeftBottom, Image.Name.BrickLeft_Bottom, 50, 25, brickWidth, brickHeight);
            SpriteGameMan.Add(SpriteGame.Name.Brick_RightTop0, Image.Name.BrickRight_Top0, 50, 25, brickWidth, brickHeight);
            SpriteGameMan.Add(SpriteGame.Name.Brick_RightBottom, Image.Name.BrickRight_Bottom, 50, 25, brickWidth, brickHeight);

            // Explosions
            SpriteGameMan.Add(SpriteGame.Name.AlienExplosion, Image.Name.AlienExplosion, 83, 3, 36, 25);
            SpriteGameMan.Add(SpriteGame.Name.SaucerExplosion, Image.Name.SaucerExplosion, 118, 3, 48, 24);
            SpriteGameMan.Add(SpriteGame.Name.PlayerExplosionA, Image.Name.PlayerExplosionA, 7, 25, 39, 24);
            SpriteGameMan.Add(SpriteGame.Name.PlayerExplosionB, Image.Name.PlayerExplosionB, 7, 25, 39, 24);
            SpriteGameMan.Add(SpriteGame.Name.AlienShotExplosion, Image.Name.AlienShotExplosion, 86, 25, 25, 25);

            //-------------------------------------------------------
            // Create SpriteBatch
            //-------------------------------------------------------

            SpriteBatch invadersBatch = SpriteBatchMan.Add(SpriteBatch.Name.SpaceInvaders, 0);
            SpriteBatch boxBatch = SpriteBatchMan.Add(SpriteBatch.Name.Boxes, 0);
            boxBatch.SetDrawEnable(false);
            SpriteBatch invisibleBoxBatch = SpriteBatchMan.Add(SpriteBatch.Name.Aesthetics, 0);
            
            SpriteBatchMan.Add(SpriteBatch.Name.Ship, 0);
            SpriteBatch shipBoxBatch = SpriteBatchMan.Add(SpriteBatch.Name.ShipBox, 0);
            shipBoxBatch.SetDrawEnable(false);
            
            invisibleBoxBatch.SetDrawEnable(false);
            
            SpriteBatchMan.Add(SpriteBatch.Name.Shields, 0);
            SpriteBatchMan.Add(SpriteBatch.Name.Explosions, 5);
            SpriteBatchMan.Add(SpriteBatch.Name.Texts);


            // STN - It is short term new because Factory is garbage collected after LoadContent()
            // since nothing points to it
            AlienFactory AF = new AlienFactory(SpriteBatch.Name.SpaceInvaders);

            float horizontalSpread = 50.0f;
            int numberOfAlienColumns = 11;
            float startX = 86;
            float alienHeight = 400;

            AlienGrid pAlienGrid = (AlienGrid)AF.Create(GameObject.Name.AlienGrid);
            this.alienGrid = pAlienGrid;
            GameObjectNodeMan.Attach(pAlienGrid);


            for (int i = 0; i < numberOfAlienColumns; i++)
            {

                AlienColumn pColA = (AlienColumn)AF.Create(GameObject.Name.AlienColumn);
                pAlienGrid.Add(pColA);

                pColA.Add(AF.Create(GameObject.Name.Octopus, startX + i * horizontalSpread, alienHeight));
                pColA.Add(AF.Create(GameObject.Name.Octopus, startX + i * horizontalSpread, alienHeight + 50));
                pColA.Add(AF.Create(GameObject.Name.Crab, startX + i * horizontalSpread, alienHeight + 100));
                pColA.Add(AF.Create(GameObject.Name.Crab, startX + i * horizontalSpread, alienHeight + 150));
                pColA.Add(AF.Create(GameObject.Name.Squid, startX + i * horizontalSpread, alienHeight + 200));
            }


            //---------------------------------------------------------------------------------------------------------
            // Input
            //---------------------------------------------------------------------------------------------------------

            InputSubject pInputSubject;
            pInputSubject = InputMan.GetArrowRightSubject();
            pInputSubject.Attach(new MoveRightObserver());

            pInputSubject = InputMan.GetArrowLeftSubject();
            pInputSubject.Attach(new MoveLeftObserver());

            pInputSubject = InputMan.GetSpaceSubject();
            pInputSubject.Attach(new ShootObserver());

            Simulation.SetState(Simulation.State.Realtime);

            //---------------------------------------------------------------------------------------------------------
            // Setting up Fonts
            //---------------------------------------------------------------------------------------------------------


            // Credits
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
                Font pPlayerOneScore = FontMan.Add(Font.Name.PlayerOneScore, SpriteBatch.Name.Texts, playerOneScore, Glyph.Name.SpaceInvaders, 63, 700);
                Font pHighScore = FontMan.Add(Font.Name.HighScore, SpriteBatch.Name.Texts, highScore, Glyph.Name.SpaceInvaders, 302, 700);
                Font pPlayerTwoScore = FontMan.Add(Font.Name.PlayerTwoScore, SpriteBatch.Name.Texts, playerTwoScore, Glyph.Name.SpaceInvaders, 540, 700);

                // Bottom Line
                Font pLivesLeft = FontMan.Add(Font.Name.LivesLeft, SpriteBatch.Name.Texts, livesLeft, Glyph.Name.SpaceInvaders, 25, 30);
                Font pCredit = FontMan.Add(Font.Name.Credits, SpriteBatch.Name.Texts, credit, Glyph.Name.SpaceInvaders, 485, 30);
                Font pZeroes = FontMan.Add(Font.Name.Zeroes, SpriteBatch.Name.Texts, creditNumStr, Glyph.Name.SpaceInvaders, 608, 30);

            




            //---------------------------------------------------------------------------------------------------------
            // Bomb
            //---------------------------------------------------------------------------------------------------------

            BombRoot pBombRoot = new BombRoot(GameObject.Name.BombRoot, SpriteGame.Name.NullObject, 0.0f, 0.0f);
            pBombRoot.ActivateSprite(invadersBatch);
            GameObjectNodeMan.Attach(pBombRoot);

            //---------------------------------------------------------------------------------------------------------
            // UFO
            //---------------------------------------------------------------------------------------------------------

            UFORoot pUFORoot = new UFORoot(GameObject.Name.UFORoot, SpriteGame.Name.NullObject, 0.0f, 0.0f);
            pUFORoot.ActivateSprite(invadersBatch);
            GameObjectNodeMan.Attach(pUFORoot);

            //---------------------------------------------------------------------------------------------------------
            // Explosion
            //---------------------------------------------------------------------------------------------------------

            ExplosionRoot pExplosionRoot = new ExplosionRoot();
            pExplosionRoot.ActivateSprite(invadersBatch);
            GameObjectNodeMan.Attach(pExplosionRoot);

            //---------------------------------------------------------------------------------------------------------
            // Walls
            //---------------------------------------------------------------------------------------------------------

            WallGroup pBottomGroup = new WallGroup(GameObject.Name.WallGroup, SpriteGame.Name.NullObject, 0.0f, 0.0f);
            pBottomGroup.ActivateSprite(invadersBatch);

            WallBottom pWallBottom = new WallBottom(GameObject.Name.WallBottom, SpriteGame.Name.Wall, 336, 50, 672, 3); // 672, 768
            pWallBottom.ActivateSprite(invadersBatch);

            WallGroup pSideWallsGroup = new WallGroup(GameObject.Name.WallGroup, SpriteGame.Name.NullObject, 0.0f, 0.0f);

            // Top and Bottom
            WallTop pWallTop = new WallTop(GameObject.Name.WallTop, SpriteGame.Name.NullObject, 300, 768, 700, 1); // 672, 768

            // Create group for side walls for alien grid collision

            WallRight pWallRight = new WallRight(GameObject.Name.WallRight, SpriteGame.Name.NullObject, 672, 300, 0, 768); // 672, 768
            WallLeft pWallLeft = new WallLeft(GameObject.Name.WallLeft, SpriteGame.Name.NullObject, 0, 300, 0, 768); // 672, 768

            pBottomGroup.Add(pWallBottom);
            pSideWallsGroup.Add(pWallRight);
            pSideWallsGroup.Add(pWallLeft);

            GameObjectNodeMan.Attach(pSideWallsGroup);
            GameObjectNodeMan.Attach(pBottomGroup);

            //---------------------------------------------------------------------------------------------------------
            // Bumper
            //---------------------------------------------------------------------------------------------------------

            BumperRoot pBumperRoot = new BumperRoot(GameObject.Name.BumperRoot, SpriteGame.Name.NullObject, 0.0f, 0.0f);


            BumperRight pBumperRight = new BumperRight(GameObject.Name.BumperRight, SpriteGame.Name.NullObject, 670, 300, 0, 768); //(672, 768);
            //pBumperRight.ActivateCollisionSprite(boxBatch);

            BumperLeft pBumperLeft = new BumperLeft(GameObject.Name.BumperLeft, SpriteGame.Name.NullObject, 0, 0, 0, 768);

            // Add to the composite the children
            pBumperRoot.Add(pBumperRight);
            pBumperRoot.Add(pBumperLeft);

            GameObjectNodeMan.Attach(pBumperRoot);

            //---------------------------------------------------------------------------------------------------------
            // Missile
            //---------------------------------------------------------------------------------------------------------

            MissileGroup pMissileGroup = new MissileGroup();
            pMissileGroup.ActivateSprite(invadersBatch);
            //pMissileGroup.ActivateCollisionSprite(boxBatch);

            GameObjectNodeMan.Attach(pMissileGroup);

            //---------------------------------------------------------------------------------------------------------
            // Ship
            //---------------------------------------------------------------------------------------------------------

            // Backups

            Ship leftShip = new Ship(GameObject.Name.ShipLeft, SpriteGame.Name.Ship, 88, 33);
            leftShip.ActivateSprite(invadersBatch);
            leftShip.ActivateCollisionSprite(boxBatch);
            Ship middleShip = new Ship(GameObject.Name.ShipMiddle, SpriteGame.Name.Ship, 133, 33);
            middleShip.ActivateSprite(invadersBatch);
            middleShip.ActivateCollisionSprite(boxBatch);
            Ship rightShip = new Ship(GameObject.Name.ShipRight, SpriteGame.Name.Ship, 178, 33);
            rightShip.ActivateCollisionSprite(boxBatch);
            rightShip.ActivateSprite(invadersBatch);



            ShipRoot pBackupShipRoot = new ShipRoot(GameObject.Name.ShipRootBackup, SpriteGame.Name.NullObject, 0.0f, 0.0f);
            pBackupShipRoot.ActivateSprite(invadersBatch);

            pBackupShipRoot.Add(leftShip);
            pBackupShipRoot.Add(middleShip);
            pBackupShipRoot.Add(rightShip);

            GameObjectNodeMan.Attach(pBackupShipRoot);

            // Real thing
            ShipRoot pShipRoot = new ShipRoot(GameObject.Name.ShipRoot, SpriteGame.Name.NullObject, 0.0f, 0.0f);
            pShipRoot.ActivateSprite(invadersBatch);
            GameObjectNodeMan.Attach(pShipRoot);

            ShipMan.Create();
            this.poShipMan = new ShipMan();
            ShipMan.SetActive(this.poShipMan);

            //---------------------------------------------------------------------------------------------------------
            // Shield 
            //---------------------------------------------------------------------------------------------------------


            float startingX = 91;
            float startingY = 150;
            int numberShields = 4;
            float distanceBetweenShields = 141f;


            GameObject pShieldRoot = ShieldFactory.CreateShields(startingX, startingY, numberShields, distanceBetweenShields);


            //---------------------------------------------------------------------------------------------------------
            // ColPair 
            //---------------------------------------------------------------------------------------------------------

            // Missile vs. Wall
            ColPair pColPair = ColPairMan.Add(ColPair.Name.Missile_Wall, pMissileGroup, pWallTop);
            Debug.Assert(pColPair != null);
            pColPair.Attach(new ShipReadyObserver());
            pColPair.Attach(new ShipRemoveMissileObserver());


            //Alien vs. Missile
            pColPair = ColPairMan.Add(ColPair.Name.Missile_Alien, pMissileGroup, pAlienGrid);
            pColPair.Attach(new RemoveMissileObserver());
            pColPair.Attach(new RemoveAlienObserver(pAlienGrid));
            pColPair.Attach(new ShipReadyObserver());

            // Alien vs. Grid
            pColPair = ColPairMan.Add(ColPair.Name.Alien_Shield, pAlienGrid, pShieldRoot);
            pColPair.Attach(new RemoveBrickObserver());

            // Bumper vs Ship
            pColPair = ColPairMan.Add(ColPair.Name.Bumper_Ship, pBumperRoot, pShipRoot);
            pColPair.Attach(new ShipMoveObserver());

            // Bomb vs Bottom
            pColPair = ColPairMan.Add(ColPair.Name.Bomb_Wall, pBombRoot, pWallBottom);
            pColPair.Attach(new RemoveBombObserver());

            // Bomb vs Shield
            pColPair = ColPairMan.Add(ColPair.Name.Bomb_Shield, pBombRoot, pShieldRoot);
            pColPair.Attach(new RemoveBombObserver());
            pColPair.Attach(new RemoveBrickObserver());

            //Bomb vs Ship
            pColPair = ColPairMan.Add(ColPair.Name.Bomb_Ship, pBombRoot, pShipRoot);
            pColPair.Attach(new RemoveBombObserver());
            pColPair.Attach(new RemoveShipObserver(pAlienGrid, leftShip, middleShip, rightShip));


            // Missile vs Shield
            pColPair = ColPairMan.Add(ColPair.Name.Misslie_Shield, pMissileGroup, pShieldRoot);
            pColPair.Attach(new RemoveMissileObserver());
            pColPair.Attach(new RemoveBrickObserver());
            pColPair.Attach(new ShipReadyObserver());

            // Grid vs. Side Walls
            pColPair = ColPairMan.Add(ColPair.Name.Alien_Wall, pSideWallsGroup, pAlienGrid);
            pColPair.Attach(new GridObserver());

            // Missile vs. Bomb
            pColPair = ColPairMan.Add(ColPair.Name.Missile_Bomb, pMissileGroup, pBombRoot);
            pColPair.Attach(new RemoveMissileObserver());
            pColPair.Attach(new ShipReadyObserver());

            // Missile vs. Bomb
            pColPair = ColPairMan.Add(ColPair.Name.Bomb_Missile, pBombRoot, pMissileGroup);
            pColPair.Attach(new RemoveBombObserver());
            pColPair.Attach(new ShipReadyObserver());

            // Missile vs. UFO
            pColPair = ColPairMan.Add(ColPair.Name.Missile_UFO, pMissileGroup, pUFORoot);
            pColPair.Attach(new RemoveMissileObserver());
            pColPair.Attach(new RemoveUFOObserver());
            pColPair.Attach(new ShipReadyObserver());

            //-------------------------------------------------------
            // Create Timer Events
            //-------------------------------------------------------

            // Squid Animation

            // These are all LTN. All the commands are continually re-added to the TimerEventMan
            // Move Command

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

            // Dagger Animation
            AnimationCmd pDaggerBombCmd = new AnimationCmd(SpriteGame.Name.PlungerShotA, TimerEvent.Name.Animation);
            pDaggerBombCmd.Attach(Image.Name.PlungerShotA);
            pDaggerBombCmd.Attach(Image.Name.PlungerShotB);
            pDaggerBombCmd.Attach(Image.Name.PlungerShotC);
            pDaggerBombCmd.Attach(Image.Name.PlungerShotD);
            TimerEventMan.Add(TimerEvent.Name.Animation, pDaggerBombCmd, .3f);

            // Straight Animation
            AnimationCmd pStraightBombCmd = new AnimationCmd(SpriteGame.Name.RollingShotA, TimerEvent.Name.Animation);
            pStraightBombCmd.Attach(Image.Name.RollingShotA);
            pStraightBombCmd.Attach(Image.Name.RollingShotB);
            pStraightBombCmd.Attach(Image.Name.RollingShotC);
            pStraightBombCmd.Attach(Image.Name.RollingShotD);
            TimerEventMan.Add(TimerEvent.Name.Animation, pStraightBombCmd, .3f);

            // Zig Zag Animation
            AnimationCmd pZigZagBombCmd = new AnimationCmd(SpriteGame.Name.SquigglyShotA, TimerEvent.Name.Animation);
            pZigZagBombCmd.Attach(Image.Name.SquigglyShotA);
            pZigZagBombCmd.Attach(Image.Name.SquigglyShotB);
            pZigZagBombCmd.Attach(Image.Name.SquigglyShotC);
            pZigZagBombCmd.Attach(Image.Name.SquigglyShotD);
            TimerEventMan.Add(TimerEvent.Name.Animation, pZigZagBombCmd, .3f);

            // Player Death Animation
            AnimationCmd pPlayerDeathCmd = new AnimationCmd(SpriteGame.Name.PlayerExplosionA, TimerEvent.Name.Animation);
            pPlayerDeathCmd.Attach(Image.Name.PlayerExplosionB);
            pPlayerDeathCmd.Attach(Image.Name.PlayerExplosionA);
            TimerEventMan.Add(TimerEvent.Name.Animation, pPlayerDeathCmd, .3f);

            MoveCmd moveGrid = new MoveCmd(pAlienGrid);
            TimerEventMan.Add(TimerEvent.Name.Move, moveGrid, 0.5f);


            // SPAWN EVENTS
            BombSpawnEvent bombEventDagger = new BombSpawnEvent(new Random(), pAlienGrid, new FallDagger(), SpriteGame.Name.RollingShotA, GameObject.Name.RollingShot);
            TimerEventMan.Add(TimerEvent.Name.BombSpawn, bombEventDagger, 2f);

            BombSpawnEvent bombEventStraight = new BombSpawnEvent(new Random(), pAlienGrid, new FallStraight(), SpriteGame.Name.PlungerShotA, GameObject.Name.PlungerShot);
            TimerEventMan.Add(TimerEvent.Name.BombSpawn, bombEventStraight, 2f);

            BombSpawnEvent bombEventZigZag = new BombSpawnEvent(new Random(), pAlienGrid, new FallZigZag(), SpriteGame.Name.SquigglyShotA, GameObject.Name.SquigglyShot);
            TimerEventMan.Add(TimerEvent.Name.BombSpawn, bombEventZigZag, 2f);

            UFOSpawnEvent UFOEvent = new UFOSpawnEvent(new Random());
            TimerEventMan.Add(TimerEvent.Name.UFOSpawn, UFOEvent, 2); // Change to 35 when done
        }




        //bool lastKeyE = false;

        public override void Update(float systemTime)
        {
            // Single Step, Free running...
            Simulation.Update(systemTime);

            // Snd update - keeps everything moving and updating smoothly
            SoundNodeMan.Update();

            // Input
            InputMan.Update();
            //Input.ReadKeyboardInput();

            //if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_E) == true && lastKeyE == false)
            //{
            //    GameObject pShieldRoot = ShieldFactory.CreateSingleShield();
            //}
            //lastKeyE = Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_E);




            //// Run based on simulation stepping
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
            SpriteBatchMan.Draw();
        }
        public override void Entering()
        {


            // Update timer since last pause
            float t0 = GlobalTimer.GetTime();
            float t1 = this.TimeAtPause;
            float delta = t0 - t1;
            TimerEventMan.PauseUpdate(delta);
            // We want a different canvas for this scene
            if (SceneContext.roundCount > 0)
            {
                SetUpManagers();
                Initialize();
                //SetShieldGrid();
            }
            SwitchActiveManagers();

        }
        public override void Leaving()
        {

            //if (SceneContext.roundCount > 0)
            //{
               // this.alienGrid.ClearGrid();
                //ShieldFactory.shieldGrid.ClearGrid();
            //}

            // Need a better way to do this
            this.TimeAtPause = GlobalTimer.GetTime();
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
        private ShipMan poShipMan;
        private InputMan poInputMan;
        private GameObjectNodeMan poGameObjectNodeMan;
        private TimerEventMan poTimerEventMan;
        private ColPairMan poColPairMan;
        private DelayedObjectMan poDelayedObjectMan;
        private AlienGrid alienGrid;
        private GameObject pShieldRoot;
    }
}

// --- End of File ---
