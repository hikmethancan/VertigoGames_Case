using _Main.Scripts.Signals;
using _Main.Scripts.UserInterface.Buttons.Abstract;

namespace _Main.Scripts.UserInterface.Buttons.Concrete
{
    public class SpinningButton : ButtonsBase
    {
        protected override void OnButtonClicked()
        {
            SpinAction();
        }

        protected override void Register(bool isActive)
        {
            base.Register(isActive);
            if (isActive)
                GameSignals.OnReadyForSpinning += ReadyForSpin;
            else
                GameSignals.OnReadyForSpinning -= ReadyForSpin;
        }

        private void ReadyForSpin()
        {
            SetInteractable(true);
        }

        private void SpinAction()
        {
            SetInteractable(false);
            GameSignals.OnSpinningButtonClicked?.Invoke();
        }
    }
}