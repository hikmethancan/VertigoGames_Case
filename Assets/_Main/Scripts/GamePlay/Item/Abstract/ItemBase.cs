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


        public CardItemType itemType;

        public ItemSo ItemData => _itemSo;
        private ItemSo _itemSo;


        public RectTransform RectTransform =>
            _rectTransform ? _rectTransform : (_rectTransform = GetComponent<RectTransform>());

        private RectTransform _rectTransform;

        protected override void OnEnable()
        {
            base.OnEnable();
            PlaySpawnedAnimation();
        }

        protected override void Setup()
        {
            
        }

        public void SetupItemData(ItemSo itemSo)
        {
            itemImage.sprite = itemSo.itemSprite;
            itemCountText.SetText($"{itemSo.spawnCount}");
            _itemSo = itemSo;
        }

        protected virtual void PlaySpawnedAnimation()
        {
            Debug.Log("scale");
            transform.DOScale(Vector3.one * 1.3f, 0.3f).SetLoops(2, LoopType.Yoyo);
        }
    }
}