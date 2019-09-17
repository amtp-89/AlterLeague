using AlterLeague.Data.IDAL;
using AlterLeague.Domain.ILogic;
using AlterLeague.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using EFPlayerModel = AlterLeague.Data.EF.Models.Player;

namespace AlterLeague.Domain.Logic
{
    public class PlayerLogic : IPlayerLogic
    {
        private IPlayerDAL _iPlayerDAL;

        public PlayerLogic(IPlayerDAL iPlayerDAL)
        {
            _iPlayerDAL = iPlayerDAL;
        }

        #region Mapping
        public Player MapPlayerToModel(EFPlayerModel player)
        {
            return new Player
            {
                playerId = player.PlayerId,
                name = player.Name,
                birth = player.Birth.Value,
                photo = player.Photo,
                wins = player.Wins,
                ties = player.Ties,
                losses = player.Losses
            };
        }

        public EFPlayerModel MapPlayerToEF(Player player)
        {
            return new EFPlayerModel
            {
                PlayerId = player.playerId,
                Name = player.name,
                Birth = player.birth,
                Photo = player.photo,
                Wins = player.wins,
                Ties = player.ties,
                Losses = player.losses
            };
        }
        #endregion

        #region CREATE

        public void InsertPlayer(Player player)
        {
            _iPlayerDAL.InsertPlayer(MapPlayerToEF(player));
        }

        #endregion

        #region READ
        public List<Player> GetAllPlayers()
        {
            List<Player> result = new List<Player>();
            _iPlayerDAL.GetAllPlayers().ForEach(p => result.Add(
                MapPlayerToModel(p)
            )); 

            return result;
        }

        public Player GetPlayerById(int id)
        {
            return MapPlayerToModel(_iPlayerDAL.GetPlayerById(id));
        }
        #endregion

        #region UPDATE
        #endregion

        #region DELETE
        #endregion        
    }
}
