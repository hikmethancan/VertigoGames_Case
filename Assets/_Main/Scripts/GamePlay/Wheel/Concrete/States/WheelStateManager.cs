using _Main.Scripts.Signals;
using _Main.Scripts.StateMachine.Abstract;

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

        #endregion

        #endregion

        protected override void Register(bool isActive)
        {
            base.Register(isActive);
            if (isActive)
            {
                GameSignals.OnSpinningButtonClicked += Spin;
                GameSignals.OnItemRewardedFinish += SetupToNextPhase;
            }
            else
            {
                GameSignals.OnSpinningButtonClicked -= Spin;
                GameSignals.OnItemRewardedFinish -= SetupToNextPhase;
            }
        }

        private void SetupToNextPhase()
        {
            SwitchState(IdleState);
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
        }

        protected override void Setup()
        {
            TryGetComponent(out _wheelController);
        }
    }
}