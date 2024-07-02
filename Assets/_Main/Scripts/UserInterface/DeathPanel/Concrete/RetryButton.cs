using _Main.Scripts.SceneSystem.Concrete;
using _Main.Scripts.Signals;
using _Main.Scripts.UserInterface.Buttons.Abstract;
using UnityEngine;

namespace _Main.Scripts.UserInterface.DeathPanel.Concrete
{
    public class RetryButton : ButtonsBase
    {
        protected override void Register(bool isActive)
        {
            base.Register(isActive);
            if (isActive)
            {
            }
        }

        protected override void OnButtonClicked()
        {
            Retry();
        }

        private void Retry()
        {
            SceneHandler.LoadGameScene();
        }
    }
}