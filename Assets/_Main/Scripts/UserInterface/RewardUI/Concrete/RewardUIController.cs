using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _Main.Scripts.Base.MonoBehaviourBase;
using _Main.Scripts.GamePlay.Item.Abstract;
using _Main.Scripts.PoolSystem.Abstract;
using _Main.Scripts.Signals;
using _Main.Scripts.UserInterface.RewardUI.Abstract;
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
            // Add any setup logic if necessary
        }

        protected override void Register(bool isActive)
        {
            base.Register(isActive);
            if (isActive)
                GameSignals.OnNewItemGained += AddItem;
            else
                GameSignals.OnNewItemGained -= AddItem;
        }

        private async void AddItem(ItemBase itemBase)
        {
            await AddNewItem(itemBase);
        }

        private async Task AddNewItem(ItemBase tempItem)
        {
            ItemBase item = _rewardedItems.FirstOrDefault(x => x.ItemData.name == tempItem.ItemData.name);

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

            if (CheckRewardedItemIsDeath(item)) // Check for Death item type
                return;
            await Task.Delay(10); // Small delay to simulate asynchronous operation

            List<Task> moveTasks = new List<Task>();
            for (int i = 0; i < rewardSo.rewardedItemsSpawnCount; i++)
            {
                var itemParticle = PoolManager.Instance.RewardedItemPool.Get();
                itemParticle.SetItem(item.ItemData.itemSprite);
                Transform itemParticleTransform = itemParticle.transform;
                itemParticleTransform.SetParent(transform);
                itemParticleTransform.localScale = Vector3.one;
                itemParticleTransform.position = tempItem.RectTransform.position +
                                                 Random.insideUnitSphere * rewardSo.rewardItemsSpawnOffsetMultiplier;
                itemParticle.gameObject.SetActive(true);
                moveTasks.Add(itemParticle.MovementAsync(item.RectTransform.position));
            }

            await Task.WhenAll(moveTasks);
            GameSignals.OnSwitchPhaseState?.Invoke();
            GameSignals.OnItemRewardedFinish?.Invoke();
        }

        private bool CheckRewardedItemIsDeath(ItemBase item)
        {
            return item.ItemData.itemType == CardItemType.Death;
        }
    }
}