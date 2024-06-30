using System.Collections.Generic;
using _Main.Scripts.GamePlay.Item.Abstract;
using NaughtyAttributes;
using UnityEngine;

namespace _Main.Scripts.GamePlay.Wheel.Abstract
{
    [CreateAssetMenu(fileName = "Datas", menuName = "Datas/WheelPhaseSo", order = 0)]
    public class WheelPhaseSo : ScriptableObject
    {
        [ShowAssetPreview] public Sprite wheelSprite;
        public WheelType wheelType;
        public List<ItemSo> items;
    }
}