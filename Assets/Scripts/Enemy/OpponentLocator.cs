using Infrastructure;
using Infrastructure.Services;
using UnityEngine;

namespace Enemy
{
    public class OpponentLocator : MonoBehaviour
    {
        [SerializeField] private EnemyMover _enemyMover;
        [SerializeField] private UnitInfo _unitInfo;
        private IGameFactory _gameFactory;
        public Transform TargetUnit { get; private set; }

        public void Initialize(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        private void Start()
        {
            _enemyMover.LostTarget += FindNewOpponent;
        }

        private void OnDestroy()
        {
            _enemyMover.LostTarget -= FindNewOpponent;
        }

        public void FindNewOpponent()
        {
            if (TargetUnit != null)
                TargetUnit.GetComponent<EnemyHealth>().Die -= FindNewOpponent;

            _gameFactory.GetClosedOpponent(SetTargetUnit, _unitInfo.ColorTeam, transform.position);
        }

        private void SetTargetUnit(Transform unitTransform)
        {
            TargetUnit = unitTransform;


            if (TargetUnit != null)
            {
                _enemyMover.SetTarget(TargetUnit);
                TargetUnit.GetComponent<EnemyHealth>().Die += FindNewOpponent;
            }
        }
    }
}