using System;
using System.Collections.Generic;
using Infrastructure.Services;

namespace Infrastructure.States
{
    public class GameStateMachine
    {
     
        private readonly Dictionary<Type, IStateGame> _storageGameStates;
        private IStateGame _activeState;

        public GameStateMachine(AllService service)
        {
            
            _storageGameStates=new Dictionary<Type, IStateGame>
            {
                [typeof(BootstrapState)]=new BootstrapState(this,service),
                [typeof(LoadProgressState)]=new LoadProgressState(this,service.Single<ISaveLoadService>(),service.Single<IPersistentProgressService>()),
                [typeof(MenuState)]=new MenuState(this,service.Single<IGameFactory>(),service.Single<ISceneLoader>()),
                [typeof(LevelLoadState)]=new LevelLoadState(service.Single<IGameFactory>(),this,service.Single<IPersistentProgressService>(),service.Single<ISceneLoader>(),
                    service.Single<IAssetProvider>()),
                [typeof(GameLoopState)]=new GameLoopState(service.Single<IGameFactory>(),service.Single<MatchViewer>(),service.Single<ISaveLoadService>()
                    ,service.Single<IPersistentProgressService>()),
                [typeof(GameEndState)]=new EndGameState()
            };
        }


        public void Enter<TState>() where TState : IStateGame
        {
            ChangeState<TState>();
        }

        public void Exit()
        {
            
        }

        private void ChangeState<TState>() where TState : IStateGame
        {
            _activeState?.Exit();
            IStateGame stateToEnter = _storageGameStates[typeof(TState)];
            stateToEnter.Enter();
            _activeState = stateToEnter;
        }
    }
}