using System.Collections.Generic;
using System.Linq;
using _Main.Scripts.Base.MonoBehaviourBase;
using _Main.Scripts.GamePlay.Item.Abstract;
using _Main.Scripts.PoolSystem.Abstract;
using _Main.Scripts.Signals;
using DG.Tweening;
using UnityEngine;

namespace _Main.Scripts.UserInterface.RewardUI.Concrete
{
    public class RewardUIController : Operator
    {
        [SerializeField] private Transform container;


        private readonly List<ItemBase> _rewardedItems = new();

        protected override void Setup()
        {
        }

        protected override void Register(bool isActive)
        {
            base.Register(isActive);
            if (isActive)
                GameSignals.OnNewItemGained += AddNewItem;
            else
                GameSignals.OnNewItemGained -= AddNewItem;
        }

        private void AddNewItem(ItemBase tempItem)
        {
            if (_rewardedItems.Any(x => x.name == tempItem.name)) return;

            var item = PoolManager.Instance.ItemPool.Get();
            item.SetupItemData(tempItem.ItemData);
            Transform itemTransform;
            (itemTransform = item.transform).SetParent(container);
            itemTransform.localScale = Vector3.one;
            item.gameObject.SetActive(true);
            var itemParticle = PoolManager.Instance.RewardedItemPool.Get();
            itemParticle.SetItem(item.ItemData.itemSprite);
            Transform itemParticleTransform;
            (itemParticleTransform = itemParticle.transform).SetParent(transform);
            itemParticleTransform.localScale = Vector3.one;
            itemParticle.RectTransform.position = tempItem.RectTransform.position;
            itemParticle.gameObject.SetActive(true);
            itemParticle.RectTransform.DOMove(item.transform.position, 2f).SetEase(Ease.InBack);
            if (CheckRewardedItemIsDeath(item)) return;
            GameSignals.OnSwitchPhaseState?.Invoke();
            GameSignals.OnItemRewardedFinish?.Invoke();
        }

        private bool CheckRewardedItemIsDeath(ItemBase item)
        {
            return item.ItemData.itemType == CardItemType.Death;
        }
    }
}