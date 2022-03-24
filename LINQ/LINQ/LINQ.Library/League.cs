using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Library
{
    public class League
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfTeams { get; set; }
        public int YearFounded { get; set; }
        public string President { get; set; }
        public List<Club> Clubs { get; set; }

        public override string ToString()
        {
            return $"{Name} has {NumberOfTeams} teams, was founded in {YearFounded} and the active president now is {President}";
        }

    }
}
