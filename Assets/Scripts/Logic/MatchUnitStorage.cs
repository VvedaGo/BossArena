using System.Collections.Generic;
using Data;
using UnityEngine;

namespace Logic
{
    public class MatchUnitStorage
    {
        public List<Transform> TeamBlue { get; private set; }
        public List<Transform> TeamRed{ get; private set; }

        public MatchUnitStorage()
        {
            TeamBlue = new List<Transform>();
            TeamRed = new List<Transform>();
        }

        public void AddUnitToTeam(Transform unitTransform, TeamColor teamColor)
        {
            List<Transform>teamWithColor= teamColor == TeamColor.Blue ? TeamBlue : TeamRed;
            teamWithColor.Add(unitTransform);
        }

        public Transform GetClosedUnitFromOpponentTeam(TeamColor colorTeam, Vector3 unitPosition)
        {
            List<Transform>teamWithColor= colorTeam == TeamColor.Blue ? TeamRed : TeamBlue;

            Transform closedOpponent=null;
            float closedDistance=float.MaxValue;
            for (int i = 0; i < teamWithColor.Count; i++)
            {
                if (teamWithColor[i] == null)
                {
                    teamWithColor.RemoveAt(i);
                    continue;
                }
                if (Vector3.Distance(teamWithColor[i].position, unitPosition)<closedDistance)
                {
                    closedOpponent = teamWithColor[i];
                    closedDistance = Vector3.Distance(teamWithColor[i].position, unitPosition);
                }
            }
           
            return closedOpponent;
        }

    }
}