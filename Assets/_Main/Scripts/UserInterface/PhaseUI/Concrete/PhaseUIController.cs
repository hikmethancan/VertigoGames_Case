using System.Collections.Generic;
using _Main.Scripts.Base.MonoBehaviourBase;
using _Main.Scripts.PoolSystem.Abstract;
using _Main.Scripts.Signals;
using _Main.Scripts.UserInterface.PhaseUI.Abstract;
using UnityEngine;

namespace _Main.Scripts.UserInterface.PhaseUI.Concrete
{
    public class PhaseUIController : Operator
    {
        [SerializeField] private Transform container;
        [SerializeField] private PhaseSo phaseSo;

        private List<PhaseUI> _currentPhases = new();

        private int _currentPhaseLevel;

        protected override void Setup()
        {
            for (int i = 0; i < 30; i++)
            {
                var phaseUI = PoolManager.Instance.PhaseUIPool.Get();
                phaseUI.SetPhaseData(i + 1);
                phaseUI.transform.SetParent(container);
                phaseUI.gameObject.SetActive(true);
            }
        }

        protected override void Register(bool isActive)
        {
            base.Register(isActive);
            if (isActive)
                GameSignals.OnSwitchPhaseState += SwitchPhase;
            else
                GameSignals.OnSwitchPhaseState -= SwitchPhase;
        }

        private void SwitchPhase()
        {
        }
    }
}