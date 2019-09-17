using AlterLeague.Data.EF.Models;
using AlterLeague.Data.IDAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlterLeague.Data.DAL
{
    public class GameDAL : IGameDAL
    {
        private AlterLeagueContext _context;

        public GameDAL(DbContext context)
        {
            _context = (AlterLeagueContext)context;
        }

        #region CREATE
        #endregion

        #region READ
        public List<Game> GetAllGames()
        {
            return _context.Game.ToList();
        }

        public Game GetGameById(int id)
        {
            return _context.Game.Where(g => g.GameId == id).SingleOrDefault();
        }
        #endregion

        #region UPDATE
        #endregion

        #region DELETE
        public void DeleteGameById(int id)
        {
            Game toRemove = new Game { GameId = id };
            _context.Game.Remove(toRemove);
            _context.SaveChanges();
        }
        #endregion
    }
}
