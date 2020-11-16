using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class PlayerRepo : IRepository<Player>
    {
        PlayersDbContext context = new PlayersDbContext();

        public PlayerRepo(PlayersDbContext contect)
        {
            this.context = contect;
        }
        public void Add(Player item)
        {
            context.Jatekosok.Add(item);
            context.SaveChanges();
        }

        public void Delete(Player item)
        {
            context.Jatekosok.Remove(item);
            context.SaveChanges();
        }

        public void Delete(string Igazolasszama)
        {
            Delete(Read(Igazolasszama));
        }

        public Player Read(string Igazolasszama)
        {
            return context.Jatekosok.FirstOrDefault(x => x.IgazolasSzama == Igazolasszama);
        }

        public IQueryable<Player> Read()
        {
            return context.Jatekosok.AsQueryable();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(string RegiIgazolas, Player ujJatekos)
        {
            var regiJatekos = Read(RegiIgazolas);

            regiJatekos.PlayerName = ujJatekos.PlayerName;
            regiJatekos.Nationality = ujJatekos.Nationality;
            regiJatekos.Rating = ujJatekos.Rating;
            regiJatekos.WeakFoot = ujJatekos.WeakFoot;

            Save();

        }
    }
}
