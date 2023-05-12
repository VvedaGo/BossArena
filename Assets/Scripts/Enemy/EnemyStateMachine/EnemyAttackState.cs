using System.Collections;
using UnityEngine;

namespace Enemy.EnemyStateMachine
{
    public class EnemyAttackState : IEnemyState
    {
        private readonly EnemyStateMachine _enemyStateMachine;
        private readonly EnemyAttack _enemyAttack;
        private readonly EnemyAnimator _enemyAnimator;
        private readonly ICoroutineRunner _coroutineRunner;

        private bool _canAttack = true;

        public EnemyAttackState(EnemyStateMachine enemyStateMachine, EnemyAttack enemyAttack,
            EnemyAnimator enemyAnimator, ICoroutineRunner coroutineRunner)
        {
            _enemyStateMachine = enemyStateMachine;
            _enemyAttack = enemyAttack;
            _enemyAnimator = enemyAnimator;
            _coroutineRunner = coroutineRunner;
        }

        public void Enter()
        {
          
            if (_canAttack)
            {
                _enemyAnimator.PlayAttack();
                _canAttack = false;
                _coroutineRunner.StartCoroutine(CooldownAttack());
            }
            else
            {
                _enemyStateMachine.Enter<EnemyMoveState>();
            }
        }

        public void Exit()
        {
            
        }

        IEnumerator CooldownAttack()
        {
            yield return new WaitForSeconds(_enemyAttack.CooldownTime);
            _canAttack=true;
        }
    }
}