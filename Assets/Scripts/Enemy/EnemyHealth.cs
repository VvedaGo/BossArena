using System;
using UnityEngine;


namespace Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private EnemyAnimator _enemyAnimator;
        public event Action Changed;
        public event Action Die;

        public float Current { get; private set; }
        public float Max { get; private set; }

        private void Start()
        {
            Max = 100;
            Current = 100;
            Changed?.Invoke();
        }

        public void GetDamage(float damage)
        {
            if (Current <= 0)
                return;

            Current -= damage;
            _enemyAnimator.PlayHit();
            Changed?.Invoke();

            if (Current <= 0)
                Die?.Invoke();
        }

        public void SetHealth(float health)
        {
            Max = health;
            Current = health;
            Changed?.Invoke();
        }
    }
}