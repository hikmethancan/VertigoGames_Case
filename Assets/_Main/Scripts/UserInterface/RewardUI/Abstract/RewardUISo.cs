using DG.Tweening;
using UnityEngine;

namespace _Main.Scripts.UserInterface.RewardUI.Abstract
{
    [CreateAssetMenu(fileName = "Datas", menuName = "Datas/RewardUISo", order = 0)]
    public class RewardUISo : ScriptableObject
    {
        public float moveDuration;
        public Ease moveEase;
    }
}