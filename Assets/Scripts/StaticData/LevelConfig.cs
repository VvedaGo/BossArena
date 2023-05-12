using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(menuName = "Static Data/Levels", fileName = "Level")]
    public class LevelConfig:ScriptableObject
    {
        public string NameScene;
        public int NumberLevel;
        public int RewardCoins;
        public UnitsOnLevel[] UnitsOnLevel;
    }
}