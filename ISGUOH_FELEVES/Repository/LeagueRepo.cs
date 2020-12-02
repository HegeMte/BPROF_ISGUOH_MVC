﻿using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class LeagueRepo : IRepository<League>
    {
        PlayersDbContext context = new PlayersDbContext();

       
        public void Add(League item)
        {
            context.Liga.Add(item);
            Save();

        }

        public void Delete(League item)
        {
            context.Liga.Remove(item);
            Save();
        }

        public void Delete(string LeagueID )
        {
            Delete(Read(LeagueID));
        }

        public League Read(string LeagueID)
        {
            return context.Liga.FirstOrDefault(x => x.LeagueID == LeagueID);
        }

        public IQueryable<League> Read()
        {
            return context.Liga.AsQueryable();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(string RegiligaID, League UjLiga)
        {
            var Regiliga = Read(RegiligaID);
            Regiliga.Country = UjLiga.Country;

            context.SaveChanges();
        }


    }
}
