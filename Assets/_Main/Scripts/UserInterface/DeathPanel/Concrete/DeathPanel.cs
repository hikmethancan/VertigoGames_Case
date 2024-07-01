using _Main.Scripts.Base.MonoBehaviourBase;
using _Main.Scripts.Signals;
using _Main.Scripts.UserInterface.DeathPanel.Abstract;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace _Main.Scripts.UserInterface.DeathPanel.Concrete
{
    public class DeathPanel : Operator
    {
        [SerializeField] private Transform deathPanel;
        [SerializeField] private DeathPanelSo deathPanelSo;
        [SerializeField] private TMP_Text coinAmountText;
        [SerializeField] private ContinueGameButton continueGameButton;
        

        private int _coinAmount;

        protected override void Setup()
        {
            _coinAmount = deathPanelSo.coinAmount;
            SetCoinAmountText();
        }

        private void SetCoinAmountText()
        {
            coinAmountText.SetText($"{_coinAmount}");
        }

        protected override void Register(bool isActive)
        {
            base.Register(isActive);
            if (isActive)
                GameSignals.OnDeathState += DeathState;
            else
                GameSignals.OnDeathState -= DeathState;
        }

        private void DeathState()
        {
            deathPanel.DOScale(Vector3.one, deathPanelSo.scaleDuration).SetEase(deathPanelSo.scaleEase);
        }
    }
}