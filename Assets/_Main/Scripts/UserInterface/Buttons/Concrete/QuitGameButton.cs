using _Main.Scripts.UserInterface.Buttons.Abstract;
using Application = UnityEngine.Application;

namespace _Main.Scripts.UserInterface.Buttons.Concrete
{
    public class QuitGameButton : ButtonsBase
    {
        protected override void OnButtonClicked()
        {
            QuitGame();
        }

        private void QuitGame()
        {
            Application.Quit();
        }
    }
}