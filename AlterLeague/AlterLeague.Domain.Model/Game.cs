using System;
using System.Collections.Generic;
using System.Text;

namespace AlterLeague.Domain.Model
{
    public class Game
    {
        public int gameId;
        public string location;
        public double? price;
        public DateTime? time;
        public int? winner;
        public int? loser;
        public string result;
        public bool? played;
    }
}
