using Data;
using Infrastructure.Services;
using Logic;
using UnityEngine;

namespace Enemy
{
    public class UnitInfo : MonoBehaviour
    {
        [SerializeField] private EnemyStateMachine.EnemyStateMachine _enemyStateMachine;
        private MatchViewer _matchViewer;
        public TeamColor ColorTeam { get; private set; }

        public void Initialize(MatchViewer matchViewer)
        {
            _matchViewer = matchViewer;
            _matchViewer.EndGame += EndGame;

        }
        public void SetTeam(TeamColor color)
        {
            ColorTeam = color;
        }

        private void EndGame(MatchResult.ResultGame result)
        {
            switch (result)
            {
             case MatchResult.ResultGame.Win:
                 _enemyStateMachine.Enter<WinEnemyState>();
                break;
             case MatchResult.ResultGame.Lose:
                 _enemyStateMachine.Enter<WinEnemyState>();
                 break;
            }
        }
        
        
    }
}
