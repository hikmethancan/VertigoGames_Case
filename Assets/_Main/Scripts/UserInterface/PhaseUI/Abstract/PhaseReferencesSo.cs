using NaughtyAttributes;
using UnityEngine;

namespace _Main.Scripts.UserInterface.PhaseUI.Abstract
{
    [CreateAssetMenu(fileName = "Datas", menuName = "Datas/PhaseReferencesSo", order = 0)]
    public class PhaseReferencesSo : ScriptableObject
    {
        [Header("References")] [ShowAssetPreview]public Sprite bronzeLevelSprite;
        [ShowAssetPreview]public Sprite silverLevelSprite;
        [ShowAssetPreview]public Sprite superZoneLevelSprite;
    }
}