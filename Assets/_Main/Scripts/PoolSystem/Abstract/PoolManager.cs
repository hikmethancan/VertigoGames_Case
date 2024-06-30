using _Main.Scripts.PoolSystem.Concrete;

namespace _Main.Scripts.PoolSystem.Abstract
{
    public class PoolManager : Singleton<PoolManager>
    {
        private ItemPool _itemPool;

        public ItemPool ItemPool => _itemPool ? _itemPool : (_itemPool = GetComponentInChildren<ItemPool>());

        private PhaseUIPool _phaseUIPool;

        public PhaseUIPool PhaseUIPool =>
            _phaseUIPool ? _phaseUIPool : (_phaseUIPool = GetComponentInChildren<PhaseUIPool>());

        private RewardedItemPool _rewardedItemPool;

        public RewardedItemPool RewardedItemPool =>
            _rewardedItemPool ? _rewardedItemPool : (_rewardedItemPool = GetComponentInChildren<RewardedItemPool>());
    }
}