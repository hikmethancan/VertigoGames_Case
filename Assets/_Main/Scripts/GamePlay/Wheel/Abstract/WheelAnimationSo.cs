using DG.Tweening;
using UnityEngine;

namespace _Main.Scripts.GamePlay.Wheel.Abstract
{
    [CreateAssetMenu(fileName = "Datas", menuName = "Datas/WheelAnimationSo", order = 0)]
    public class WheelAnimationSo : ScriptableObject
    {
        [Header("Spinning Animation Data")] public float spinningDuration;
        public Ease spinningAnimationEase;
        public RotateMode spinningRotateMode;
        public int spinningTourCount;
    }
}