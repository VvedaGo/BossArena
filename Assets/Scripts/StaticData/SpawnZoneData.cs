using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(menuName = "Static Data/SpawnZone", fileName = "SpawnZone")]
    public class SpawnZoneData : ScriptableObject
    {
        public Vector3 Position;
        public GameObject Prefab;
    }
}
