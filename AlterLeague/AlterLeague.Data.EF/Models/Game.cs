using System;
using System.Collections.Generic;

namespace AlterLeague.Data.EF.Models
{
    public partial class Game
    {
        public Game()
        {
            GameTeam = new HashSet<GameTeam>();
            PlayerGame = new HashSet<PlayerGame>();
        }

        public int GameId { get; set; }
        public string Location { get; set; }
        public double? Price { get; set; }
        public DateTime? Time { get; set; }
        public int? Winner { get; set; }
        public int? Loser { get; set; }
        public string Result { get; set; }
        public bool? Played { get; set; }

        public virtual ICollection<GameTeam> GameTeam { get; set; }
        public virtual ICollection<PlayerGame> PlayerGame { get; set; }
    }
}
