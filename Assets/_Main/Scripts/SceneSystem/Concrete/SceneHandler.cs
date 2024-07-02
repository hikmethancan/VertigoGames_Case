using UnityEngine.SceneManagement;

namespace _Main.Scripts.SceneSystem.Concrete
{
    public static class SceneHandler
    {
        public static void LoadMenuScene()
        {
            SceneManager.LoadScene(SceneNames.MainMenuScene.ToString());
        }

        public static void LoadGameScene()
        {
            SceneManager.LoadScene(SceneNames.WheelOfFortuneScene.ToString());
        }
    }
}