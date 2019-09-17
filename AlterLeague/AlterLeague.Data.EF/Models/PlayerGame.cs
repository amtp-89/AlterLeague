using System;
using System.Collections.Generic;

namespace AlterLeague.Data.EF.Models
{
    public partial class PlayerGame
    {
        public int PlayerGameId { get; set; }
        public int? PlayerId { get; set; }
        public int? GameId { get; set; }

        public virtual Game Game { get; set; }
        public virtual Player Player { get; set; }
    }
}
