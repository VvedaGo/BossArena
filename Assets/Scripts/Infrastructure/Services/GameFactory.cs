using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Enemy;
using Enemy.EnemyStateMachine;
using Infrastructure.States;
using Logic;
using StaticData;
using Ui;
using UnityEngine;
using UnityEngine.AI;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;


namespace Infrastructure.Services
{
    public class GameFactory : IGameFactory
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IPersistentProgressService _persistentProgressService;
        private readonly ISaveLoadService _saveLoadService;
        private readonly MatchViewer _matchViewer;
        private readonly IAssetProvider _assetProvider;
        private readonly List<TeamZone> _teamZones;
        
        private MatchUnitStorage _matchUnitStorage;
        private AllUnitConfig _unitsConfig;


        public GameFactory(GameStateMachine stateMachine, IPersistentProgressService persistentProgressService,
            ISaveLoadService saveLoadService, MatchViewer matchViewer, IAssetProvider assetProvider)
        {
            _stateMachine = stateMachine;
            _persistentProgressService = persistentProgressService;
            _saveLoadService = saveLoadService;
            _matchViewer = matchViewer;
            _assetProvider = assetProvider;

            _teamZones = new List<TeamZone>();
            _matchUnitStorage = new MatchUnitStorage();
            _unitsConfig = _assetProvider.GetUnitConfig();
        }

        private Vector3 PositionSpawn(Collider zone)
        {
            Bounds bounds = zone.bounds;
            Vector3 minVector = bounds.center - bounds.extents;
            Vector3 maxVector = bounds.center + bounds.extents;
            Vector3 positionSpawn = new Vector3(Random.Range(minVector.x, maxVector.x), bounds.center.y,
                Random.Range(minVector.z, maxVector.z));

            return positionSpawn;
        }

        public GameObject CreateUnit(TeamColor teamColor, UnitType unitType)
        {
            var zoneToSpawn = _teamZones.FirstOrDefault(zone => zone.TeamColor == teamColor);
            UnitConfig config = _unitsConfig.Configs.FirstOrDefault(unitConfig => unitConfig.UnitType == unitType);
            GameObject prefabToSpawn = teamColor == TeamColor.Blue ? config.PrefabBlue : config.PrefabRed;

            GameObject unit = Object.Instantiate(prefabToSpawn,
                PositionSpawn(zoneToSpawn.ZoneCollider), Quaternion.identity);

            _matchUnitStorage.AddUnitToTeam(unit.transform, teamColor);
            unit.GetComponent<EnemyStateMachine>().Initialize();

            unit.GetComponent<UnitInfo>().SetTeam(teamColor);
            unit.GetComponent<ActorUI>().DrawBar(teamColor == TeamColor.Blue ? Color.blue : Color.red);
            unit.GetComponent<OpponentLocator>().Initialize(this);
            unit.GetComponent<EnemyHealth>().SetHealth(config.Hp);
            unit.GetComponent<EnemyAttack>().Initialization(config.Damage, config.AttackReload);
            unit.GetComponent<NavMeshAgent>().speed = config.Speed;
            unit.GetComponent<UnitInfo>().Initialize(_matchViewer);
            return unit;
        }


        public void CreateZone(TeamColor zoneColor)
        {
            TeamZone teamZone = new TeamZone {TeamColor = zoneColor};
            SpawnZoneData zoneData = _assetProvider.GetZoneData(zoneColor);
            teamZone.ZoneCollider = Object.Instantiate(zoneData.Prefab, zoneData.Position, Quaternion.identity)
                .GetComponent<Collider>();
            _teamZones.Add(teamZone);
        }

        public MenuUi CreateHudMenu()
        {
            MenuUi menuUi = Object.Instantiate(Resources.Load<MenuUi>(AssetPath.PathMenuUi), Vector3.zero,
                Quaternion.identity);
            menuUi.Construct(_stateMachine, _persistentProgressService, _saveLoadService);
            menuUi.LoadLevelsInfo(_assetProvider.GetLevels());
            return menuUi;
        }

        public GameUi CreateHudGame()
        {
            GameUi gameUi = Object.Instantiate(Resources.Load<GameUi>(AssetPath.PathGameUi));
            return gameUi;
        }


        public void GetClosedOpponent(Action<Transform> setTargetUnit, TeamColor teamColor, Vector3 unitPosition)
        {
            Transform nextUnit = _matchUnitStorage.GetClosedUnitFromOpponentTeam(teamColor, unitPosition);

            if (nextUnit == null)
            {
                _matchViewer.SendEndGame(MatchResult.ResultGame.Win);
            }
            else
            {
                setTargetUnit?.Invoke(nextUnit);
            }
        }

        public void SendFirstTarget()
        {
            foreach (var t in _matchUnitStorage.TeamBlue)
            {
                t.GetComponent<EnemyStateMachine>().Enter<EnemyMoveState>();
            }

            foreach (var t in _matchUnitStorage.TeamRed)
            {
                t.GetComponent<EnemyStateMachine>().Enter<EnemyMoveState>();
            }
        }
    }
}