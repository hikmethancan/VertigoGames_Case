using System;
using _Main.Scripts.GamePlay.Item.Abstract;

namespace _Main.Scripts.Signals
{
    public static class GameSignals
    {
        //Spinning
        public static Action OnSpinningButtonClicked;
        public static Action OnReadyForSpinning;

        // Items
        public static Action<ItemBase> OnNewItemGained;
        public static Action OnDeathState;
        public static Action OnItemRewardedFinish;

        // Phase
        public static Action OnSwitchPhaseState;
        public static Action<bool> OnExitButtonActivate;

        // Button Events
        public static Action OnContinueButtonClicked;
        public static Action OnSetCoinAmount;
        public static Action OnExitTheGame;
    }
}