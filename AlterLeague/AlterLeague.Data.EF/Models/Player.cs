using System;
using System.Collections.Generic;

namespace AlterLeague.Data.EF.Models
{
    public partial class Player
    {
        public Player()
        {
            PlayerGame = new HashSet<PlayerGame>();
            TeamPlayer = new HashSet<TeamPlayer>();
        }

        public int PlayerId { get; set; }
        public string Name { get; set; }
        public DateTime? Birth { get; set; }
        public byte[] Photo { get; set; }
        public int? Wins { get; set; }
        public int? Ties { get; set; }
        public int? Losses { get; set; }

        public virtual ICollection<PlayerGame> PlayerGame { get; set; }
        public virtual ICollection<TeamPlayer> TeamPlayer { get; set; }
    }
}
