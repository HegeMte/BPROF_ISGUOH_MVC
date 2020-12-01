using Microsoft.EntityFrameworkCore;
using Models;
using System;

namespace Data
{
    public class PlayersDbContext : DbContext
    {
        public DbSet<Player> Jatekosok { get; set; }
        public DbSet<Team> Csapatok { get; set; }
        public DbSet<League> Liga { get; set; }
        public PlayersDbContext(DbContextOptions<PlayersDbContext> opt) : base(opt)
        {

        }

        public PlayersDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.
                    UseLazyLoadingProxies().
                    UseSqlServer(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|Player.mdf;integrated security=True;MultipleActiveResultSets=True");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity<Player>(entity =>
            {
                entity
                .HasOne(Player => Player.Csapat)
                .WithMany(Team => Team.Jatekosok)
                .HasForeignKey(Player => Player.TeamID);
            });
            modelbuilder.Entity<Team>(entity =>
            {
                entity
                .HasOne(Team => Team.League)
                .WithMany(League => League.Teams)
                .HasForeignKey(Team => Team.LeagueID);
            });
        }

    }
}
