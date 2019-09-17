using AlterLeague.Data.EF.Models;
using AlterLeague.Data.IDAL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AlterLeague.Data.DAL
{
    public class PlayerDAL : IPlayerDAL
    {
        private AlterLeagueContext _context;

        public PlayerDAL(DbContext context)
        {
            _context = (AlterLeagueContext)context;
        }

        #region CREATE

        public void InsertPlayer(Player player)
        {
            _context.Player.Add(player);
            _context.SaveChanges();
        }

        #endregion

        #region READ
        public List<Player> GetAllPlayers()
        {
            return _context.Player.ToList();
        }

        public Player GetPlayerById(int id)
        {
            return _context.Player.Where(p => p.PlayerId == id).SingleOrDefault();
        }
        #endregion

        #region UPDATE
        #endregion

        #region DELETE
        public void DeletePlayerById(int id)
        {
            Player toRemove = new Player { PlayerId = id };
            _context.Player.Remove(toRemove);
            _context.SaveChanges();
        }
        #endregion
    }
}
