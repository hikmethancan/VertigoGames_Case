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
        [SerializeField] private TMP_Text deathText;
        [SerializeField] private TMP_Text coinAmountText;
        [SerializeField] private ContinueGameButton continueGameButton;
        [SerializeField] private CanvasGroup canvasGroup;

        private int _coinAmount;


        protected override void Setup()
        {
            transform.localScale = Vector3.zero;
            _coinAmount = deathPanelSo.coinAmount;
            continueGameButton.SetCost(_coinAmount);
            SetCoinAmountText();
            deathText.SetText($"{deathPanelSo.deathText}");
        }

        private void SetCoinAmountText()
        {
            coinAmountText.SetText($"{_coinAmount}");
        }

        protected override void Register(bool isActive)
        {
            base.Register(isActive);
            if (isActive)
            {
                GameSignals.OnDeathState += DeathState;
                GameSignals.OnContinueButtonClicked += DeActivate;
            }
            else
            {
                GameSignals.OnDeathState -= DeathState;
                GameSignals.OnContinueButtonClicked -= DeActivate;
            }
        }

        private void DeActivate()
        {
            canvasGroup.interactable = false;
            deathPanel.DOScale(Vector3.zero, deathPanelSo.scaleDuration).SetEase(deathPanelSo.scaleEase);
        }

        private void DeathState()
        {
            canvasGroup.interactable = true;
            deathPanel.DOScale(Vector3.one, deathPanelSo.scaleDuration).SetEase(deathPanelSo.scaleEase);
        }
    }
}