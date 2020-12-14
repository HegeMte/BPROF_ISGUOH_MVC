using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class StatLogic
    {
        IRepository<Player> playerrepo;
        IRepository<Team> teamrepo;
        IRepository<League> leaguerepo;


        public StatLogic(IRepository<Player> playerrepo, IRepository<Team> teamrepo, IRepository<League> leaguerepo)
        {
            this.playerrepo = playerrepo;
            this.teamrepo = teamrepo;
            this.leaguerepo = leaguerepo;

        }

        public StatLogic(IRepository<Player> playerrepo, IRepository<Team> teamrepo)
        {
            this.playerrepo = playerrepo;
            this.teamrepo = teamrepo;
            
        }

        public StatLogic(IRepository<Player> playerrepo)
        {
            this.playerrepo = playerrepo;
        }

        //***************************************************************************************
        //LIGA
        //***************************************************************************************
        public string LegNagyobbLiga()
        {
            
            var q = leaguerepo.Read();
            var neve = q.OrderByDescending(x => x.Teams.Count).FirstOrDefault();

            return neve.LeagueID;

        }


        public int LeagueCount()
        {
            return leaguerepo.Read().Count();
        }

        //***************************************************************************************
        //PLAYER
        //***************************************************************************************
        public string MaxRatedPlayer()
        {
            var q1 = playerrepo.Read();

            var player = q1.OrderByDescending(x => x.Rating).FirstOrDefault();

            return player.PlayerName;
        }


        public int PlayerCount(List<Player> playerlist)
        {

            return playerlist.Count();

        }

        //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
       //::::::::::::::::::::::::::::::::::::::::::::::::::JOIN:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
       //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        public string TeamAVGPlayer(/*List<Player> playerlista,List<Team> teamlista*/)
        {
        

            var q = (from x in playerrepo.Read().ToList()
                     group x by x.TeamID into t
                    join x in teamrepo.Read().ToList() on t.Key equals x.TeamID
                    orderby t.Average(x => x.Rating) descending
                    select x).FirstOrDefault();

            return q.TeamID;
        }


    



        public IEnumerable<Player> FilterPlayers(string teamname)
        {

            var q = from x in playerrepo.Read().ToList()
                    join y in teamrepo.Read().ToList() on x.TeamID equals y.TeamID
                    where y.TeamID == teamname
                    select x;


            return q;
        }

        //Melyik csapat az amelyiknél a legtöbb a weakfoot értéke(sum)
        public string BESTWEAKFOOTSUMBYTEAM()
        {

            var q = (from x in playerrepo.Read().ToList()
                     group x by x.TeamID into t
                     join x in teamrepo.Read().ToList() on t.Key equals x.TeamID
                     orderby t.Sum(x => x.WeakFoot) descending
                     select x).FirstOrDefault();


            return q.TeamID;

        }


    }
}
