using AlterLeague.Data.EF.Models;
using AlterLeague.Data.IDAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlterLeague.Data.DAL
{
    public class Player_GameDAL : IPlayer_GameDAL
    {
        private AlterLeagueContext _context;

        public Player_GameDAL(DbContext context)
        {
            _context = (AlterLeagueContext)context;
        }
        public List<Player> GetPlayersByGameId(int gameId)
        {
            List<Player> result = (from playerGame in _context.PlayerGame
                                  join player in _context.Player on playerGame.PlayerId equals player.PlayerId
                                  where playerGame.GameId == gameId
                                  select player).ToList();

            return result;
        }
    }
}
