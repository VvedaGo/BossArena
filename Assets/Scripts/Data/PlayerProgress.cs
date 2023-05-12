using System.Collections.Generic;
using StaticData;

namespace Data
{
    public class PlayerProgress
    {
        public int CoinCount;
        public int NumberLevel;
        public readonly Dictionary<UnitType, int> CountUnits;

        public PlayerProgress()
        {
            CountUnits = new Dictionary<UnitType, int>();
        }

        public void AddUnit(UnitType typeUnit, int count)
        {
            if (CountUnits.TryGetValue(typeUnit, out int previousValue))
            {
                CountUnits[typeUnit] = previousValue + count;
            }
            else
            {
                CountUnits[typeUnit] =  count;
            }
        }

        public void RemoveUnit(UnitType typeUnit, int count)
        {
            if (CountUnits.TryGetValue(typeUnit, out int previousValue))
            {
                CountUnits[typeUnit] = previousValue - count;
            }
        }
    }
}