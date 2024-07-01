using _Main.Scripts.DataSystem.Concrete;
using _Main.Scripts.Signals;
using _Main.Scripts.UserInterface.Buttons.Abstract;

namespace _Main.Scripts.UserInterface.DeathPanel.Concrete
{
    public class ContinueGameButton : ButtonsBase
    {
        private int _cost;

        protected override void Register(bool isActive)
        {
            base.Register(isActive);
        }

        protected override void OnButtonClicked()
        {
            Continue();
        }

        public void SetCost(int cost)
        {
            _cost = cost;
        }

        private void Continue()
        {
            if (DataManager.Money <= _cost)
            {
                return;
            }

            GameSignals.OnContinueButtonClicked?.Invoke();
            DataManager.Money -= _cost;
            GameSignals.OnSetCoinAmount?.Invoke();
            GameSignals.OnSwitchPhaseState?.Invoke();
            GameSignals.OnItemRewardedFinish?.Invoke();
        }
    }
}