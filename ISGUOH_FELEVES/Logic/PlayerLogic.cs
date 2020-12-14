using Models;
using Repository;
using System;
using System.Linq;

namespace Logic
{
    public class PlayerLogic
    {
        IRepository<Player> playerrepo;
        IRepository<Team> teamrepo;
        IRepository<League> leaguerepo;

        public PlayerLogic(IRepository<Player> playerrepo, IRepository<Team> teamrepo, IRepository<League> leaguerepo)
        {
            this.playerrepo = playerrepo;
            this.teamrepo = teamrepo;
            this.leaguerepo = leaguerepo;
        }

      
        public PlayerLogic(IRepository<Player> repo)
        {
            this.playerrepo = repo;
        }


        public void AddPlayer(Player player)
        {
            this.playerrepo.Add(player);

        }

        public void DeletePlayer(string IgazolasSzama)
        {
            this.playerrepo.Delete(IgazolasSzama);
        }

        public IQueryable<Player> GetAllPlayers()
        {
            return playerrepo.Read();
        }


        public Player GetPlayer(string IgazolasSzama)
        {
            return playerrepo.Read(IgazolasSzama);
        }


        public void UpdatePlayer(string IgazolasSzama,Player newplayer)
        {
            playerrepo.Update(IgazolasSzama, newplayer);
        }


        public IQueryable<Player> PlayersFromThisTeam(string TeamID)
        {

            var q1 = from x in playerrepo.Read()
                     where x.TeamID == TeamID
                     select x;

            return q1.AsQueryable();

        }

        //public string MaxRatedPlayer()
        //{
        //    var q1 = playerrepo.Read();
            
        //  var player= q1.OrderByDescending(x => x.Rating).FirstOrDefault();

        //    return player.PlayerName;
        //}


        //public int PlayerCount()
        //{

        //    return playerrepo.Read().Count();

        //}

    }
}
