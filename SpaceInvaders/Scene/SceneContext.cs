//-----------------------------------------------------------------------------
// 
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SceneContext
    {
        public enum Scene
        {
            Select,
            Play,
            Over
        }
        private SceneContext()
        {
            // Set scores
            SceneContext.currentScore = 0;
            SceneContext.highScore = 0;
            SceneContext.livesLeft = 3;
            SceneContext.roundCount = 0;

            // reserve the states
            SceneContext.poSceneSelect = new SceneSelect(this);
            SceneContext.poScenePlay = new ScenePlay(this);
            SceneContext.poSceneOver = new SceneOver(this);



            // initialize to the select state
            SceneContext.pSceneState = SceneContext.poSceneSelect;
            SceneContext.pSceneState.Entering();


        }

        public static void Create()
        {
            Debug.Assert(psInstance == null);
            
            if (psInstance == null)
            {
                psInstance = new SceneContext(); // LTN - this
            }

        }

        private static SceneContext privGetInstance()
        {
            // Safety - this forces users to call Create() first before using class
            Debug.Assert(psInstance != null);

            return psInstance;
        }

        public static SceneState GetState()
        {
            return SceneContext.pSceneState;
        }

        public static string GetScore()
        {
            return SceneContext.currentScore.ToString();
        }
        public static int GetScoreInt()
        {
            return SceneContext.currentScore;
        }

        public static void SetScore(int score)
        {
            SceneContext.currentScore = score;
        }

        public static string GetHighScore()
        {
            return SceneContext.highScore.ToString();
        }

        public static int GetHighScoreInt()
        {
            return SceneContext.highScore;
        }

        public static void SetHighScore(int highScore)
        {
            SceneContext.highScore = highScore;
        }

        public static string GetLivesLeft()
        {
            int life = SceneContext.livesLeft;
            return SceneContext.livesLeft.ToString();
        }

        public static int GetLivesLeftInt()
        {
            return SceneContext.livesLeft;
        }

        public static void SetLivesLeft(int livesLeft)
        {
            SceneContext.livesLeft = livesLeft;
        }



        public static void SetState(Scene eScene)
        {
            switch (eScene)
            {
                case Scene.Select:
                    SceneContext.pSceneState.Leaving();
                    SceneContext.pSceneState = SceneContext.poSceneSelect;
                    SceneContext.pSceneState.Entering();
                    break;

                case Scene.Play:
                    SceneContext.pSceneState.Leaving();
                    SceneContext.pSceneState = SceneContext.poScenePlay;
                    SceneContext.pSceneState.Entering();
                    break;

                case Scene.Over:
                    SceneContext.pSceneState.Leaving();
                    SceneContext.pSceneState = SceneContext.poSceneOver;
                    SceneContext.pSceneState.Entering();
                    break;
            }
        }


        // ----------------------------------------------------
        // Data: 
        // -------------------------------------------o---------
        private static SceneContext psInstance = null;
        private static SceneState pSceneState;
        private static SceneSelect poSceneSelect;
        private static SceneOver poSceneOver;
        private static ScenePlay poScenePlay;
        private static int currentScore;
        private static int highScore;
        private static int livesLeft;
        public static int roundCount;

        
    }
}

// --- End of File ---