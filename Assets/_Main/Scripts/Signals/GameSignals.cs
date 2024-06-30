using System;
using _Main.Scripts.GamePlay.Item.Abstract;

namespace _Main.Scripts.Signals
{
    public static class GameSignals
    {
        //Spinning
        public static Action OnSpinningButtonClicked;
        public static Action OnSpinningAnimationEnded;
        public static Action OnReadyForSpinning;

        // Items
        public static Action<ItemBase> OnNewItemGained;
        public static Action OnItemRewardedFinish;
    }
}