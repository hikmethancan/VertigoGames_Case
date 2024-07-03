using System;
using _Main.Scripts.GamePlay.Item.Abstract;
using _Main.Scripts.GamePlay.Wheel.Abstract;

namespace _Main.Scripts.Signals
{
    public static partial class GameSignals
    {
        // Items
        public static Action<ItemBase> OnNewItemGained;
        public static Action OnDeathState;
        public static Action OnItemRewardedFinish;

        // Phase
        public static Action OnSwitchPhaseState;
        public static Action<bool> OnExitButtonActivate;
        public static Action<int,WheelType> OnNewPhaseSwitched;

        // Button Events
        public static Action OnContinueButtonClicked;
        public static Action OnSetCoinAmount;
        public static Action OnExitTheGame;
    }
}