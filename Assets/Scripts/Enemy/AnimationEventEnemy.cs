using Enemy.EnemyStateMachine;
using UnityEngine;

namespace Enemy
{
    public class AnimationEventEnemy : MonoBehaviour
    {
        private EnemyAttack _enemyAttack;
        private EnemyStateMachine.EnemyStateMachine _enemyStateMachine;

        private void Start()
        {
            _enemyAttack = GetComponentInParent<EnemyAttack>();
            _enemyStateMachine = GetComponentInParent<EnemyStateMachine.EnemyStateMachine>();
        }

        public void OnAttack()
        {
            _enemyAttack.OnAttack();
        }

        public void GetDamage()
        {
            _enemyStateMachine.Enter<EnemyMoveState>();
        }
    }
}
