using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolfScoreOnly.Models
{
    public class ScoreCardModel
    {
        public ScoreCardModel(GolfCourse course, DateTime date, List<Player> players, int roundOfDay = 1)
        {
            Players = players;
            Course = course;
            Date = date;
            RoundOfDay = roundOfDay;
            Scores = new List<Score>();
        }

        public GolfCourse Course { get; set; }
        public DateTime Date { get; set; }
        public int RoundOfDay { get; }
        public List<Score> Scores { get; set; }
        public List<Player> Players { get; set; }

        public int GetPlayerGrossScore(Player player)
        {
            return Scores.Where(h => h.Player == player).Sum(h => h.Gross);
        }

        public int GetPlayerGrossHoleScore(Player player, Hole hole)
        {       
            var gross = from score in Scores
                        where (score.Player == player) && (score.Hole == hole)
                        select score.Gross;
            return gross.FirstOrDefault();
        }

        public Player GetPlayer(int number)
        {
            try
            {
                return Players[number-1];
            }
            catch 
            {
                return null;
            }
        }

        public string GetPlayerName(int number)
        {
            try
            {
                return Players[number-1].Name;
            }
            catch 
            {
                return string.Empty;
            }
        }

    }

    public class Hole
    {

        public Hole()
        {
            Stroke = new Dictionary<string, int>();
            Distance = new Dictionary<string, int>();
        }

        public Hole(int number, int par) : this()
        {
            Number = number;
            Par = par;
        }

        public int Number { get; set; }
        public int Par { get; set; }
        public Dictionary<string, int> Stroke { get; set; }
        public Dictionary<string, int> Distance { get; set; }

        public void AddStroke(string catagory, int stroke)
        {
            Stroke.Add(catagory, stroke);
        }

        public void AddDistance(string tbox, int distance)
        {
            Distance.Add(tbox, distance);
        }

        public List<string> GetStrokeTypes()
        {
            return Stroke.Keys.Distinct().ToList();
        }

        public List<string> GetDistanceTypes()
        {
            return Distance.Keys.Distinct().ToList();
        }
    }

    public class GolfCourse
    {
        public GolfCourse()
        {
            CourseLayout = new List<Hole>();
        }

        public string Name { get; set; }
        public List<Hole> CourseLayout { get; set; }

        
    }

    public class Umhlali
    {
        public Umhlali()
        {
            GolfCourse umhlali = new GolfCourse { Name = "Umhlali" };

            var h1 = new Hole(1, 4);
            h1.AddStroke("Men", 18);
            h1.AddStroke("Ladies", 16);
            h1.AddDistance("Champioship", 294);
            h1.AddDistance("Club", 284);
            h1.AddDistance("Forward", 284);
            h1.AddDistance("Ladies", 245);
            umhlali.CourseLayout.Add(h1);

            var h2 = new Hole(2, 4);
            h2.AddStroke("Men", 6);
            h2.AddStroke("Ladies", 2);
            h2.AddDistance("Champioship", 396);
            h2.AddDistance("Club", 372);
            h2.AddDistance("Forward", 372);
            h2.AddDistance("Ladies", 344);
            umhlali.CourseLayout.Add(h2);

            var h3 = new Hole(3, 4);
            h3.AddStroke("Men", 2);
            h3.AddStroke("Ladies", 4);
            h3.AddDistance("Champioship", 378);
            h3.AddDistance("Club", 370);
            h3.AddDistance("Forward", 370);
            h3.AddDistance("Ladies", 306);
            umhlali.CourseLayout.Add(h3);

            var h4 = new Hole(4, 3);
            h4.AddStroke("Men", 10);
            h4.AddStroke("Ladies", 8);
            h4.AddDistance("Champioship", 188);
            h4.AddDistance("Club", 170);
            h4.AddDistance("Forward", 134);
            h4.AddDistance("Ladies", 129);
            umhlali.CourseLayout.Add(h4);

            var h5 = new Hole(5, 5);
            h5.AddStroke("Men", 14);
            h5.AddStroke("Ladies", 12);
            h5.AddDistance("Champioship", 484);
            h5.AddDistance("Club", 474);
            h5.AddDistance("Forward", 374);
            h5.AddDistance("Ladies", 375);
            umhlali.CourseLayout.Add(h5);

            var h6 = new Hole(6, 3);
            h6.AddStroke("Men", 16);
            h6.AddStroke("Ladies", 18);
            h6.AddDistance("Champioship", 139);
            h6.AddDistance("Club", 132);
            h6.AddDistance("Forward", 132);
            h6.AddDistance("Ladies", 119);
            umhlali.CourseLayout.Add(h6);

            var h7 = new Hole(7, 4);
            h7.AddStroke("Men", 8);
            h7.AddStroke("Ladies", 10);
            h7.AddDistance("Champioship", 326);
            h7.AddDistance("Club", 316);
            h7.AddDistance("Forward", 316);
            h7.AddDistance("Ladies", 282);
            umhlali.CourseLayout.Add(h7);

            var h8 = new Hole(8, 4);
            h8.AddStroke("Men", 12);
            h8.AddStroke("Ladies", 14);
            h8.AddDistance("Champioship", 371);
            h8.AddDistance("Club", 374);
            h8.AddDistance("Forward", 374);
            h8.AddDistance("Ladies", 287);
            umhlali.CourseLayout.Add(h8);

            var h9 = new Hole(9, 4);
            h9.AddStroke("Men", 4);
            h9.AddStroke("Ladies", 6);
            h9.AddDistance("Champioship", 342);
            h9.AddDistance("Club", 338);
            h9.AddDistance("Forward", 3338);
            h9.AddDistance("Ladies", 302);
            umhlali.CourseLayout.Add(h9);

            var players = new List<Player> {
                new Player("Gert", 18),
                new Player("Dude", 17),
                new Player("Bra", 3),
                new Player("Bro", 9)
             };

            ScoreCard = new ScoreCardModel(umhlali, DateTime.Now, players);

            ScoreCard.Scores.Add(new Score { Hole = h1, Player = players[0], Gross = 5 });
            ScoreCard.Scores.Add(new Score { Hole = h1, Player = players[1], Gross = 6 });
            ScoreCard.Scores.Add(new Score { Hole = h1, Player = players[2], Gross = 4 });
            ScoreCard.Scores.Add(new Score { Hole = h1, Player = players[3], Gross = 5 });

            ScoreCard.Scores.Add(new Score { Hole = h2, Player = players[0], Gross = 5 });
            ScoreCard.Scores.Add(new Score { Hole = h2, Player = players[1], Gross = 6 });
            ScoreCard.Scores.Add(new Score { Hole = h2, Player = players[2], Gross = 4 });
            ScoreCard.Scores.Add(new Score { Hole = h2, Player = players[3], Gross = 5 });

            ScoreCard.Scores.Add(new Score { Hole = h3, Player = players[0], Gross = 5 });
            ScoreCard.Scores.Add(new Score { Hole = h3, Player = players[1], Gross = 6 });
            ScoreCard.Scores.Add(new Score { Hole = h3, Player = players[2], Gross = 4 });
            ScoreCard.Scores.Add(new Score { Hole = h3, Player = players[3], Gross = 5 });

            ScoreCard.Scores.Add(new Score { Hole = h4, Player = players[0], Gross = 4 });
            ScoreCard.Scores.Add(new Score { Hole = h4, Player = players[1], Gross = 5 });
            ScoreCard.Scores.Add(new Score { Hole = h4, Player = players[2], Gross = 3 });
            ScoreCard.Scores.Add(new Score { Hole = h4, Player = players[3], Gross = 3 });

        }

        public ScoreCardModel ScoreCard { get; set; }

    }

    public class Player
    {
        public Player(string name, int handicap)
        {
            Name = name;
            Handicap = handicap;
        }

        public string Name { get; set; }
        public int Handicap { get; set; }
    }

    public class Score
    {
        public Player Player { get; set; }
        public Hole Hole { get; set; }
        public int Nett { get; set; }
        public int Gross { get; set; }
    }
}
