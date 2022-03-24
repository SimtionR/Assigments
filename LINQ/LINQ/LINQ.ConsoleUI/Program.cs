// See https://aka.ms/new-console-template for more information


using LINQ.Library;
using LINQ.Library.Extensions;

namespace LIQN.ConsoleUI
{
    public static class Program
    {
        public static void Main(string[] args)
        {

            //Extension Methods
            var cristiano = _players.Where(p => p.FirstName == "Cristiano").FirstOrDefault();
         
            //Console.WriteLine($"salary cristiano : {cristiano.Salary}");
            cristiano.HasScored();
            cristiano.RaiseSalary(2);

            //Console.WriteLine($"Salary after raise for goal {cristiano.Salary}");

            var city = _clubs.Where(c => c.Name == "Manchester City").FirstOrDefault();
            //Console.WriteLine($"Budget man city {city.Budget}");

            city.GetLoanForBudget(20000);
            //Console.WriteLine($"Budget man city after loan from sheiks {city.Budget}");


         
           
        }

        private static void PrintCollection<T>(IEnumerable<T> source)
        {
            foreach (var item in source)
            {
                Console.WriteLine(item);
            }
        }


        public static void Filtering()
        {
            // where
            var freePlayerNextYear = _players.Where(p => p.ContractLength < 2);
           

            //take

            var fiveFreePlayers = freePlayerNextYear.Take(5);
            
            // Skip

            var freePlayersWithoutFirstTwo = freePlayerNextYear.Skip(2);
            

            //TakeWhile

            var whileUnder30AndRich = _players.TakeWhile(p => p.Age < 30 && p.Salary> 4);
           

            //SkipWhile

            var skipWhileLongTimeContract = _players.SkipWhile(p => p.Age == 23);
            

            //Distinct

            var distinctList = _players.Distinct();

            //Chunk

            var chucnkedDistinctLisnt = distinctList.Chunk(5);

        }


        public static void Projection()
        {
            //Select
            var salaryByTeam = _players.Select(p => new { p.FirstName, p.Salary, p.ClubId })
                                        .OrderBy(p => p.ClubId);
            //SelectMany
            var playersFromTeams = _clubs.SelectMany(p => p.Players);

            
        }


        public static void LinqJoins()
        {
            //   Join
            var playersByTeam = _players.Join(_clubs, player => player.ClubId, club => club.ClubId,
                (player, club) => new { player.FirstName, player.LastName, club.Name });

            // join sql
            var playersByTeamSql = from clubs in _clubs
                                   group clubs by clubs.Name into clb
                                   join players in _players on clb.FirstOrDefault().ClubId equals players.ClubId
                                   select new { clb.FirstOrDefault().Name, players.FirstName, players.LastName };



            //group join 
            var playerTeamGroup  = from clubs in _clubs
                                join players in _players on clubs.ClubId equals players.ClubId into playersGroup
                                select new { clubs.Name, playersGroup };
            

            foreach(var group in playerTeamGroup)
            {
                Console.WriteLine($"Team {group.Name} with following players : ");

                foreach (var player in group.playersGroup)
                {
                    Console.WriteLine($"{player.FirstName} - {player.LastName}");
                }

                Console.WriteLine("----------------");
            
        }


            //Zip 

            var test = _players.Zip(_clubs, (first, second) => first.FirstName + second.LeagueName);

            foreach(var item in test)
            {
                Console.WriteLine(item);
            }
        }


        public static void LinqOrdering()
        {
            //Order by then  by
            var playersOrdered = _players.OrderBy(p => p.ClubId).ThenBy(p => p.Age);


            //descending


            var playersOrdered2 = _players.OrderByDescending(p => p.Age).ThenByDescending(p => p.Salary);

            //reverese
            
            var clubsReversed = _clubs.Reverse();

            PrintCollection(clubsReversed);

        }

