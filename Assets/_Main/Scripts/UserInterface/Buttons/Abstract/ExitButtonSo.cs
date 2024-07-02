using DG.Tweening;
using UnityEngine;

namespace _Main.Scripts.UserInterface.Buttons.Abstract
{
    [CreateAssetMenu(fileName = "Datas", menuName = "Datas/Buttons/ExitButtonSo", order = 0)]
    public class ExitButtonSo : ScriptableObject
    {
        public float scaleDuration;
        public Ease scaleUpEase;
        public Ease scaleDownEase;
    }
}