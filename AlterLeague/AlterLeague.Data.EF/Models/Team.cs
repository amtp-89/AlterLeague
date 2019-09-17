using System;
using System.Collections.Generic;

namespace AlterLeague.Data.EF.Models
{
    public partial class Team
    {
        public Team()
        {
            GameTeam = new HashSet<GameTeam>();
            TeamPlayer = new HashSet<TeamPlayer>();
        }

        public int TeamId { get; set; }
        public string Name { get; set; }
        public int? Wins { get; set; }
        public int? Ties { get; set; }
        public int? Losses { get; set; }

        public virtual ICollection<GameTeam> GameTeam { get; set; }
        public virtual ICollection<TeamPlayer> TeamPlayer { get; set; }
    }
}
