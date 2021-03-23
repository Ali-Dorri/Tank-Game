using UnityEngine.SceneManagement;

namespace Adop.TankGame.Utility
{
    public static class LevelManager
    {
        public static void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public static void GotoNextLevel()
        {
            int levelIndex = SceneManager.GetActiveScene().buildIndex;
            levelIndex = (levelIndex + 1) % SceneManager.sceneCountInBuildSettings;
            SceneManager.LoadScene(levelIndex);
        }
    }
}
