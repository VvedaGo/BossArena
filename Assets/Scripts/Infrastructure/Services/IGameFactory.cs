using System;
using Data;
using StaticData;
using Ui;
using UnityEngine;

namespace Infrastructure.Services
{
    public interface IGameFactory:IService
    {
        GameObject CreateUnit(TeamColor teamColor,UnitType unitType);
        void CreateZone(TeamColor teamColor);
        void GetClosedOpponent(Action<Transform> setTargetUnit, TeamColor teamColor, Vector3 unitPosition);
        void SendFirstTarget();
        MenuUi CreateHudMenu();
        
    }
}