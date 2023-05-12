using UnityEngine;

namespace Enemy
{
    public class ActorUI : MonoBehaviour
    {
        [SerializeField] private EnemyHealth _enemyHealth;
        [SerializeField] private HpBar _hpBar;

        private void Start()
        {
            _enemyHealth.Changed += UpdateHealthView;
        }

        private void OnDestroy()
        {
            _enemyHealth.Changed -= UpdateHealthView;
        }

        private void UpdateHealthView()
        {
            _hpBar.SetValue(_enemyHealth.Current,_enemyHealth.Max);
        }

        public void DrawBar(Color color)
        {
            _hpBar.DrawBar(color);
        }
    }
}