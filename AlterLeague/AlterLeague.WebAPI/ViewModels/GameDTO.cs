using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlterLeague.WebAPI.ViewModels
{
    public class GameDTO
    {
        public int gameId;
        public string location;
        public double? price;
        public double? pricePerPerson;
        public DateTime? time;
        public int? winner;
        public int? loser;
        public string result;
        public bool? played;
    }
}
