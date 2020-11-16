using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    class LeagueLogic
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


    }
}
