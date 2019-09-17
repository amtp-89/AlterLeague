using System;
using System.Collections.Generic;

namespace AlterLeague.Data.EF.Models
{
    public partial class GameTeam
    {
        public int GameTeamId { get; set; }
        public int? GameId { get; set; }
        public int? TeamId { get; set; }

        public virtual Game Game { get; set; }
        public virtual Team Team { get; set; }
    }
}
