using NaughtyAttributes;
using UnityEngine;

namespace _Main.Scripts.GamePlay.Item.Abstract
{
    [CreateAssetMenu(fileName = "Datas", menuName = "Datas/ItemsSo", order = 0)]
    public class ItemSo : ScriptableObject
    {
        [ShowAssetPreview] public Sprite itemSprite;
        [Space(10f)] public CardItemType itemType;

        [ShowIf("itemType", CardItemType.Chest)]
        public ChestType chestType;

        [ShowIf("itemType", CardItemType.Weapon)]
        public WeaponType weaponType;

        [ShowIf("itemType", CardItemType.Point)]
        public PointType pointType;

        [Space(10f)] public int spawnCount;
        [Range(0, 100)] public int spawnPossibility;
    }
}