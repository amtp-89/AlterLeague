using AlterLeague.Data.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlterLeague.Data.IDAL
{
    public interface IGameDAL
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
        void DeleteGameById(int id);
        #endregion
    }
}
