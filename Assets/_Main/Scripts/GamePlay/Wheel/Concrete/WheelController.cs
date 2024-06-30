using System.Collections.Generic;
using _Main.Scripts.Base.MonoBehaviourBase;
using _Main.Scripts.DISystem.Abstract;
using _Main.Scripts.GamePlay.Item.Abstract;
using _Main.Scripts.GamePlay.Wheel.Abstract;
using _Main.Scripts.GamePlay.Wheel.Concrete.States;
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
            _wheelAnimations = new WheelAnimations(transform, wheelAnimationSo);
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

        public void SpinWheel()
        {
        }

        private void CreateNewItems()
        {
            _currentItems.Clear();
            float angleStep = 360f / 8;
            for (int i = 0; i < wheelSo.howManyItemsWillSpawn; i++)
            {
                float angle = i * angleStep;
                Vector3 position = CalculateItemsSpawnPosition(angle, wheelSo.cardSpawnRadius);
                var item = Instantiate(itemPrefab, position, Quaternion.identity, itemsSpawnParent);
                var rnd = Random.Range(0, _currentPhaseSo.items.Count);
                var itemSo = _currentPhaseSo.items[rnd];
                item.SetupItemData(itemSo);
                _currentItems.Add(item);
            }
        }

        Vector3 CalculateItemsSpawnPosition(float angle, float radius)
        {
            float angleInRadians = angle * Mathf.Deg2Rad;
            float x = Mathf.Cos(angleInRadians) * radius;
            float y = Mathf.Sin(angleInRadians) * radius;
            return new Vector3(x, y, 0) + itemsSpawnParent.position;
        }
    }
}