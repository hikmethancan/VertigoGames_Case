using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _Main.Scripts.Base.MonoBehaviourBase;
using _Main.Scripts.DataSystem.Concrete;
using _Main.Scripts.GamePlay.Item.Abstract;
using _Main.Scripts.GamePlay.Item.Concrete;
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
            {
                GameSignals.OnNewItemGained += AddItem;
                GameSignals.OnExitTheGame += CollectItems;
            }
            else
            {
                GameSignals.OnNewItemGained -= AddItem;
                GameSignals.OnExitTheGame -= CollectItems;
            }
        }

        private void CollectItems()
        {
            var goldItem = _rewardedItems.FirstOrDefault(x => x.ItemData.itemType == CardItemType.Gold);
            if (goldItem != null)
            {
                DataManager.Money += goldItem.RewardRewardCount;
            }
        }

        private async void AddItem(ItemBase itemBase)
        {
            await AddNewItem(itemBase);
        }

        private async Task AddNewItem(ItemBase tempItem)
        {
            if (CheckRewardedItemIsDeath(tempItem))
            {
                GameSignals.OnDeathState?.Invoke();
                return;
            }

            var existingItem = GetExistingItem(tempItem);
            if (existingItem == null)
            {
                existingItem = CreateNewItem(tempItem);
                _rewardedItems.Add(existingItem);
            }

            await HandleItemMovementAsync(tempItem, existingItem);
            existingItem.IncreaseItemCount(tempItem.ItemData.spawnCount);
            GameSignals.OnSwitchPhaseState?.Invoke();
            GameSignals.OnItemRewardedFinish?.Invoke();
        }

        private ItemBase GetExistingItem(ItemBase tempItem)
        {
            return _rewardedItems.FirstOrDefault(x => x.IsEqualItemType(tempItem));
        }

        private ItemBase CreateNewItem(ItemBase tempItem)
        {
            var newItem = PoolManager.Instance.ItemPool.Get();
            newItem.SetupItemData(tempItem.ItemData);
            newItem.RewardedSetup();
            Transform itemTransform = newItem.transform;
            itemTransform.SetParent(container);
            itemTransform.localScale = Vector3.one;
            newItem.gameObject.SetActive(true);
            return newItem;
        }

        private async Task HandleItemMovementAsync(ItemBase tempItem, ItemBase existingItem)
        {
            await Task.Delay(10); // Small delay to wait initialize of rewardedItem

            var moveTasks = new List<Task>();
            for (int i = 0; i < rewardSo.rewardedItemsSpawnCount; i++)
            {
                var itemParticle = PoolManager.Instance.RewardedItemPool.Get();
                SetupItemParticle(itemParticle, tempItem, existingItem);
                moveTasks.Add(itemParticle.MovementAsync(existingItem.RectTransform.position));
            }

            await Task.WhenAll(moveTasks);
        }

        private void SetupItemParticle(RewardedItemImage itemParticle, ItemBase tempItem, ItemBase existingItem)
        {
            itemParticle.SetItem(existingItem.ItemData.itemSprite);
            Transform itemParticleTransform = itemParticle.transform;
            itemParticleTransform.SetParent(transform);
            itemParticleTransform.localScale = Vector3.one;
            var rndVector = Random.insideUnitSphere * rewardSo.rewardItemsSpawnOffsetMultiplier;
            var tempItemPos = tempItem.RectTransform.position;
            itemParticleTransform.position = tempItemPos + new Vector3(rndVector.x, rndVector.y, tempItemPos.z);
            itemParticle.gameObject.SetActive(true);
        }

        private bool CheckRewardedItemIsDeath(ItemBase item)
        {
            return item.ItemData.itemType == CardItemType.Death;
        }
    }
}