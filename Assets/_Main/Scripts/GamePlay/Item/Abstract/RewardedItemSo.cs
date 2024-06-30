using DG.Tweening;
using UnityEngine;

namespace _Main.Scripts.GamePlay.Item.Abstract
{
    [CreateAssetMenu(fileName = "Datas", menuName = "Datas/RewardedItemSo", order = 0)]
    public class RewardedItemSo : ScriptableObject
    {
        public float moveDuration;
        public Ease moveEase;
    }
}