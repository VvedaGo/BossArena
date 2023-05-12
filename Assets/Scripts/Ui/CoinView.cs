using TMPro;
using UnityEngine;

namespace Ui
{
    public class CoinView:MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _countCoin;

        public void SetCount(int count)
        {
            _countCoin.text = count.ToString();
        }
    }
}