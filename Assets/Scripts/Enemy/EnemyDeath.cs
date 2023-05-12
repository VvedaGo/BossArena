using UnityEngine;

namespace Enemy
{
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private EnemyHealth _enemyHealth;
        
        private void Start()
        {
            _enemyHealth.Die += Die;
        }

        private void OnDestroy()
        {
            _enemyHealth.Die -= Die;
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}
