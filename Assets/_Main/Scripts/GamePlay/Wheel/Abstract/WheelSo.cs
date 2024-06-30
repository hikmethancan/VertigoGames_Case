using UnityEngine;

namespace _Main.Scripts.GamePlay.Wheel.Abstract
{
    [CreateAssetMenu(fileName = "Datas", menuName = "Datas/WheelSo", order = 0)]
    public class WheelSo : ScriptableObject
    {
        public int howManyItemsWillSpawn;
        public float cardSpawnRadius;
    }
}