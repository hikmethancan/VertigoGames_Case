using _Main.Scripts.Signals;
using _Main.Scripts.StateMachine.Abstract;

namespace _Main.Scripts.GamePlay.Wheel.Concrete.States
{
    public class WheelSpinningState : BaseState<WheelStateManager>
    {
        public WheelSpinningState(WheelStateManager context) : base(context)
        {
        }

        public override void EnterState()
        {
            GameSignals.OnReadForSpinning?.Invoke();
        }

        public override void UpdateState()
        {
        }

        public override void ExitState()
        {
        }
    }
}