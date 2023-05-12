using System.Linq;
using Enemy.EnemyStateMachine;
using UnityEngine;

namespace Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private EnemyStateMachine.EnemyStateMachine _enemyStateMachine;
        [SerializeField] private UnitInfo _unitInfo;
        private bool _canAttack;
        public float CooldownTime { get; private set; }
        private float _damage = 30;
        private int _layerMask;

        private Coroutine _cooldownWaiter;
        private Collider _currentTouchCollider;
        private Collider[] _hitColliders;


        public void Initialization(float damage, float cooldownAttack)
        {
            _damage = damage;
            CooldownTime = cooldownAttack;
        }

        private void Start()
        {
            _layerMask = 1 << LayerMask.NameToLayer("Hittable");
            _hitColliders = new Collider[5];
        }


        public void OnAttack()
        {
            var attackColliders = Physics.OverlapSphereNonAlloc(transform.position, 3, _hitColliders, _layerMask);
            if (attackColliders > 0)
            {
                Transform opponentToDamage = OpponentFromColliders();
                if (opponentToDamage != null)
                {
                    opponentToDamage.GetComponentInParent<EnemyHealth>().GetDamage(_damage);
                }
            }

            _enemyStateMachine.Enter<EnemyMoveState>();
        }

        private Transform OpponentFromColliders()
        {
            var opponentList = _hitColliders.Where(collider1 => collider1 != null).Where(collider1 =>
                collider1.transform.GetComponentInParent<UnitInfo>().ColorTeam != _unitInfo.ColorTeam).ToList();

            return opponentList.Count > 0 ? opponentList[0].transform : null;
        }
    }

}