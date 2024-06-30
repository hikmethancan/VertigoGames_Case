using System.Collections.Generic;
using System.Linq;
using _Main.Scripts.Base.MonoBehaviourBase;
using _Main.Scripts.DISystem.Abstract;
using _Main.Scripts.GamePlay.Item.Abstract;
using _Main.Scripts.GamePlay.Wheel.Abstract;
using _Main.Scripts.GamePlay.Wheel.Concrete.States;
using _Main.Scripts.PoolSystem.Abstract;
using _Main.Scripts.Signals;
using _Main.Scripts.UserInterface.Buttons.Concrete;
using NaughtyAttributes;
using UnityEngine;

namespace _Main.Scripts.GamePlay.Wheel.Concrete
{
    public class WheelController : Operator
    {
        #region Publics

        public WheelSo WheelSo => wheelSo;
        public WheelAnimations WheelAnimations => _wheelAnimations;

        #endregion


        #region SerializeFields

        [SerializeField] private WheelSo wheelSo;
        [SerializeField] private WheelAnimationSo wheelAnimationSo;
        [SerializeField] private SpinningButton spinButton;
        [SerializeField] private ItemBase itemPrefab;
        [ShowAssetPreview] [SerializeField] private Transform itemsSpawnParent;

        #endregion


        #region Privates

        private WheelAnimations _wheelAnimations;
        private WheelStateManager _wheelStateManager;
        private WheelPhaseSo _currentPhaseSo;
        private List<ItemBase> _currentItems = new();

        #endregion


        protected override void Setup()
        {
            _wheelAnimations = new WheelAnimations(transform, wheelAnimationSo, this);
            TryGetComponent(out _wheelStateManager);
        }

        protected override void Register(bool isActive)
        {
            base.Register(isActive);
            if (isActive)
                GameSignals.OnSpinningButtonClicked += BeginWheelSpinning;
            else
                GameSignals.OnSpinningButtonClicked -= BeginWheelSpinning;
        }

        private void BeginWheelSpinning()
        {
            _wheelAnimations.SpinWheel();
        }

        public void SetupWheelData(WheelType wheelType)
        {
            _currentPhaseSo = ScriptableObject.CreateInstance<WheelPhaseSo>();
            _currentPhaseSo = DIContainer.Instance.GetWheelPhaseData(wheelType);
            CreateNewItems();
        }

        public WheelSpinResultData GetWheelItemSpinResulData()
        {
            int totalPossibility = _currentItems.Sum(item => item.ItemData.spawnPossibility);

            int randomValue = Random.Range(0, totalPossibility);

            int cumulativePossibility = 0;
            for (var i = 0; i < _currentItems.Count; i++)
            {
                var item = _currentItems[i];
                cumulativePossibility += item.ItemData.spawnPossibility;
                if (randomValue < cumulativePossibility)
                {
                    return new WheelSpinResultData
                    {
                        item = _currentItems[i],
                        itemType = item.itemType,
                        itemCount = item.ItemData.spawnCount,
                        index = i
                    };
                }
            }

            return default(WheelSpinResultData);
        }

        public ItemSo GetItem()
        {
            List<ItemSo> items = _currentPhaseSo.items;

            int totalPossibility = items.Sum(item => item.spawnPossibility);

            int randomValue = Random.Range(0, totalPossibility);

            int cumulativePossibility = 0;
            foreach (ItemSo item in items)
            {
                cumulativePossibility += item.spawnPossibility;
                if (randomValue < cumulativePossibility)
                {
                    return item;
                }
            }

            return default(ItemSo);
        }

        private void CreateNewItems()
        {
            _currentItems.Clear();
            float angleStep = 360f / 8;
            for (int i = 0; i < wheelSo.howManyItemsWillSpawn; i++)
            {
                float angle = i * angleStep;
                Vector3 position = CalculateItemsSpawnPosition(angle, wheelSo.cardSpawnRadius);
                var item = PoolManager.Instance.ItemPool.Get();
                Transform itemTransform;
                (itemTransform = item.transform).SetParent(itemsSpawnParent);
                itemTransform.position = position;
                itemTransform.localScale = Vector3.one;
                item.SetupItemData(GetItem());
                _currentItems.Add(item);
                item.gameObject.SetActive(true);
            }
        }

        Vector3 CalculateItemsSpawnPosition(float angle, float radius)
        {
            float angleInRadians = angle * Mathf.Deg2Rad;
            float x = Mathf.Cos(angleInRadians) * radius;
            float y = Mathf.Sin(angleInRadians) * radius;
            return new Vector3(x, y, 0) + itemsSpawnParent.position;
        }


        public void ChangeItemsForPhase()
        {
            foreach (var currentItem in _currentItems)
            {
                PoolManager.Instance.ItemPool.ReturnToPool(currentItem);
            }
        }
    }
}