using _Main.Scripts.GamePlay.Wheel.Abstract;
using _Main.Scripts.Signals;
using _Main.Scripts.StateMachine.Abstract;
using UnityEngine;

namespace _Main.Scripts.GamePlay.Wheel.Concrete.States
{
    public class WheelIdleState : BaseState<WheelStateManager>
    {
        public WheelIdleState(WheelStateManager context) : base(context)
        {
        }

        public override void EnterState()
        {
            GameSignals.OnReadyForSpinning?.Invoke();
            _context.WheelController.SetupWheelData();
        }

        public override void UpdateState()
        {
        }

        public override void ExitState()
        {
        }
    }
}