using AlterLeague.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlterLeague.Domain.ILogic
{
    public interface IPlayerLogic
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
        #endregion
    }
}
