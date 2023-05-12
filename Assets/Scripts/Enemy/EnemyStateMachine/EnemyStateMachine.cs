using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy.EnemyStateMachine
{
    public class EnemyStateMachine : MonoBehaviour,ICoroutineRunner
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private OpponentLocator _opponentLocator;
        [SerializeField] private EnemyAnimator _enemyAnimator;
        [SerializeField] private EnemyAttack _enemyAttack;
        private Dictionary<Type, IEnemyState> _enemyStates;
        private IEnemyState _currentState;

        public void Initialize()
        {
            _enemyStates = new Dictionary<Type, IEnemyState>
            {
                [typeof(EnemyMoveState)] = new EnemyMoveState(this,_enemyAnimator, this,_navMeshAgent,_opponentLocator),
                [typeof(EnemyAttackState)] = new EnemyAttackState(this,_enemyAttack,_enemyAnimator, this),
                [typeof(WinEnemyState)] = new WinEnemyState(_enemyAnimator),
                [typeof(LoseEnemyState)] = new LoseEnemyState()
            };
            
        }
       

        public void Enter<TEState>() where TEState : IEnemyState
        {
            ChangeState<TEState>();
        }

        public void Exit()
        {
        }

        private void ChangeState<TEState>() where TEState : IEnemyState
        {
            _currentState?.Exit();
            IEnemyState nextState = _enemyStates[typeof(TEState)];
            _currentState = nextState;
            _currentState.Enter();
        }

        Coroutine ICoroutineRunner.StartCoroutine(IEnumerator coroutine)
        {
           return StartCoroutine(coroutine);
        }

        void ICoroutineRunner.StopCoroutine(Coroutine coroutine)
        {
            StopCoroutine(coroutine);
        }
    }
}