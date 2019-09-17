using AlterLeague.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlterLeague.Domain.ILogic
{
    public interface IGameLogic
    {
        #region CREATE
        #endregion

        #region READ
        List<Game> GetAllGames();

        Game GetGameById(int id);
        #endregion

        #region UPDATE
        #endregion

        #region DELETE
        #endregion
    }
}
