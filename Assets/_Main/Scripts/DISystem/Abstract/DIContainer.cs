using System.Collections.Generic;
using _Main.Scripts.GamePlay.Wheel.Abstract;
using UnityEngine;

namespace _Main.Scripts.DISystem.Abstract
{
    public class DIContainer : Singleton<DIContainer>
    {
        private Dictionary<WheelType, WheelPhaseSo> _wheelPhasesData;

        private void Awake()
        {
            Application.targetFrameRate = 60;
            LoadScriptableObjectsFromResources();
        }

        private void LoadScriptableObjectsFromResources()
        {
            var wheelDatas = Resources.LoadAll<WheelPhaseSo>("Datas/Wheel/Phase");
            _wheelPhasesData = new();
            foreach (var phaseSo in wheelDatas)
            {
                _wheelPhasesData.Add(phaseSo.wheelType, phaseSo);
            }
        }

        public WheelPhaseSo GetWheelPhaseData(WheelType wheelType)
        {
            return _wheelPhasesData[wheelType];
        }
    }
}