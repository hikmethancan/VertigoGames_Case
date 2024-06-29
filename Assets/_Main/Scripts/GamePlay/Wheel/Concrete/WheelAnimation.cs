using System.Threading.Tasks;
using _Main.Scripts.GamePlay.Wheel.Abstract;
using UnityEngine;

namespace _Main.Scripts.GamePlay.Wheel.Concrete
{
    public class WheelAnimation
    {
        private Transform _wheelTransform;
        private WheelAnimationSo _wheelAnimationSo;

        public WheelAnimation(Transform wheelTransform, WheelAnimationSo wheelAnimationSo)
        {
            _wheelTransform = wheelTransform;
            _wheelAnimationSo = wheelAnimationSo;
        }
        public async Task SpinWheel()
        {
        }
    }
}