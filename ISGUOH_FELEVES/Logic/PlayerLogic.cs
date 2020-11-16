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


    }
}
