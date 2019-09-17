using AlterLeague.Data.IDAL;
using AlterLeague.Domain.ILogic;
using AlterLeague.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using EFGameModel = AlterLeague.Data.EF.Models.Game;

namespace AlterLeague.Domain.Logic
{
    public class GameLogic : IGameLogic
    {
        private IGameDAL _iGameDAL;

        public GameLogic(IGameDAL iGameDAL)
        {
            _iGameDAL = iGameDAL;
        }

        public Game MapPlayer(EFGameModel game)
        {
            return new Game
            {
                gameId = game.GameId,
                location = game.Location,
                price = game.Price,
                time = game.Time,
                winner = game.Winner,
                loser = game.Loser,
                result = game.Result
            };
        }

        #region CREATE
        #endregion

        #region READ
        public List<Game> GetAllGames()
        {
            List<Game> result = new List<Game>();
            _iGameDAL.GetAllGames().ForEach(p => result.Add(
                MapPlayer(p)
            ));

            return result;
        }

        public Game GetGameById(int id)
        {
            return MapPlayer(_iGameDAL.GetGameById(id));
        }
        #endregion

        #region UPDATE
        #endregion

        #region DELETE
        #endregion
    }
}
