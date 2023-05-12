using Data;
using StaticData;

namespace Infrastructure.Services
{
    public interface IAssetProvider:IService
    {
        public LevelConfig[] GetLevels();
        public AllUnitConfig GetUnitConfig();
        public SpawnZoneData GetZoneData(TeamColor zoneColor);
    }
}