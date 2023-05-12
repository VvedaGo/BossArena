using Infrastructure.Services;

namespace Infrastructure.States
{
    public class GameEndState:IStateGame
    {
        private readonly IGameFactory _gameFactory;

        public GameEndState(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }
        public void Enter()
        {
         
        }

        public void Exit()
        {
        
        }
    }
}