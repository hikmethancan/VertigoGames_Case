using System.Collections.Generic;
using _Main.Scripts.Base.MonoBehaviourBase;
using _Main.Scripts.PoolSystem.Abstract;
using _Main.Scripts.Signals;
using _Main.Scripts.UserInterface.PhaseUI.Abstract;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _Main.Scripts.UserInterface.PhaseUI.Concrete
{
    public class PhaseUIController : Operator
    {
        [SerializeField] private RectTransform container;
        [SerializeField] private PhaseAnimationSo phaseAnimationSo;
        [SerializeField] private PhaseReferencesSo phaseReferencesSo;
        [SerializeField] private Image currentPhaseBgImage;

        private readonly List<PhaseUI> _currentPhases = new();
        private int _currentPhaseLevel;

        protected override void Setup()
        {
            _currentPhaseLevel = 1;
            for (int i = 0; i < 30; i++)
            {
                var phaseUI = PoolManager.Instance.PhaseUIPool.Get();
                phaseUI.SetPhaseData(i + 1);
                phaseUI.transform.SetParent(container);
                phaseUI.gameObject.SetActive(true);
                _currentPhases.Add(phaseUI);
            }

            SortThePhaseAnimation();
        }
        protected override void Register(bool isActive)
        {
            base.Register(isActive);
            if (isActive)
                GameSignals.OnSwitchPhaseState += SwitchPhase;
            else
                GameSignals.OnSwitchPhaseState -= SwitchPhase;
        }

        private void SortThePhaseAnimation()
        {
            var targetX = 600f - _currentPhaseLevel * phaseAnimationSo.phaseImageSpawnOffsetX;
            container.DOAnchorPosX(targetX, phaseAnimationSo.moveDuration).SetEase(phaseAnimationSo.moveEase);
            ColorFadePassedLevelsText();
        }

        private void ColorFadePassedLevelsText()
        {
            for (int i = 0; i < _currentPhaseLevel - 1; i++)
            {
                _currentPhases[i].FadeText();
            }
        }

        private void SwitchPhase()
        {
            if (_currentPhaseLevel == 30)
                _currentPhaseLevel = 0;
            _currentPhaseLevel++;
            SortThePhaseAnimation();
            CheckPhaseStates();
        }

        private void CheckPhaseStates()
        {
            currentPhaseBgImage.sprite = _currentPhaseLevel switch
            {
                5 => phaseReferencesSo.silverLevelSprite,
                30 => phaseReferencesSo.superZoneLevelSprite,
                _ => phaseReferencesSo.bronzeLevelSprite
            };
        }
    }
}