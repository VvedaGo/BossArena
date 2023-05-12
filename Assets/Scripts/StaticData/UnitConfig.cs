using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(menuName = "Static Data/Units", fileName = "Unit")]
    public class UnitConfig :ScriptableObject
    {
        public UnitType UnitType;
        public GameObject PrefabBlue;
        public GameObject PrefabRed;
        public float Hp;
        public float Damage;
        public float AttackReload;
        public float Speed;
    }
}
