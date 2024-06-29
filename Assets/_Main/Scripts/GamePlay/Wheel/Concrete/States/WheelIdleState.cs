using _Main.Scripts.StateMachine.Abstract;

namespace _Main.Scripts.GamePlay.Wheel.Concrete.States
{
    public class WheelIdleState : BaseState<WheelStateManager>
    {
        public WheelIdleState(WheelStateManager context) : base(context)
        {
        }

        public override void EnterState()
        {
            _context.wheelController.SetupWheelData(0);
        }

        public override void UpdateState()
        {
        }

        public override void ExitState()
        {
        }
    }
}