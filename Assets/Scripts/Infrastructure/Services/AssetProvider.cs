using Data;
using StaticData;
using UnityEngine;

namespace Infrastructure.Services
{
    public class AssetProvider : IAssetProvider
    {
        public LevelConfig[] GetLevels()
        {
            return Resources.LoadAll<LevelConfig>(AssetPath.PathLevelsConfig);
        }

        public AllUnitConfig GetUnitConfig()
        {
            return Resources.Load<AllUnitConfig>(AssetPath.PathUnits);
        }

        public SpawnZoneData GetZoneData(TeamColor zoneColor)
        {
            string pathPrefab = zoneColor == TeamColor.Blue ? AssetPath.PathBlueZoneData : AssetPath.PathRedZoneData;
            return Resources.Load<SpawnZoneData>(pathPrefab);
        }
    }
}