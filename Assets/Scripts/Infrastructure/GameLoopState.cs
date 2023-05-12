using Infrastructure.Services;
using Infrastructure.States;
using Logic;
using Ui;
using UnityEngine;

namespace Infrastructure
{
    public class GameLoopState : IStateGame
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IGameFactory _gameFactory;
        private readonly MatchViewer _matchViewer;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IPersistentProgressService _persistentProgressService;
        private GameUi _gameUi;

        public GameLoopState(GameStateMachine gameStateMachine,IGameFactory gameFactory, MatchViewer matchViewer, ISaveLoadService saveLoadService,
            IPersistentProgressService persistentProgressService)
        {
            _gameStateMachine = gameStateMachine;
            _gameFactory = gameFactory;
            _matchViewer = matchViewer;
            _saveLoadService = saveLoadService;
            _persistentProgressService = persistentProgressService;
        }

        public void Enter()
        {
            _gameUi = _gameFactory.CreateHudGame();
            _gameUi.Initialize(_gameStateMachine);
            _gameFactory.SendFirstTarget();
            _matchViewer.EndGame+=EndGame;
        
            
        }

        public void Exit()
        {
        }

        private void EndGame(MatchResult.ResultGame resultGame)
        {
            Debug.Log("result game");
            if (resultGame == MatchResult.ResultGame.Win)
            {
                _gameUi.Construct("Winner");
                _persistentProgressService.Progress.CoinCount += 20;
                _saveLoadService.SaveProgress(); 
            }
            else
            {
                _gameUi.Construct("Loser");
            }
            _gameUi.Open();
        }
    }
}