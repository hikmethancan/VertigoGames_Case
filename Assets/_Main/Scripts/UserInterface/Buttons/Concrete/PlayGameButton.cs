using _Main.Scripts.SceneSystem.Concrete;
using _Main.Scripts.UserInterface.Buttons.Abstract;

namespace _Main.Scripts.UserInterface.Buttons.Concrete
{
    public class PlayGameButton : ButtonsBase
    {
        protected override void OnButtonClicked()
        {
            PlayGame();
        }

        private void PlayGame()
        {
            SceneHandler.LoadGameScene();
        }
    }
}