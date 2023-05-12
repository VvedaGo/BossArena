using Infrastructure.Services;
using Infrastructure.States;

namespace Infrastructure
{
    public class Game
    {
        public readonly GameStateMachine GameStateMachine;

        public Game()
        {
            GameStateMachine=new GameStateMachine(AllService.Container);
        }
       
    }
}