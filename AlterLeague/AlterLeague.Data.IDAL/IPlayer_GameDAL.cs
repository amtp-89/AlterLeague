using AlterLeague.Data.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlterLeague.Data.IDAL
{
    public interface IPlayer_GameDAL
    {
        List<Player> GetPlayersByGameId(int gameId);
    }
}
