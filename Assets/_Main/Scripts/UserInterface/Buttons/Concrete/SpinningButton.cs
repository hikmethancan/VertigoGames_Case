using _Main.Scripts.Signals;
using _Main.Scripts.UserInterface.Buttons.Abstract;

namespace _Main.Scripts.UserInterface.Buttons.Concrete
{
    public class SpinningButton : ButtonsBase
    {
        protected override void OnButtonClicked()
        {
            base.OnButtonClicked();
            
        }

        private void SpinAction()
        {
            SetInteractable(false);
            GameSignals.OnSpinningButtonClicked?.Invoke();
        }
    }
}