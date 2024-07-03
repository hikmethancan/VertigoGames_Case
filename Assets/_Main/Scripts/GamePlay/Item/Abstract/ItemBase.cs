using System;
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
        private float _initWidthValue;
        private float _initHeightValue;
        private int _count;
        public int RewardRewardCount => _count;

        protected override void OnEnable()
        {
            base.OnEnable();
            PlaySpawnedAnimation();
            
        }

        protected override void Awake()
        {
            base.Awake();
            var rect = itemImage.rectTransform.rect;
            _initWidthValue = rect.width;
            _initHeightValue = rect.height;
        }

        public bool IsEqualItemType(ItemBase targetItem)
        {
            if (ItemData.itemType != targetItem.ItemData.itemType)
                return false;

            return ItemData.itemType switch
            {
                CardItemType.Chest => ItemData.chestType == targetItem.ItemData.chestType,
                CardItemType.Weapon => ItemData.weaponType == targetItem.ItemData.weaponType,
                CardItemType.Point => ItemData.pointType == targetItem.ItemData.pointType,
                _ => true
            };
        }


        protected override void Setup()
        {
        }

        public void SetupItemData(ItemSo itemSo)
        {
            itemImage.sprite = itemSo.itemSprite;
            _count = itemSo.spawnCount;
            _itemSo = itemSo;
            CheckIfTypeDeath();
            SetItemCountText();
        }

        private void StretchImage(bool isDeath)
        {
            var rectTransform = itemImage.rectTransform;
            if (isDeath)
            {
                rectTransform.sizeDelta = new Vector2(100f, 100f);
            }
            else
            {
                rectTransform.sizeDelta = new Vector2(_initWidthValue, _initHeightValue);
            }
        }
        private void CheckIfTypeDeath()
        {
            bool isDeathType = _itemSo.itemType == CardItemType.Death;
            ActivateCountText(isDeathType);
            StretchImage(isDeathType);
        }

        private void ActivateCountText(bool activate)
        {
            itemCountText.gameObject.SetActive(!activate);
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