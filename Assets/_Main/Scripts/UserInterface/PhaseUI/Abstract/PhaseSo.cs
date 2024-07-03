using UnityEngine;

namespace _Main.Scripts.UserInterface.PhaseUI.Abstract
{
    [CreateAssetMenu(fileName = "Datas", menuName = "Datas/PhaseData", order = 0)]
    public class PhaseSo : ScriptableObject
    {
        public int safeZoneNo;
        public int superZoneNo;
    }
}