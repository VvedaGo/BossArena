using System.Linq;
using Infrastructure.Services;
using Infrastructure.States;
using StaticData;
using UnityEngine;

public class LevelMap : MonoBehaviour
{
   [SerializeField] private LevelInstance[] _levelInstances;
   private IPersistentProgressService _progressService;
   private GameStateMachine _gameStateMachine;

   public void Initialize(IPersistentProgressService progressService, GameStateMachine gameStateMachine)
   {
      _progressService = progressService;
      _gameStateMachine = gameStateMachine;
   }
   public void Open()
   {
      gameObject.SetActive(true);
   }
   public void Close()
   {
      gameObject.SetActive(false);
   }

   public void StartLevel(int numberLevel)
   {
      _progressService.Progress.NumberLevel = numberLevel;
      _gameStateMachine.Enter<LevelLoadState>();
   }
   public void LoadLevelInfo(LevelConfig[] levelConfigs)
   {
      for (int i = 0; i < _levelInstances.Length; i++)
      {
         var configForLevel = levelConfigs.FirstOrDefault(config => config.NumberLevel == i);
         _levelInstances[i].Initialize(this);
         _levelInstances[i].LoadValues(configForLevel.NumberLevel,configForLevel.RewardCoins);
      }
   }
}
