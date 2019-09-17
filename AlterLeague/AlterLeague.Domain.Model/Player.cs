using System;
using System.Collections.Generic;
using System.Text;

namespace AlterLeague.Domain.Model
{
    public class Player
    {
        public int playerId;
        public string name;
        public DateTime birth;
        public byte[] photo;
        public int? wins;
        public int? ties;
        public int? losses;
    }
}
