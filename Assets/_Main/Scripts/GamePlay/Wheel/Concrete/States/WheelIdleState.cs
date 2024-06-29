using System.Threading.Tasks;
using _Main.Scripts.GamePlay.Wheel.Abstract;
using _Main.Scripts.StateMachine.Abstract;
using UnityEngine;

namespace _Main.Scripts.GamePlay.Wheel.Concrete.States
{
    public class WheelIdleState : BaseState<WheelStateManager>
    {
        public WheelIdleState(WheelStateManager context) : base(context)
        {
        }

        public override async void EnterState()
        {
            _context.WheelController.SetupWheelData(WheelType.Bronze);
        }

        public override void UpdateState()
        {
        }

        public override void ExitState()
        {
        }
    }
}