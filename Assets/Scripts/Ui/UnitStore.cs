using Infrastructure.Services;
using StaticData;
using TMPro;
using UnityEngine;

namespace Ui
{
    public class UnitStore : MonoBehaviour
    {
        [SerializeField] private GameObject _unitStorePage;
        [SerializeField] private TextMeshProUGUI _countFootmanUnit;
        [SerializeField] private TextMeshProUGUI _countTankUnit;
        private IPersistentProgressService _persistentProgressService;
        private ISaveLoadService _saveLoadService;

        public void Construct(IPersistentProgressService persistentProgressService,ISaveLoadService saveLoadService)
        {
            _persistentProgressService = persistentProgressService;
            _saveLoadService = saveLoadService;
            UpdateInfoUnits();
        }
        public void Open()
        {
            _unitStorePage.SetActive(true);
           
        }

        public void Close()
        {
            _unitStorePage.SetActive(false);
        }

        public void BuyUnitFootman()
        {
            _persistentProgressService.Progress.AddUnit(UnitType.Footman,1);
            _persistentProgressService.Progress.CoinCount -= 1;
            UpdateInfoUnits();
        }
        public void SellUnitFootman()
        {
            _persistentProgressService.Progress.RemoveUnit(UnitType.Footman,1);
            _persistentProgressService.Progress.CoinCount += 1;
            UpdateInfoUnits();
        }

        public void BuyUnitKnight()
        {
            _persistentProgressService.Progress.AddUnit(UnitType.Knight,1);
            _persistentProgressService.Progress.CoinCount -= 2;
            UpdateInfoUnits();
        }
        public void SellUnitKnight()
        {
            _persistentProgressService.Progress.RemoveUnit(UnitType.Knight,1);
            _persistentProgressService.Progress.CoinCount += 2;
            UpdateInfoUnits();
        }

        private void UpdateInfoUnits()
        {
            _countFootmanUnit.text = _persistentProgressService.Progress.CountUnits[UnitType.Footman].ToString();
            _countTankUnit.text = _persistentProgressService.Progress.CountUnits[UnitType.Knight].ToString();
            
            _saveLoadService.SaveProgress();
        }
    }
}
