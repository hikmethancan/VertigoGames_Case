using System.Collections;
using _Main.Scripts.GamePlay.Wheel.Abstract;
using DG.Tweening;
using UnityEngine;

namespace _Main.Scripts.GamePlay.Wheel.Concrete
{
    public class WheelAnimations
    {
        #region WheelReferences

        private WheelController _wheelController;
        private Transform _wheelTransform;
        private WheelAnimationSo _wheelAnimationSo;

        #endregion


        public WheelAnimations(Transform wheelTransform, WheelAnimationSo wheelAnimationSo,
            WheelController wheelController)
        {
            _wheelTransform = wheelTransform;
            _wheelAnimationSo = wheelAnimationSo;
            _wheelController = wheelController;
        }

        public void SpinWheel()
        {
        }

        public void PlayWheelDataSetupAnimation()
        {
        }

        public IEnumerator SpinRoutine(WheelSpinResultData wheelSpinResultData)
        {
            var tourCount = _wheelAnimationSo.spinningTourCount;
            int segmentCount = _wheelController.WheelSo.howManyItemsWillSpawn;
            float anglePerSegment = 360f / segmentCount;
            float itemAngle = 360f - anglePerSegment * wheelSpinResultData.index;
            var tourAngle = tourCount * 360f;
            var targetRotateAngle = itemAngle + tourAngle;
            var wheelControllerTransform = _wheelController.transform;
            yield return wheelControllerTransform
                .DORotate(Vector3.forward * targetRotateAngle, _wheelAnimationSo.spinningDuration,
                    _wheelAnimationSo.spinningRotateMode).SetEase(_wheelAnimationSo.spinningAnimationEase)
                .WaitForCompletion();
        }
    }
}