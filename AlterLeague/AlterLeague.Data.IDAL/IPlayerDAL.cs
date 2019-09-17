using AlterLeague.Data.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlterLeague.Data.IDAL
{
    public interface IPlayerDAL
    {
        #region CREATE

        void InsertPlayer(Player player);

        #endregion

        #region READ
        List<Player> GetAllPlayers();

        Player GetPlayerById(int id);
        #endregion

        #region UPDATE
        #endregion

        #region DELETE
        void DeletePlayerById(int id);
        #endregion
    }
}
