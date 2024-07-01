using _Main.Scripts.Signals;
using _Main.Scripts.UserInterface.Buttons.Abstract;

namespace _Main.Scripts.UserInterface.Buttons.Concrete
{
    public class ExitButton : ButtonsBase
    {
        protected override void OnButtonClicked()
        {
            ExitAction();
        }

        protected override void Register(bool isActive)
        {
            base.Register(isActive);
            if (isActive)
                GameSignals.OnExitButtonActivate += ReadyForExit;
            else
                GameSignals.OnExitButtonActivate -= ReadyForExit;
        }

        private void ReadyForExit()
        {
            SetInteractable(true);
        }

        private void ExitAction()
        {
            SetInteractable(false);
        }
    }
}