using System.Threading.Tasks;
using _Main.Scripts.Signals;
using _Main.Scripts.StateMachine.Abstract;
using UnityEngine;

namespace _Main.Scripts.GamePlay.Wheel.Concrete.States
{
    public class WheelStateManager : BaseStateManager<WheelStateManager>
    {
        #region Publics

        public WheelController WheelController => _wheelController;
        private WheelController _wheelController;

        #region States

        private WheelSpinningState SpinningState { get; set; }
        private WheelIdleState IdleState { get; set; }
        private WheelRewardState WheelRewardState { get; set; }
        private WheelPhaseChangingState WheelPhaseChangingState { get; set; }

        #endregion

        #endregion

        protected override void Register(bool isActive)
        {
            base.Register(isActive);
            if (isActive)
            {
                GameSignals.OnSpinningButtonClicked += Spin;
            }
            else
            {
                GameSignals.OnSpinningButtonClicked -= Spin;
            }
        }

        private void Spin()
        {
            SwitchState(SpinningState);
        }

        protected override void Start()
        {
            Setup();
            _initialState = IdleState;
            base.Start();
        }

        protected override void InitializeStates()
        {
            SpinningState = new WheelSpinningState(this);
            IdleState = new WheelIdleState(this);
            WheelRewardState = new WheelRewardState(this);
            WheelPhaseChangingState = new WheelPhaseChangingState(this);
        }

        protected override void Setup()
        {
            TryGetComponent(out _wheelController);
        }
    }
}