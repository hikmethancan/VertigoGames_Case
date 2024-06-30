using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _Main.Scripts.Base.MonoBehaviourBase;
using _Main.Scripts.GamePlay.Item.Abstract;
using _Main.Scripts.GamePlay.Item.Concrete;
using _Main.Scripts.PoolSystem.Abstract;
using _Main.Scripts.Signals;
using _Main.Scripts.UserInterface.RewardUI.Abstract;
using DG.Tweening;
using UnityEngine;

namespace _Main.Scripts.UserInterface.RewardUI.Concrete
{
    public class RewardUIController : Operator
    {
        [SerializeField] private Transform container;
        [SerializeField] private RewardUISo rewardSo;

        private readonly List<ItemBase> _rewardedItems = new();

        protected override void Setup()
        {
        }

        protected override void Register(bool isActive)
        {
            base.Register(isActive);
            if (isActive)
                GameSignals.OnNewItemGained += AddItem;
            else
                GameSignals.OnNewItemGained -= AddItem;
        }

        private void AddItem(ItemBase itemBase)
        {
            AddNewItem(itemBase);
        }

        private async Task AddNewItem(ItemBase tempItem)
        {
            ItemBase item = _rewardedItems.FirstOrDefault(x => x.name == tempItem.name);

            if (item == null)
            {
                item = PoolManager.Instance.ItemPool.Get();
                item.SetupItemData(tempItem.ItemData);
                Transform itemTransform = item.transform;
                itemTransform.SetParent(container);
                itemTransform.localScale = Vector3.one;
                item.gameObject.SetActive(true);
                _rewardedItems.Add(item);
            }

            List<Task> moveTasks = new List<Task>();
            for (int i = 0; i < rewardSo.rewardedItemsSpawnCount; i++)
            {
                var itemParticle = PoolManager.Instance.RewardedItemPool.Get();
                itemParticle.SetItem(item.ItemData.itemSprite);
                Transform itemParticleTransform = itemParticle.transform;
                itemParticleTransform.SetParent(transform);
                itemParticleTransform.localScale = Vector3.one;
                itemParticle.RectTransform.anchoredPosition =
                    tempItem.RectTransform.anchoredPosition + Random.insideUnitCircle * 10f;
                itemParticle.gameObject.SetActive(true);
                await itemParticle.MovementAsync(item.RectTransform.anchoredPosition);
            }

            // Check for Death item type
            if (CheckRewardedItemIsDeath(item))
                return;

            // await Task.WhenAll(moveTasks);
            GameSignals.OnSwitchPhaseState?.Invoke();
            GameSignals.OnItemRewardedFinish?.Invoke();
        }

        private bool CheckRewardedItemIsDeath(ItemBase item)
        {
            return item.ItemData.itemType == CardItemType.Death;
        }
    }
}