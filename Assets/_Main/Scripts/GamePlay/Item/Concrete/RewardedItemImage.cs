using System.Threading.Tasks;
using _Main.Scripts.Base.MonoBehaviourBase;
using _Main.Scripts.GamePlay.Item.Abstract;
using _Main.Scripts.PoolSystem.Abstract;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _Main.Scripts.GamePlay.Item.Concrete
{
    public class RewardedItemImage : Operator
    {
        public RectTransform RectTransform => rectTransform;


        [SerializeField] private RewardedItemSo rewardedItemSo;
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private Image itemImage;

        protected override void Setup()
        {
        }

        public void SetItem(Sprite sprite)
        {
            itemImage.sprite = sprite;
        }

        public async Task MovementAsync(Vector2 pos)
        {
            //TODO Burayi doldur hiko bey
            await rectTransform.DOMove(pos, rewardedItemSo.moveDuration).SetEase(rewardedItemSo.moveEase)
                .OnComplete(
                    () => { PoolManager.Instance.RewardedItemPool.ReturnToPool(this); })
                .AsyncWaitForCompletion();
        }
    }
}