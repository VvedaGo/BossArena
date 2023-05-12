using UnityEngine;

namespace Data
{
    public class SpawnZone : MonoBehaviour
    {
        [SerializeField] private TeamColor _teamColor;
        public TeamColor GetColor => _teamColor;
    }
}
