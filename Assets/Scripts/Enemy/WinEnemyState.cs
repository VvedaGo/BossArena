using Enemy.EnemyStateMachine;

namespace Enemy
{
    public class WinEnemyState:IEnemyState
    {
        private readonly EnemyAnimator _enemyAnimator;

        public WinEnemyState(EnemyAnimator enemyAnimator)
        {
            _enemyAnimator = enemyAnimator;
        }
        public void Enter()
        {
            _enemyAnimator.Win();
        }

        public void Exit()
        {
            
        }
    }
}