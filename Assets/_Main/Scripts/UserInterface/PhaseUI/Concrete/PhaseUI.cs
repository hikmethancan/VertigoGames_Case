using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Main.Scripts.UserInterface.PhaseUI.Concrete
{
    public class PhaseUI : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private TMP_Text phaseLevelText;


        public void SetPhaseData(int level)
        {
            phaseLevelText.SetText($"{level}");
        }
    }
}