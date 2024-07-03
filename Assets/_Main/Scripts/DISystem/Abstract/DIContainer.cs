using System.Collections.Generic;
using System.Linq;
using _Main.Scripts.DataSystem.Abstract;
using _Main.Scripts.GamePlay.Wheel.Abstract;
using _Main.Scripts.UserInterface.PhaseUI.Abstract;
using UnityEngine;

namespace _Main.Scripts.DISystem.Abstract
{
    public class DIContainer : Singleton<DIContainer>
    {
        private Dictionary<WheelType, WheelPhaseSo> _wheelPhasesData;
        private PhaseSoProvider _phaseSoProvider;
        private WheelDataProvider _wheelDataProvider;

        private void Awake()
        {
            Application.targetFrameRate = 60;
            LoadScriptableObjectsFromResources();
        }

        private void LoadScriptableObjectsFromResources()
        {
            LoadWheelPhaseDatas();
            LoadPhaseDatas();
            LoadWheelDatas();
        }

        private void LoadPhaseDatas()
        {
            _phaseSoProvider = new PhaseSoProvider();
            _phaseSoProvider.phaseSo = Resources.Load<PhaseSo>(DataPathConstants.PhaseSo);
            _phaseSoProvider.phaseAnimationSo = Resources.Load<PhaseAnimationSo>(DataPathConstants.PhaseAnimationSo);
            _phaseSoProvider.phaseReferencesSo = Resources.Load<PhaseReferencesSo>(DataPathConstants.PhaseReferencesSo);
        }

        private void LoadWheelPhaseDatas()
        {
            var wheelDatas = Resources.LoadAll<WheelPhaseSo>(DataPathConstants.WheelPhaseSoPath);
            _wheelPhasesData = new();
            foreach (var phaseSo in wheelDatas)
            {
                _wheelPhasesData.Add(phaseSo.wheelType, phaseSo);
            }
        }

        private void LoadWheelDatas()
        {
            _wheelDataProvider = new WheelDataProvider();
            var datas = Resources.LoadAll<ScriptableObject>(DataPathConstants.WheelDatas);
            _wheelDataProvider.wheelSo = (WheelSo)datas.FirstOrDefault(x => x.GetType() == typeof(WheelSo));
            _wheelDataProvider.wheelAnimationSo =
                (WheelAnimationSo)datas.FirstOrDefault(x => x.GetType() == typeof(WheelAnimationSo));
        }

        public PhaseSoProvider GetPhaseDatas()
        {
            return _phaseSoProvider;
        }

        public WheelPhaseSo GetWheelPhaseData(WheelType wheelType)
        {
            return _wheelPhasesData[wheelType];
        }

        public WheelDataProvider GetWheelDatas()
        {
            return _wheelDataProvider;
        }
    }
}