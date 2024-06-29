using _Main.Scripts.StateMachine.Abstract;

namespace _Main.Scripts.GamePlay.Wheel.Concrete.States
{
    public class WheelStateManager : BaseStateManager<WheelStateManager>
    {
        #region Publics

        private WheelSpinningState SpinningState { get; set; }
        private WheelIdleState IdleState { get; set; }

        #endregion


        protected override void Start()
        {
            base.Start();
            SwitchState(IdleState);
        }

        protected override void InitializeStates()
        {
            SpinningState = new WheelSpinningState(this);
            IdleState = new WheelIdleState(this);
        }

        protected override void Setup()
        {
            
        }
    }
}