using _Main.Scripts.Signals;
using _Main.Scripts.UserInterface.Buttons.Abstract;
using UnityEngine;

namespace _Main.Scripts.UserInterface.Buttons.Concrete
{
    public class SpinningButton : ButtonsBase
    {
        protected override void OnButtonClicked()
        {
            SpinAction();
        }

        private void SpinAction()
        {
            Debug.Log("Clicked");
            SetInteractable(false);
            GameSignals.OnSpinningButtonClicked?.Invoke();
        }
    }
}