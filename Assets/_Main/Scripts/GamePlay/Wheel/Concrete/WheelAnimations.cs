using _Main.Scripts.GamePlay.Wheel.Abstract;
using UnityEngine;

namespace _Main.Scripts.GamePlay.Wheel.Concrete
{
    public class WheelAnimations
    {
        #region WheelReferences

        private Transform _wheelTransform;
        private WheelAnimationSo _wheelAnimationSo;

        #endregion
        

        public WheelAnimations(Transform wheelTransform, WheelAnimationSo wheelAnimationSo)
        {
            _wheelTransform = wheelTransform;
            _wheelAnimationSo = wheelAnimationSo;
        }

        public void SpinWheel()
        {
            
        }

        public void PlayWheelDataSetupAnimation()
        {
            
        }
    }
}