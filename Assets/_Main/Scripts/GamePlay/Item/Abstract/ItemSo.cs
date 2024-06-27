using UnityEngine;

namespace _Main.Scripts.GamePlay.Item.Abstract
{
    [CreateAssetMenu(fileName = "Datas", menuName = "Datas/ItemsSo", order = 0)]
    public class ItemSo : ScriptableObject
    {
        public Sprite itemSprite;
        [Range(0, 100)] public int spawnPossibility;
    }
}