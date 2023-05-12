using System.Collections.Generic;
using Data;
using Infrastructure.Services;
using StaticData;

namespace Infrastructure.States
{
    public class LevelLoadState : IStateGame
    {
        private readonly IGameFactory _factory;
        private readonly GameStateMachine _stateMachine;
        private readonly IPersistentProgressService _persistentProgressService;
        private readonly ISceneLoader _sceneLoader;
        private readonly IAssetProvider _assetProvider;

        public LevelLoadState(IGameFactory factory, GameStateMachine stateMachine,
            IPersistentProgressService persistentProgressService, ISceneLoader sceneLoader,IAssetProvider assetProvider)
        {
            _factory = factory;
            _stateMachine = stateMachine;
            _persistentProgressService = persistentProgressService;
            _sceneLoader = sceneLoader;
            _assetProvider = assetProvider;
        }

        public void Enter()
        {
            string nameScene=_assetProvider.GetLevels()[_persistentProgressService.Progress.NumberLevel].NameScene;
            _sceneLoader.LoadSceneAsync(nameScene, SpawnGameWorld);
        }

        public void Exit()
        {
        }

        private void SpawnEnemy()
        {
            foreach (KeyValuePair<UnitType, int> unitsTypeCount in _persistentProgressService.Progress.CountUnits)
            {
                for (int i = 0; i < unitsTypeCount.Value; i++)
                {
                    _factory.CreateUnit(TeamColor.Blue, unitsTypeCount.Key);
                }
            }
            
            foreach (UnitsOnLevel unitsOnLevel in _assetProvider.GetLevels()[_persistentProgressService.Progress.NumberLevel].UnitsOnLevel)
            {
                for (int i = 0; i < unitsOnLevel.Count; i++)
                {
                    _factory.CreateUnit(TeamColor.Red, unitsOnLevel.Type);
                }
            }
        
        }

        private void SpawnGameWorld()
        {
            _factory.CreateZone(TeamColor.Blue);
            _factory.CreateZone(TeamColor.Red);

            SpawnEnemy();

            _stateMachine.Enter<GameLoopState>();
        }
    }
}