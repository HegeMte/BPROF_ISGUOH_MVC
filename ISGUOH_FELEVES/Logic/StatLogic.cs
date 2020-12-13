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


        public int PlayerCount()
        {

            return playerrepo.Read().Count();

        }


        //***************************************************************************************
        //PLAYER
        //***************************************************************************************

        public string LigaAVGPlayer()
        {
            var q = (from x in leaguerepo.Read().ToList()
                    join y in teamrepo.Read().ToList() on x.LeagueID equals y.LeagueID
                    join z in playerrepo.Read().ToList() on y.TeamID equals z.TeamID
                    group x by x.LeagueID into g
                    select new 
                    {
                        LeagueName = g.Key,
                        AVG = g.SelectMany(x =>x.Teams).SelectMany(x => x.Jatekosok).Average(x => x.Rating)

                        
                    }).OrderByDescending(x => x.AVG).FirstOrDefault();


            return q.LeagueName;
        }


    }
}
