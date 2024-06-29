using _Main.Scripts.Base.MonoBehaviourBase;
using _Main.Scripts.GamePlay.Wheel.Abstract;
using _Main.Scripts.GamePlay.Wheel.Concrete.States;
using _Main.Scripts.Signals;
using _Main.Scripts.UserInterface.Buttons.Concrete;
using UnityEngine;

namespace _Main.Scripts.GamePlay.Wheel.Concrete
{
    public class WheelController : Operator
    {
        [SerializeField] private WheelControllerSo wheelControllerSo;
        [SerializeField] private WheelAnimationSo wheelAnimationSo;
        [SerializeField] private SpinningButton spinButton;


        private WheelAnimations _wheelAnimations;
        private WheelStateManager _wheelStateManager;
        protected override void Setup()
        {
        }

        protected override void Register(bool isActive)
        {
            base.Register(isActive);
            if (isActive)
                GameSignals.OnSpinningButtonClicked += BeginWheelSpinning;
            else
                GameSignals.OnSpinningButtonClicked -= BeginWheelSpinning;
        }

        private void BeginWheelSpinning()
        {
            _wheelAnimations.SpinWheel();
        }

        public void SetupWheelData(int phaseIndex)
        {
            
        }

        public void SpinWheel()
        {
            
        }
    }
}