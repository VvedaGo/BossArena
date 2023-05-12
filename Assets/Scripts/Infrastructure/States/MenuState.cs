using Infrastructure.Services;
using Ui;

namespace Infrastructure.States
{
    public class MenuState : IStateGame
    {
        private const string NameScene = "MenuScene";
        private readonly GameStateMachine _stateMachine;
        private readonly IGameFactory _gameFactory;
        private readonly ISceneLoader _sceneLoader;
        private MenuUi _menuUi;

        public MenuState(GameStateMachine stateMachine, IGameFactory gameFactory, ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _gameFactory = gameFactory;
            _sceneLoader = sceneLoader;
        }
        
        public void Enter()
        {
            _sceneLoader.LoadSceneAsync(NameScene,LoadedScene);
        }

        private void LoadedScene()
        {
            _menuUi= _gameFactory.CreateHudMenu();
        }

        public void Exit()
        {
           
        }

    }
}