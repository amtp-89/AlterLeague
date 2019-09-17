using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlterLeague.Domain.ILogic;
using AlterLeague.Domain.Model;
using AlterLeague.WebAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlterLeague.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private IPlayerLogic _client;

        public PlayerController(IPlayerLogic client) 
        {
            _client = client;
        }

        public PlayerDTO MapToPlayerDTO(Player player)
        {
            return new PlayerDTO
            {
                playerId = player.playerId,
                name = player.name,
                birth = string.Format("{0:dd/MM/yyyy}", player.birth),
                age = CalculateAge(player.birth),
                photo = ImageConverterToString(player.photo),
                wins = player.wins,
                ties = player.ties,
                losses = player.losses,
                total = player.wins + player.ties + player.losses
            };
        }

        public string ImageConverterToString(byte[] img)
        {
            string imreBase64Data = Convert.ToBase64String(img);            

            return imreBase64Data;
        }

        public byte[] ImageConverterToBytes(string img)
        {
            byte[] bytes = Convert.FromBase64String(img);

            return bytes;
        }

        public int CalculateAge(DateTime birth)
        {
            int age = DateTime.Now.Year - birth.Year;
            int monthDifference = DateTime.Now.Month - birth.Month;
            int dayDifference = DateTime.Now.Day - birth.Day;

            return (monthDifference < 0 || dayDifference < 0) ? age : age-1;
        }

        [HttpGet("[action]")]
        public List<PlayerDTO> GetAllPlayers()
        {
            List<PlayerDTO> result = new List<PlayerDTO>();
            _client.GetAllPlayers().ForEach(p => result.Add(MapToPlayerDTO(p)));

            return result;
        }

        [HttpGet("[action]")]
        public PlayerDTO GetPlayerById([FromQuery] string playerId)
        {
            return MapToPlayerDTO(_client.GetPlayerById(Convert.ToInt32(playerId)));
        }

        [HttpPost("[action]")]
        public Player InsertPlayer([FromQuery] string name, [FromQuery] DateTime birth, [FromQuery] string photo, 
            [FromQuery] int wins, [FromQuery] int ties, [FromQuery] int losses)
        {
            Player player = new Player
            {
                name = name,
                birth = birth,
                photo = ImageConverterToBytes(photo),
                wins = wins,
                ties = ties,
                losses = losses
            };

            return player;
        }
    }
}