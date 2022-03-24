using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Library
{
    public class Club
    {
        public int ClubId { get; set; }
        public string Name { get; set; }
        public double Budget { get; set; }
        public string Country { get; set; }
        public string CEO { get; set; }
        public string LeagueName { get; set; }
        public int LeagueId { get; set; }
        public List<Player> Players { get; set; }

        public override string ToString()
        {
            return $"{Name} is a club that plays in {LeagueName}, {Country}, it's CEO is { CEO} and has a budgret of {Budget}"; 
        }
    }       
}
