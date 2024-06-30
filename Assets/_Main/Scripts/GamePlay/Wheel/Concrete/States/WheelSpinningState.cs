using System.Collections;
using _Main.Scripts.Signals;
using _Main.Scripts.StateMachine.Abstract;
using UnityEngine;

namespace _Main.Scripts.GamePlay.Wheel.Concrete.States
{
    public class WheelSpinningState : BaseState<WheelStateManager>
    {
        private Coroutine _spinningCoroutine;

        public WheelSpinningState(WheelStateManager context) : base(context)
        {
        }

        public override void EnterState()
        {
            Debug.Log("Spinning Entered");
            GameSignals.OnReadyForSpinning?.Invoke();
            _spinningCoroutine = _context.WheelController.StartCoroutine(SpinRoutine());
        }

        public override void UpdateState()
        {
        }

        public override void ExitState()
        {
            if (_spinningCoroutine != null)
            {
                _context.WheelController.StopCoroutine(SpinRoutine());
            }
        }

        private IEnumerator SpinRoutine()
        {
            yield return _context.WheelController.WheelAnimations.SpinRoutine();
            
        }
    }
}