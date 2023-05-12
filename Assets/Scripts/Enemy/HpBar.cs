using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
  [SerializeField] private Image _imageCurrent;

  public void SetValue(float current, float max)
  {
    _imageCurrent.fillAmount = current / max;
  }

  public void DrawBar(Color color)
  {
    _imageCurrent.color = color;
  }
}