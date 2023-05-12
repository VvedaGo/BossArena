using Infrastructure.Services;
using Infrastructure.States;
using Logic;

namespace Infrastructure
{
    public class GameLoopState : IStateGame
    {
        private readonly IGameFactory _gameFactory;

        private readonly MatchViewer _matchViewer;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IPersistentProgressService _persistentProgressService;

        public GameLoopState(IGameFactory gameFactory, MatchViewer matchViewer, ISaveLoadService saveLoadService,
            IPersistentProgressService persistentProgressService)
        {
            _gameFactory = gameFactory;
            _matchViewer = matchViewer;
            _saveLoadService = saveLoadService;
            _persistentProgressService = persistentProgressService;
        }

        public void Enter()
        {
            _gameFactory.SendFirstTarget();
            _matchViewer.EndGame+=EndGame;
        }

        public void Exit()
        {
        }

        private void EndGame(MatchResult.ResultGame resultGame)
        {
            _persistentProgressService.Progress.CoinCount += 20;
            _saveLoadService.SaveProgress();
        }
    }
}