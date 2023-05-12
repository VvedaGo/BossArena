using System;
using UnityEngine;

namespace Enemy
{
    public class TriggerObserver : MonoBehaviour
    {
        public event Action<Collider> Enter ;
        public event Action<Collider> Exit;
        public event Action<Collision> Stay;

        

        private void OnTriggerEnter(Collider other)
        {
            Enter?.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            Exit?.Invoke(other);
        }

        private void OnCollisionStay(Collision other)
        {
            Stay?.Invoke(other);
        }
    }
}
