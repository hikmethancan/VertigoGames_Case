using _Main.Scripts.UserInterface.Buttons.Abstract;
using UnityEngine;

namespace _Main.Scripts.UserInterface.DeathPanel.Concrete
{
    public class RetryButton : ButtonsBase
    {
        protected override void Register(bool isActive)
        {
            base.Register(isActive);
        }

        protected override void OnButtonClicked()
        {
            Retry();
        }

        private void Retry()
        {
            Debug.Log("Retry Action");
        }
    }
}