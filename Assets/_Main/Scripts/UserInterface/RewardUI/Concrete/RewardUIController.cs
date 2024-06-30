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
            item.transform.SetParent(container);
            item.transform.localScale = Vector3.one;
            item.gameObject.SetActive(true);
            var itemParticle = PoolManager.Instance.RewardedItemPool.Get();
            itemParticle.SetItem(item.ItemData.itemSprite);
            itemParticle.transform.SetParent(container.parent.parent);
            itemParticle.transform.localScale = Vector3.one;
            itemParticle.transform.position = tempItem.transform.position;
            itemParticle.gameObject.SetActive(true);
            itemParticle.transform.DOMove(item.transform.position, 3f).SetDelay(1f).SetEase(Ease.InBack);
            GameSignals.OnReadyForSpinning?.Invoke();
        }
    }
}