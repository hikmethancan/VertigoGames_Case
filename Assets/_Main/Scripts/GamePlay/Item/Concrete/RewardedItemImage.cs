using _Main.Scripts.Base.MonoBehaviourBase;
using UnityEngine;
using UnityEngine.UI;

namespace _Main.Scripts.GamePlay.Item.Concrete
{
    public class RewardedItemImage : Operator
    {
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