using Infrastructure.Services;

namespace Infrastructure.States
{
    public class BootstrapState : IStateGame
    {
        private readonly GameStateMachine _stateMachine;
        private readonly AllService _allService;

        public BootstrapState(GameStateMachine stateMachine, AllService allService)
        {
            _stateMachine = stateMachine;
            _allService = allService;
            RegisterService();
        }
        public void Enter()
        {
           _stateMachine.Enter<LoadProgressState>();
        }

        public void Exit()
        {
            
        }

        private void RegisterService()
        {
            _allService.RegisterSingle<IAssetProvider>(new AssetProvider());
            _allService.RegisterSingle<IPersistentProgressService>(new PersistentProgressService());
            _allService.RegisterSingle<ISaveLoadService>(new SaveLoadService(_allService.Single<IPersistentProgressService>())); 
            _allService.RegisterSingle<MatchViewer>(new MatchViewer());
            _allService.RegisterSingle<IGameFactory>(new GameFactory(_stateMachine,_allService.Single<IPersistentProgressService>()
                ,_allService.Single<ISaveLoadService>(),_allService.Single<MatchViewer>(),_allService.Single<IAssetProvider>()));
            _allService.RegisterSingle<ISceneLoader>(new SceneLoader());
            
        }
    }
}