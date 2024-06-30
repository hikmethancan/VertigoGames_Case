using DG.Tweening;
using UnityEngine;

namespace _Main.Scripts.UserInterface.PhaseUI.Abstract
{
    [CreateAssetMenu(fileName = "Datas", menuName = "Datas/PhaseSo", order = 0)]
    public class PhaseSo : ScriptableObject
    {
        public float phaseImageSpawnOffsetX;
        [Header("Animation Values")] public float moveDuration;
        public Ease moveEase;
    }
}