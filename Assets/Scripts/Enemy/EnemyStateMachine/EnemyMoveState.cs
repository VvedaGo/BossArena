using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy.EnemyStateMachine
{
    public class EnemyMoveState : IEnemyState
    {
        private readonly EnemyStateMachine _enemyStateMachine;
        private readonly EnemyAnimator _enemyAnimator;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly NavMeshAgent _agent;
        private readonly OpponentLocator _opponentLocator;

        private Transform _targetOpponent;
        private Coroutine _moveCoroutine;

        private float _distanceToAttack = 3f;

        public EnemyMoveState(EnemyStateMachine enemyStateMachine, EnemyAnimator enemyAnimator,
            ICoroutineRunner coroutineRunner, NavMeshAgent agent, OpponentLocator opponentLocator)
        {
            _enemyStateMachine = enemyStateMachine;
            _enemyAnimator = enemyAnimator;
            _coroutineRunner = coroutineRunner;
            _agent = agent;
            _opponentLocator = opponentLocator;
        }

        public void Enter()
        {
            _agent.ResetPath();
            _moveCoroutine = _coroutineRunner.StartCoroutine(MoveToTarget());
        }

        public void Exit()
        {
           
        }

        private IEnumerator MoveToTarget()
        {
            while (_agent.gameObject.activeSelf)
            {
                yield return null;
                _opponentLocator.FindNewOpponent();
                if (_opponentLocator.TargetUnit == null)
                {
                    continue;
                }

                _agent.transform.LookAt(_opponentLocator.TargetUnit);

                _agent.SetDestination(_agent.destination);

                if (!TrueDistanceToAttack())
                {
                    _enemyAnimator.Move();
                    continue;
                }
                else
                {
                    _enemyAnimator.Stand();
                }


                _agent.isStopped = true;
                _enemyStateMachine.Enter<EnemyAttackState>();
            }
        }

        private bool TrueDistanceToAttack()
        {
            return (Vector3.Distance(_agent.transform.position, _opponentLocator.TargetUnit.position) <=
                    _distanceToAttack);
        }
    }
}