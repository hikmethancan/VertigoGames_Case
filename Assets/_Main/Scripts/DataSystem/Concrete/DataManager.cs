using UnityEngine;

namespace _Main.Scripts.DataSystem.Concrete
{
    public static class DataManager
    {
        private const string MoneyKey = "Money";

        public static int Money
        {
            get => PlayerPrefs.GetInt(MoneyKey, 500);
            set
            {
                PlayerPrefs.SetInt(MoneyKey, value);
                PlayerPrefs.Save();
            }
        }
    }
}