﻿using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class TeamRepo : IRepository<Team>
    {
        PlayersDbContext context = new PlayersDbContext();

     

        public void Add(Team item)
        {
            context.Csapatok.Add(item);
            Save();
        }

        public void Delete(Team item)
        {
            context.Csapatok.Remove(item);
            Save();
        }

        public void Delete(string TeamID)
        {
            Delete(Read(TeamID));
        }

        public Team Read(string TeamID)
        {
            return context.Csapatok.FirstOrDefault(x => x.TeamID == TeamID);
        }

        public IQueryable<Team> Read()
        {
            return context.Csapatok.AsQueryable();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(string RegiCsapat, Team ujCsapat)
        {
            var regicsapat = Read(RegiCsapat);
            regicsapat.City = ujCsapat.City;
        
            context.SaveChanges();
        }
    }
}
