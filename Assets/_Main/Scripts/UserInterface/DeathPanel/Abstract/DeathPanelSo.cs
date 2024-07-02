using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

namespace _Main.Scripts.UserInterface.DeathPanel.Abstract
{
    [CreateAssetMenu(fileName = "Datas", menuName = "Datas/DeathPanelSo", order = 0)]
    public class DeathPanelSo : ScriptableObject
    {
        [Header("Panel Text Values")] [ResizableTextArea]
        public string deathText;

        [Space(20f)] [Header("Animation Datas")]
        public float scaleDuration;

        public Ease scaleEase;
        [Space(20f)] [Header("Amount Datas")] public int coinAmount;
    }
}