        public static void LinqGruping()
        {
            // Group By

            var players = _players.GroupBy(p => p.ContractLength);
            foreach(var contractLength in players)
            {
                Console.WriteLine($" Years remaining on contract: {contractLength.Key}");
                foreach(var player in  contractLength)
                {
                    Console.WriteLine($"{player.FirstName} {player.LastName}");
                }
            }
        }


        public static void LinqSetOperator()
        {
            //Concat

            var defenders = _players.Where(p => p.Position == "Defender");
            var goalkeepers = _players.Where(p => p.Position == "Goalkeeper");

            var defendersAndGoalkeepers = defenders.Concat(goalkeepers);


            //Intersect

            var richestPlayers = _players.Where(p => p.Salary > 8);
            var oldPlayers = _players.Where(p => p.Age > 33);

            var oldAndRich = richestPlayers.Intersect(oldPlayers);



            //Union

            var cristiano = _players.Where(p => p.Age == 37).FirstOrDefault();

            IEnumerable<Player> cristianoX10 = Enumerable.Repeat(cristiano, 10);

            var goats = cristianoX10.Union(_players.Where(p => p.FirstName == "Lionel"));
            

            //Except

            var outCristiano = richestPlayers.Except(cristianoX10);
            PrintCollection(outCristiano);
        }


        public static void LinqConversion()
        {
            //OfType
            var coachPlayers = _players.OfType<PlayerCoach>();

            
            //Cast
            var allPlayers = _players.Cast<Player>();
          

            //ToArray

            var clubsBudgetArray = _clubs.Where(c => c.Budget > 800000000).ToArray();
           

            //ToList


            var goalkeeperList = _players.Where(p => p.Position == "Goalkeeper").ToList();
            

            //ToDictionary

            var playersClubDictionary = _players.Distinct().ToDictionary(p => p.FirstName, p => p.ClubId);

            //ToLookup

            var playersByLetter = _players.OrderBy(p=>p.FirstName).ToLookup(p => p.FirstName[0], p =>p.FirstName+" Salary: " + p.Salary + " Age: " + p.Age + " " + p.Position);

            foreach(var pack in playersByLetter)
            {
                Console.WriteLine(pack.Key);
                foreach(var player in pack)
                {
                    Console.WriteLine(player);
                }
            }


            //asEnumerable

            var goalkeeperEnumerable = goalkeeperList.AsEnumerable();

            //asQueryable

            var clubsBudgetQueryable = clubsBudgetArray.AsQueryable();
            PrintCollection(clubsBudgetQueryable);



        }

        public static void LinqElementOperators()
        {
            //First, FirstOrDefault

            var franceClub = _clubs.First(c => c.Country == "France");

            var spanishClub = _clubs.FirstOrDefault(c => c.Country == "Spain");

            //Last, LastOrDefault


            var oldPlayer = _players.Last(p => p.Age > 35);

            var youngPlayer = _players.LastOrDefault(p => p.Age < 23);

            //Single, SingleOrDefault

            var reallyOldPlayer = _players.Single(p => p.Age == 37);
           

            var tooOld = _players.SingleOrDefault(p => p.Age == 50);
            
            //ElementAt, ElementAtOrDefault


            var thirdClub = _clubs.ElementAt(2);
          

            var sixthClub = _clubs.ElementAtOrDefault(5);

            //DefaultIfEmpty

            var defaultPlayer = new Player { FirstName = "a", LastName = "b", Age=0};

            var OldPlayers = new List<Player>();
            OldPlayers.Add(new Player());
            OldPlayers.Add(reallyOldPlayer);

            foreach(var player in OldPlayers.DefaultIfEmpty(defaultPlayer))
            {
                Console.WriteLine(player.ToString());
            }

        }

