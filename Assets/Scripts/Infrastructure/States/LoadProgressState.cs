using Data;
using Infrastructure.Services;

namespace Infrastructure.States
{
    public class LoadProgressState:IStateGame
    {
        private readonly GameStateMachine _stateMachine;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IPersistentProgressService _progressService;


        public LoadProgressState(GameStateMachine stateMachine,ISaveLoadService saveLoadService,IPersistentProgressService progressService)
        {
            _stateMachine = stateMachine;
            _saveLoadService = saveLoadService;
            _progressService = progressService;
        }
        public void Enter()
        {
            _progressService.Progress =
                _saveLoadService.LoadProgress();
                
            
            _stateMachine.Enter<MenuState>();
        }

        public void Exit()
        {
            
        }
    }
}