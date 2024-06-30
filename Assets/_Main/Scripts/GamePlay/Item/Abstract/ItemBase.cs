using _Main.Scripts.Base.MonoBehaviourBase;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Main.Scripts.GamePlay.Item.Abstract
{
    public abstract class ItemBase : Operator
    {
        [Header("References")] [SerializeField]
        private Image itemImage;

        [SerializeField] private TMP_Text itemCountText;


        public CardItemType itemType;

        public ItemSo ItemData => _itemSo;
        private ItemSo _itemSo;


        public RectTransform RectTransform =>
            _rectTransform ? _rectTransform : (_rectTransform = GetComponent<RectTransform>());

        private RectTransform _rectTransform;

        protected override void Setup()
        {
        }

        public void SetupItemData(ItemSo itemSo)
        {
            itemImage.sprite = itemSo.itemSprite;
            itemCountText.SetText($"{itemSo.spawnCount}");
            _itemSo = itemSo;
        }
    }
}