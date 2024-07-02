using _Main.Scripts.Base.MonoBehaviourBase;
using DG.Tweening;
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


        public ItemSo ItemData => _itemSo;
        private ItemSo _itemSo;


        public RectTransform RectTransform =>
            _rectTransform ? _rectTransform : (_rectTransform = GetComponent<RectTransform>());

        private RectTransform _rectTransform;

        private int _count;
        public int RewardRewardCount => _count;

        protected override void OnEnable()
        {
            base.OnEnable();
            PlaySpawnedAnimation();
        }

        public bool IsEqualItemType(object obj)
        {
            if (obj is ItemBase other)
            {
                if (ItemData.itemType != other.ItemData.itemType)
                    return false;

                switch (ItemData.itemType)
                {
                    case CardItemType.Chest:
                        return ItemData.chestType == other.ItemData.chestType;
                    case CardItemType.Weapon:
                        return ItemData.weaponType == other.ItemData.weaponType;
                    case CardItemType.Point:
                        return ItemData.pointType == other.ItemData.pointType;
                    default:
                        return true; // For types like Cash, Gold, Death which don't have subtypes
                }
            }

            return false;
        }


        protected override void Setup()
        {
        }

        public void SetupItemData(ItemSo itemSo)
        {
            itemImage.sprite = itemSo.itemSprite;
            _count = itemSo.spawnCount;
            _itemSo = itemSo;
            SetItemCountText();
        }

        private void SetItemCountText()
        {
            itemCountText.SetText($"{_count}");
        }

        public void RewardedSetup()
        {
            _count = 0;
            SetItemCountText();
        }

        public void IncreaseItemCount(int increaseCount)
        {
            var targetCount = _count + increaseCount;
            DOVirtual.Int(_count, targetCount, 0.5f, x =>
            {
                itemCountText.SetText($"{x}");
                _count = x;
            });
        }

        protected virtual void PlaySpawnedAnimation()
        {
            transform.DOScale(Vector3.one * 1.3f, 0.3f).SetLoops(2, LoopType.Yoyo);
        }
    }
}