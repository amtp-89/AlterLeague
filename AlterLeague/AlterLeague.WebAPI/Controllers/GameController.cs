using System;
using System.Collections.Generic;
using System.Linq;
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
    public class GameController : ControllerBase
    {
        private IGameLogic _client;

        public GameController(IGameLogic client)
        {
            _client = client;
        }

        public GameDTO MapToGameDTO(Game game)
        {
            return new GameDTO
            {
                gameId = game.gameId,
                location = game.location,
                price = game.price,
                pricePerPerson = game.price/10,
                time = game.time,
                winner = game.winner,
                loser = game.loser,
                result = game.result,
                played = game.played
            };
        }

        [HttpGet("[action]")]
        public List<GameDTO> GetAllGamess()
        {
            List<GameDTO> result = new List<GameDTO>();
            _client.GetAllGames().ForEach(p => result.Add(MapToGameDTO(p)));

            return result;
        }

        [HttpGet("[action]")]
        public GameDTO GetGameById([FromQuery] string gameId)
        {
            return MapToGameDTO(_client.GetGameById(Convert.ToInt32(gameId)));
        }
    }
}