using System.Collections.Generic;
using _Main.Scripts.Base.MonoBehaviourBase;
using _Main.Scripts.DISystem.Abstract;
using _Main.Scripts.GamePlay.Wheel.Abstract;
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
        [SerializeField] private Image currentPhaseBgImage;

        private readonly List<PhaseUI> _currentPhases = new();
        private int _currentPhaseLevel;
        private PhaseAnimationSo _phaseAnimationSo;
        private PhaseReferencesSo _phaseReferencesSo;
        private PhaseSo _phaseSo;

        protected override void Setup()
        {
            PhaseDataSetup();
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

        private void PhaseDataSetup()
        {
            var phaseDatas = DIContainer.Instance.GetPhaseDatas();
            _phaseSo = phaseDatas.phaseSo;
            _phaseAnimationSo = phaseDatas.phaseAnimationSo;
            _phaseReferencesSo = phaseDatas.phaseReferencesSo;
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
            var targetX = 600f - _currentPhaseLevel * _phaseAnimationSo.phaseImageSpawnOffsetX;
            container.DOAnchorPosX(targetX, _phaseAnimationSo.moveDuration).SetEase(_phaseAnimationSo.moveEase);
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
            if (_currentPhaseLevel == _phaseSo.superZoneNo)
                _currentPhaseLevel = 0;
            _currentPhaseLevel++;
            SortThePhaseAnimation();
            CheckPhaseStates();
        }

        private void CheckPhaseStates()
        {
            if (_currentPhaseLevel % _phaseSo.superZoneNo == 0)
            {
                currentPhaseBgImage.sprite = _phaseReferencesSo.superZoneLevelSprite;
                GameSignals.OnNewPhaseSwitched?.Invoke(_currentPhaseLevel, WheelType.Gold);
            }
            else if (_currentPhaseLevel % _phaseSo.safeZoneNo == 0)
            {
                currentPhaseBgImage.sprite = _phaseReferencesSo.silverLevelSprite;
                GameSignals.OnNewPhaseSwitched?.Invoke(_currentPhaseLevel, WheelType.Silver);
            }
            else
            {
                currentPhaseBgImage.sprite = _phaseReferencesSo.bronzeLevelSprite;
                GameSignals.OnNewPhaseSwitched?.Invoke(_currentPhaseLevel, WheelType.Bronze);
            }
        }
    }
}