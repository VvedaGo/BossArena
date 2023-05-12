using TMPro;
using UnityEngine;

public class LevelInstance : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI _numberLevelText;
   [SerializeField] private TextMeshProUGUI _rewardCountText;

   private int _numberLevel;
   private LevelMap _levelMap;

   public void Initialize(LevelMap levelMap)
   {
      _levelMap = levelMap;
   }

   public void ChooseLevel()
   {
      _levelMap.StartLevel(_numberLevel);
   }

   public void LoadValues(int numberLevel, int rewardCount)
   {
      _numberLevelText.text = $"Level: {numberLevel + 1}";
      _rewardCountText.text = $"Reward: {rewardCount}";

      _numberLevel = numberLevel;
   }
}
