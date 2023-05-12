using System;
using Logic;


namespace Infrastructure.Services
{
    public class MatchViewer
    {
        public Action<MatchResult.ResultGame> EndGame;


        public void SendEndGame(MatchResult.ResultGame resultGame)
        {
            EndGame?.Invoke(resultGame);
        }
    }
}