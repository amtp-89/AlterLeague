using System;
using System.Collections.Generic;

namespace AlterLeague.Data.EF.Models
{
    public partial class TeamPlayer
    {
        public int TeamPlayerId { get; set; }
        public int? TeamId { get; set; }
        public int? PlayerId { get; set; }

        public virtual Player Player { get; set; }
        public virtual Team Team { get; set; }
    }
}
