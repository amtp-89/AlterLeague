using System;

namespace AlterLeague.WebAPI.ViewModels
{
    public class PlayerDTO
    {
        public int playerId;
        public string name;
        public string birth;
        public int? age;
        public string photo;
        public int? wins;
        public int? ties;
        public int? losses;
        public int? total;
    }
}
