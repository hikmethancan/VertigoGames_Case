using _Main.Scripts.Base.MonoBehaviourBase;
using _Main.Scripts.DataSystem.Concrete;
using _Main.Scripts.Signals;
using TMPro;
using UnityEngine;

namespace _Main.Scripts.UserInterface.CoinAmount.Concrete
{
    public class CoinPanel : Operator
    {
        [SerializeField] private TMP_Text coinAmountText;

        protected override void Register(bool isActive)
        {
            base.Register(isActive);
            if (isActive)
            {
                GameSignals.OnSetCoinAmount += Setup;
            }
            else
                GameSignals.OnSetCoinAmount -= Setup;
        }

        protected override void Setup()
        {
            coinAmountText.SetText($"{DataManager.Money}");
        }
    }
}