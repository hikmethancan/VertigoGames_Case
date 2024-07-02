using _Main.Scripts.UserInterface.Buttons.Abstract;
using UnityEngine.WSA;
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