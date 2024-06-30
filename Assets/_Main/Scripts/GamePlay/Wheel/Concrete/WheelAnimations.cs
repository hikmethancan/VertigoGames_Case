using System.Collections;
using _Main.Scripts.GamePlay.Wheel.Abstract;
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

        public IEnumerator SpinRoutine()
        {
            float duration = 2f;
            float time = 0;
            int segmentCount = _wheelController.WheelSo.howManyItemsWillSpawn;
            float anglePerSegment = 360f / segmentCount;
            float randomAngle = Random.Range(0, 360f);
            var wheelControllerTransform = _wheelController.transform;
            float targetAngle = wheelControllerTransform.eulerAngles.z + 720f + randomAngle;

            while (time < duration)
            {
                time += Time.deltaTime;
                float angle = Mathf.Lerp(wheelControllerTransform.eulerAngles.z, targetAngle, time / duration);
                wheelControllerTransform.eulerAngles = new Vector3(0, 0, angle);
                yield return null;
            }

            float finalAngle = wheelControllerTransform.eulerAngles.z % 360f;
            int finalSegmentIndex = (int)(finalAngle / anglePerSegment);
            // _controller.HandleSegment(_controller.WheelSegments[finalSegmentIndex]);
            //
            // _controller.StateMachine.SetState(new IdleState(_controller));
        }
    }
}