        public static void LinqAggregation()
        {
            //Count, LongCount

            var spanishClubs = _clubs.Count(c => c.Country == "Spain");

            var strikers = _players.LongCount(p => p.Position == "Attacker");


            //Min, Max, 

            var lowestSalary = _players.Min(p => p.Salary);

            var biggestBudget = _clubs.Max(c => c.Budget);

            

            //Sum, Average

            var salaryRealMadridPlayers = _players.Where(p=> p.ClubId == 5).Sum(p => p.Salary);

            var averageClubBudget = _clubs.Average(c => c.Budget);

            //Aggregate

            var clubPresidens = _clubs.Aggregate("", (prevResult, club) => prevResult + club.CEO, clubPresidens => clubPresidens);
            
        }
        
        public static void LinqQuantifiers()
        {
            //Contains 
            var player = new Player { FirstName = "Eder", LastName = "Militao", Age = 23, ClubId = 5, ContractLength = 3, Position = "Defender", Salary = 8 };
            var hasMilitao = _players.Contains(player);

            

            //Any

            var isDefender = _players.Any(p => p.Position == "Defender");

           

            //All

            var areClubsRich = _clubs.All(c => c.Budget > 600000000);
            Console.WriteLine(areClubsRich);

            //SequanceEqual


            var richClubs = _clubs.Where(c => c.Budget > 600000000);

            var isTrue = _clubs.SequenceEqual(richClubs);
            Console.WriteLine(isTrue);
             

        }

        public static void LinqGeneration()
        {
            //Empty

            var empty = Enumerable.Empty<Player>();



            //Repeat

            var cristiano = _players.Where(p => p.Age == 37).FirstOrDefault();

            IEnumerable<Player> cristianoX10 = Enumerable.Repeat(cristiano, 10);

            //Range

            IEnumerable<int> OddRange = Enumerable.Range(0, 50).Where(x => x % 2 != 0);
            PrintCollection(OddRange);
        }

  

        private static readonly IEnumerable<Player> _players = CreatePlayerList();
        private static readonly IEnumerable<Club> _clubs= CreateClubList();
        private static readonly IEnumerable<League> _leagues;

        // united id = 20, city, 25, psg id = 15 barca 10 real 5
        private static IEnumerable<Player> CreatePlayerList()
        {
            return new List<Player>
            {
                new Player{FirstName = "Raphfael", LastName= "Varane", Age= 28, ClubId=20, ContractLength=3, Position="Defender", Salary=12.5 },
                new Player{FirstName = "Sergio", LastName= "Ramos", Age= 35, ClubId=15, ContractLength=2, Position="Defender", Salary=13 },
                new Player{FirstName = "Ronald", LastName= "Araujo", Age= 22, ClubId=10, ContractLength=1, Position="Defender", Salary=4 },
                new Player{FirstName = "Eder", LastName= "Militao", Age= 23, ClubId=5, ContractLength=3, Position="Defender", Salary=8 },
                new Player{FirstName = "Ferland", LastName= "Mendy", Age= 26, ClubId=5, ContractLength=3, Position="Defender", Salary=8 },
                new Player{FirstName = "Rodrygo", LastName= "Goes", Age= 22, ClubId=5, ContractLength=4, Position="Attacker", Salary=6 },
                new Player{FirstName = "Thibout", LastName= "Courtois", Age= 28, ClubId=5, ContractLength=4, Position="Goalkeeper", Salary=12.5 },
                new Player{FirstName = "Marc", LastName= "Ter Stegen", Age= 30, ClubId=10, ContractLength=2, Position="Goalkeeper", Salary=11 },
                new Player{FirstName = "Adama", LastName= "Traore", Age= 23, ClubId=10, ContractLength=1, Position="Attacker", Salary=3 },
                new Player{FirstName = "Frankie", LastName= "De Jong", Age= 24, ClubId=10, ContractLength=2, Position="Midfilder", Salary=10 },
                new Player{FirstName = "Bernardo", LastName= "Silva", Age= 28, ClubId=25, ContractLength=1, Position="Midfilder", Salary=10 },
                new Player{FirstName = "Kylie", LastName= "Walker", Age= 27, ClubId=25, ContractLength=3, Position="Defender", Salary=10 },
                new Player{FirstName = "Kevin", LastName= "De Bruyne", Age= 30, ClubId=25, ContractLength=2, Position="Midfilder", Salary=14 },
                new Player{FirstName = "Cristiano", LastName= "Ronaldo", Age= 37, ClubId=20, ContractLength=2, Position="Attacker", Salary=25 },
                new Player{FirstName = "Harry", LastName= "Maguire", Age= 26, ClubId=20, ContractLength=4, Position="Defender", Salary=14 },
                new Player{FirstName = "Paul", LastName= "Pogba", Age= 29, ClubId=20, ContractLength=1, Position="Midfilder", Salary=18 },
                new Player{FirstName = "Lionel", LastName= "Messi", Age= 34, ClubId=15, ContractLength=2, Position="Attacker", Salary=30 },
                new Player{FirstName = "Kilyan", LastName= "Mbappe", Age= 22, ClubId=15, ContractLength=1, Position="Attacker", Salary=20 },
                new Player{FirstName = "Marco", LastName= "Veratti", Age= 30, ClubId=15, ContractLength=3, Position="Midfilder", Salary=15 },
                new Player{FirstName = "Keylor", LastName= "Navas", Age= 33, ClubId=15, ContractLength=2, Position="Goalkeeper", Salary=10 },
                new Player{FirstName = "Keylor", LastName= "Navas", Age= 33, ClubId=15, ContractLength=2, Position="Goalkeeper", Salary=10 },
                new PlayerCoach{FirstName ="Dorinel", LastName ="Munteanu", Age= 44, ClubId= 15, ContractLength=2, Position="Midfilder", Salary=5, CoachBonuses=2}




            };
        }


