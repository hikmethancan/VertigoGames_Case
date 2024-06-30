using _Main.Scripts.Base.MonoBehaviourBase;
using _Main.Scripts.GamePlay.Item.Abstract;
using UnityEngine;
using UnityEngine.UI;

namespace _Main.Scripts.GamePlay.Item.Concrete
{
    public class RewardedItemImage : Operator
    {
        public RectTransform RectTransform => rectTransform;


        [SerializeField] private RewardedItemSo rewardedItemSo;
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private Image itemImage;

        protected override void Setup()
        {
        }

        public void SetItem(Sprite sprite)
        {
            itemImage.sprite = sprite;
        }
    }
}