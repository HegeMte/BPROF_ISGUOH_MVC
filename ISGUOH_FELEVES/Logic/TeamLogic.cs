using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    class TeamLogic
    {
        IRepository<Player> playerrepo;
        IRepository<Team> teamrepo;
        IRepository<League> leaguerepo;

        public TeamLogic(IRepository<Player> playerrepo, IRepository<Team> teamrepo, IRepository<League> leaguerepo)
        {
            this.playerrepo = playerrepo;
            this.leaguerepo = leaguerepo;
            this.teamrepo = teamrepo;
        }


        public void AddTeam(Team team)
        {
            this.teamrepo.Add(team);

        }

        public void DeleteTeam(Team team)
        {
            this.teamrepo.Delete(team);

        }

        public IQueryable<Team> GetAllTeam()
        {
            return teamrepo.Read();
        }

        public Team GetTeam(string TeamID)
        {
            return teamrepo.Read(TeamID);
        }

        public void UpdateTeam(string oldteam,Team newteam)
        {
            teamrepo.Update(oldteam, newteam);
        }
    }
}