        private static IEnumerable<Club> CreateClubList()
        {
            return new List<Club>
            {
                new Club{Name="Real Madrid", CEO = "Florentino Perez", Budget = 990000000, ClubId =5, Country ="Spain", LeagueName= "LaLiga", LeagueId=1
                ,Players = new List<Player> { new Player() {FirstName="p1"}, new Player() { FirstName="p2"} } },
                new Club{Name="Barcelona", CEO = "Joan Laporta", Budget = 640000000, ClubId =10, Country ="Spain", LeagueName= "LaLiga", LeagueId=1
                ,Players = new List<Player> { new Player() {FirstName="p1"}, new Player() { FirstName="p2"} } },
                new Club{Name="Manchester United", CEO = "Glazer Family", Budget = 750000000, ClubId =20, Country ="UK", LeagueName= "Premier League", LeagueId=2
                ,Players = new List<Player> { new Player() {FirstName="p1"}, new Player() { FirstName="p2"} } },
                new Club{Name="Manchester City", CEO = "Sheikh Mansour", Budget = 880000000, ClubId =25, Country ="UK", LeagueName= "Premier League", LeagueId=2
                ,Players = new List<Player> { new Player() {FirstName="p1"}, new Player() { FirstName="p2"} } },
                new Club{Name="Paris Saint-Germain", CEO = "Nasser Al-Khelafi", Budget = 900000000, ClubId =15, Country ="France", LeagueName= "Ligue 1", LeagueId=3
                ,Players = new List<Player> { new Player() {FirstName="p1"}, new Player() { FirstName="p2"} } },

            };
        }

        private static IEnumerable<League> CreateLeagueList()
        {
            return new List<League>
            {
                new League{Name="La Liga", Id=1, President= "Javier Tebas", NumberOfTeams= 20, YearFounded= 1929},
                new League{Name="Premier League", Id=2, President= "Richard Masters", NumberOfTeams= 20, YearFounded= 1992},
                 new League{Name="Ligue 1", Id=3, President= "Vincent Labrune", NumberOfTeams= 20, YearFounded= 1930},


            };

        }


    }

}



