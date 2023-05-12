using System;
using Logic;
using UnityEngine;


namespace Infrastructure.Services
{
    public class MatchViewer
    {
        public Action<MatchResult.ResultGame> EndGame;


        public void SendEndGame(MatchResult.ResultGame resultGame)
        {
            Debug.Log("End Game");
            EndGame?.Invoke(resultGame);
        }
    }
}