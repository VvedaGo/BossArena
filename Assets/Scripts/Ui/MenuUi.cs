using Infrastructure.Services;
using Infrastructure.States;
using StaticData;
using UnityEngine;

namespace Ui
{
    public class MenuUi : MonoBehaviour
    {
        [SerializeField] private UnitStore _unitStore;
        [SerializeField] private CoinView _coin;
        [SerializeField] private LevelMap _levelMap;
        private GameStateMachine _stateMachine;
        private IPersistentProgressService _persistentProgress;
        private ISaveLoadService _saveLoadService;
        
        public void Construct(GameStateMachine stateMachine,IPersistentProgressService persistentProgressService,ISaveLoadService saveLoadService)
        {
            _stateMachine = stateMachine;
            _persistentProgress = persistentProgressService;
            _saveLoadService = saveLoadService;

            ConstructChildPage();
            _coin.SetCount(_persistentProgress.Progress.CoinCount);
        }

        private void ConstructChildPage()
        {
            _unitStore.Construct(_persistentProgress,_saveLoadService);
            _levelMap.Initialize(_persistentProgress,_stateMachine);
        }

        public void LoadLevelsInfo(LevelConfig [] levelConfigs)
        {
            _levelMap.LoadLevelInfo(levelConfigs);
        }

        public void LoadGameScene()
        {
            _stateMachine.Enter<LevelLoadState>();
        }
    }
}