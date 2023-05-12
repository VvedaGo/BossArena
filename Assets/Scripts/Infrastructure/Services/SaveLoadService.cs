using Data;
using Newtonsoft.Json;
using UnityEngine;

namespace Infrastructure.Services
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string PlayerProgressKey = "PlayerProgress";
        private readonly IPersistentProgressService _persistentProgressService;

        public SaveLoadService(IPersistentProgressService persistentProgressService)
        {
            _persistentProgressService = persistentProgressService;
        }

        public void SaveProgress()
        {
            PlayerPrefs.SetString(PlayerProgressKey, JsonConvert.SerializeObject(_persistentProgressService.Progress));
        }

        public PlayerProgress LoadProgress()
        {
            return PlayerPrefs.HasKey(PlayerProgressKey)
                ? JsonConvert.DeserializeObject<PlayerProgress>(PlayerPrefs.GetString(PlayerProgressKey))
                : new PlayerProgress();
        }
    }
}