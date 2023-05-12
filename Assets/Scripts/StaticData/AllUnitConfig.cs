using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(menuName = "Static Data/AllUnitConfig", fileName = "AllUnits")]
    public class AllUnitConfig : ScriptableObject
    {
        public UnitConfig[] Configs;
    }
}
