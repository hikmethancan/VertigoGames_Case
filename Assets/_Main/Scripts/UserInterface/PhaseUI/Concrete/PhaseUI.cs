using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Main.Scripts.UserInterface.PhaseUI.Concrete
{
    public class PhaseUI : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private TMP_Text phaseLevelText;

        public int Level => _level;
        private int _level;

        public void SetPhaseData(int level)
        {
            _level = level;
            phaseLevelText.SetText($"{level}");
        }
    }
}