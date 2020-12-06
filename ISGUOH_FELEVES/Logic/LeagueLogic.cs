using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class LeagueLogic
    {
        IRepository<Player> playerrepo;
        IRepository<Team> teamrepo;
        IRepository<League> leaguerepo;

        public LeagueLogic(IRepository<Player> playerrepo, IRepository<Team> teamrepo, IRepository<League> leaguerepo)
        {
            this.teamrepo = teamrepo;
            this.playerrepo = playerrepo;
            this.leaguerepo = leaguerepo;
        }

        public void AddLeague(League league)
        {
            this.leaguerepo.Add(league);
        }

        public void DeleteLeague(string LeagueID)
        {
            this.leaguerepo.Delete(LeagueID);
        }


        public IQueryable<League> GetAllLeague()
        {
            return leaguerepo.Read();
        }

        public League GetLeague (string LeagueID)
        {
            return leaguerepo.Read(LeagueID);
        }

        public void UpdateLeague(string oldLeague, League newLeague)
        {

            leaguerepo.Update(oldLeague, newLeague);
        }

        public IQueryable<Team> GetTeams(string LigaID)
        {
            return leaguerepo.Read(LigaID).Teams.AsQueryable();
        }


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

    }
}
