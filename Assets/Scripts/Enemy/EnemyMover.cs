using System;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyMover : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private EnemyAnimator _enemyAnimator;
       [SerializeField] private Transform _target;
        public event Action LostTarget; 
        
        private void Update()
        {
            if (_target != null&&!_navMeshAgent.isStopped&& Vector3.Distance(transform.position,_target.position)>5.5f)
            {
                _navMeshAgent.SetDestination(_target.position);
                _enemyAnimator.Move();
                transform.LookAt(_target);
            }
        }

        public void SetTarget(Transform target)
        {
            _target = target;
            if (_target == null)
            {
                LostTarget?.Invoke();
            }
        }

        public void StopMove()
        {
            _navMeshAgent.isStopped = true;
        }

        public void StartMove()
        {
            _navMeshAgent.isStopped = false;
        }
    }
}
